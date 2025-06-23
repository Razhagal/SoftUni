using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            MethodInfo[] objMethods = objType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            PropertyInfo[] properties = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            //foreach (PropertyInfo item in properties)
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.GetValue(obj, null));
            //}

            //foreach (MethodInfo method in objMethods)
            //{
            //    if (method.Name.StartsWith("get"))
            //    {
            //        Console.WriteLine(method.Name);
            //        Console.WriteLine(method.Invoke(obj, null));
            //    }

            //}

            foreach (PropertyInfo property in properties)
            {
                if (property.CustomAttributes.Any(a => a.AttributeType.BaseType.Equals(typeof(MyValidationAttribute))))
                {
                    //Console.WriteLine(property.Name);
                    var attributes = property.GetCustomAttributes(typeof(MyValidationAttribute));
                    foreach (Attribute attribute in attributes)
                    {
                        //Console.WriteLine(property.GetValue(obj, null) + " " + ((MyValidationAttribute)item).IsValid(property.GetValue(obj, null)));
                        if (!((MyValidationAttribute)attribute).IsValid(property.GetValue(obj, null)))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
