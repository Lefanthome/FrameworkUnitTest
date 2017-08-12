using System;

namespace FUnitTest.Attributes
{
    [AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class FTestCategory : System.Attribute
    {
        public string CategoryName { get; set; }

        public FTestCategory(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
