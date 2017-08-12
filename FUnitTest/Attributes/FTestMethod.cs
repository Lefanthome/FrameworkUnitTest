using System;

namespace FUnitTest.Attributes
{
    [AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class FTestMethod : System.Attribute
    {
    }
}
