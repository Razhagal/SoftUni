using SIS.MvcFramework.ViewEngine;

namespace SIS.MvcFramework.Tests
{
    public class TestSisViewEngine
    {
        [Theory]
        [InlineData("TestWithoutCSharpCode")]
        [InlineData("UseForForeachAndIf")]
        [InlineData("UseModelData")]
        public void TestGetHtml(string testFileName)
        {
            IViewEngine viewEngine = new SisViewEngine();
            string viewFileName = $"ViewTests/{testFileName}.html";
            string expectedResultFileName = $"ViewTests/{testFileName}.Result.html";

            var viewContent = File.ReadAllText(viewFileName);
            var expectedResult = File.ReadAllText(expectedResultFileName);

            var actualResult = viewEngine.GetHtml<object>(viewContent, new TestViewModel()
            {
                StringValue = "str",
                ListValues = new List<string> { "123", "val1", string.Empty }
            },
            new Validation.ModelStateDictionary(),
            new Identity.IdentityUser() { });

            Assert.Equal(expectedResult.TrimEnd(), actualResult.TrimEnd());
        }
    }
}