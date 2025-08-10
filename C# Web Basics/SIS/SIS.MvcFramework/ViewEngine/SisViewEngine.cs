using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using SIS.MvcFramework.Identity;
using SIS.MvcFramework.Validation;

using System.Collections;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace SIS.MvcFramework.ViewEngine
{
    public class SisViewEngine : IViewEngine
    {
        private string GetModelType<T>(T model)
        {
            if (model is IEnumerable)
            {
                return $"IEnumerable<{model.GetType().GetGenericArguments()[0].FullName}>";
            }

            return model.GetType().FullName;
        }

        public string GetHtml<T>(string viewContent, T model, ModelStateDictionary modelState, IdentityUser user)
        {
            string csharpHtmlCode = string.Empty;
            csharpHtmlCode = this.CheckForWidgets(viewContent);
            csharpHtmlCode = this.GetCSharpCode(csharpHtmlCode);
            string code = $@"
using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using SIS.MvcFramework.ViewEngine;
using SIS.MvcFramework.Identity;
using SIS.MvcFramework.Validation;
namespace AppViewCodeNamespace
{{
    public class AppViewCode : IView
    {{
        public string GetHtml(object model, ModelStateDictionary modelState, IdentityUser user)
        {{
            var Model = {(model == null ? "new {}" : "model as " + GetModelType(model))};
            var User = user;
            var ModelState = modelState;

            var html = new StringBuilder();

            {csharpHtmlCode}

            return html.ToString();
        }}
    }}
}}";

            var view = this.CompileAndInstantiate(code, model?.GetType().Assembly);
            string htmlResult = view?.GetHtml(model, modelState, user);
            return htmlResult;
        }

        private string CheckForWidgets(string viewContent)
        {
            var widgets = Assembly
                .GetEntryAssembly()?
                .GetTypes()
                .Where(type => typeof(IViewWidget)
                .IsAssignableFrom(type))
                .Select(x => (IViewWidget)Activator.CreateInstance(x))
                .ToList();

            if (widgets == null || widgets.Count == 0)
            {
                return viewContent;
            }

            string widgetPrefix = "@Widgets.";

            foreach (var viewWidget in widgets)
            {
                viewContent = viewContent.Replace($"{widgetPrefix}{viewWidget.GetType().Name}", viewWidget.Render());
            }

            return viewContent;
        }

        private string GetCSharpCode(string viewContent)
        {
            string[] lines = viewContent.Split(new string[] { "\r\n", "\n\r", "\n" }, StringSplitOptions.None);
            StringBuilder csharpCode = new StringBuilder();
            string[] supportedOperators = new string[] { "for", "if", "else" };
            Regex csharpCodeRegex = new Regex(@"[^\s<""\&]+", RegexOptions.Compiled);
            int csharpCodeDepth = 0; // If > 0, Inside CSharp Syntax

            foreach (var line in lines)
            {
                string currentLine = line;

                if (currentLine.TrimStart().StartsWith("@{"))
                {
                    csharpCodeDepth++;
                }
                else if (currentLine.TrimStart().StartsWith("{") || currentLine.TrimStart().StartsWith("}"))
                {
                    if (csharpCodeDepth > 0)
                    {
                        if (currentLine.TrimStart().StartsWith("{"))
                        {
                            csharpCodeDepth++;
                        }
                        else if (currentLine.TrimStart().StartsWith("}"))
                        {
                            if ((--csharpCodeDepth) == 0)
                            {
                                continue;
                            }
                        }
                    }

                    csharpCode.AppendLine(currentLine);
                }
                else if (csharpCodeDepth > 0)
                {
                    csharpCode.AppendLine(currentLine);
                    continue;
                }
                else if (supportedOperators.Any(x => currentLine.TrimStart().StartsWith("@" + x)))
                {
                    // @C#
                    int atSignLocation = currentLine.IndexOf("@");
                    string csharpLine = currentLine.Remove(atSignLocation, 1);
                    csharpCode.AppendLine(csharpLine);
                }
                else
                {
                    // HTML
                    if (currentLine.Contains("@RenderBody()"))
                    {
                        string csharpLine = $"html.AppendLine(@\"{currentLine}\");";
                        csharpCode.AppendLine(csharpLine);
                    }
                    else
                    {
                        string csharpStringToAppend = "html.AppendLine(@\"";
                        string restOfLine = currentLine;
                        while (restOfLine.Contains("@"))
                        {
                            int atSignLocation = restOfLine.IndexOf("@");
                            string plainText = restOfLine.Substring(0, atSignLocation).Replace("\"", "\"\"");
                            var csharpExpression = csharpCodeRegex.Match(restOfLine.Substring(atSignLocation + 1))?.Value;

                            if (csharpExpression.Contains("{") && csharpExpression.Contains("}"))
                            {
                                string csharpInlineExpression = csharpExpression.Substring(1, csharpExpression.IndexOf("}") - 1);
                                csharpStringToAppend += plainText + "\" + " + csharpInlineExpression + " + @\"";
                                csharpExpression = csharpExpression.Substring(0, csharpExpression.IndexOf("}") + 1);
                            }
                            else
                            {
                                csharpStringToAppend += plainText + "\" + " + csharpExpression + " + @\"";
                            }

                            if (restOfLine.Length <= atSignLocation + csharpExpression.Length + 1)
                            {
                                restOfLine = string.Empty;
                            }
                            else
                            {
                                restOfLine = restOfLine.Substring(atSignLocation + csharpExpression.Length + 1);
                            }
                        }

                        csharpStringToAppend += $"{restOfLine.Replace("\"", "\"\"")}\");";
                        csharpCode.AppendLine(csharpStringToAppend);
                    }
                }
            }

            return csharpCode.ToString();
        }

        private IView CompileAndInstantiate(string code, Assembly modelAssembly)
        {
            modelAssembly = modelAssembly ?? Assembly.GetEntryAssembly();

            var compilation = CSharpCompilation.Create("AppViewAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(typeof(Object).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(Assembly.GetEntryAssembly().Location))
                .AddReferences(MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("netstandard")).Location))
                .AddReferences(MetadataReference.CreateFromFile(modelAssembly.Location));

            var netStandardAssembly = Assembly.Load(new AssemblyName("netstandard")).GetReferencedAssemblies();
            foreach (var assembly in netStandardAssembly)
            {
                compilation = compilation.AddReferences(MetadataReference.CreateFromFile(Assembly.Load(assembly).Location));
            }

            compilation = compilation.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(code));

            using (var memoryStream = new MemoryStream())
            {
                var compilationResult = compilation.Emit(memoryStream);
                if (!compilationResult.Success)
                {
                    var errors = compilationResult.Diagnostics.Where(x => x.Severity == DiagnosticSeverity.Error);
                    StringBuilder errorsHtml = new StringBuilder();
                    errorsHtml.AppendLine($"<h1>{errors.Count()} errors:</h1>");
                    foreach (var error in errors)
                    {
                        errorsHtml.AppendLine($"<div>{error.Location} => {error.GetMessage()}</div>");
                    }

                    errorsHtml.AppendLine($"<pre>{WebUtility.HtmlEncode(code)}</pre>");
                    return new ErrorView(errorsHtml.ToString());
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                byte[] assemblyBytes = memoryStream.ToArray();
                var assembly = Assembly.Load(assemblyBytes);

                var type = assembly.GetType("AppViewCodeNamespace.AppViewCode");
                if (type == null)
                {
                    Console.WriteLine("AppViewCode not found.");
                    return null;
                }

                var instance = Activator.CreateInstance(type);
                return instance as IView;
            }
        }
    }
}
