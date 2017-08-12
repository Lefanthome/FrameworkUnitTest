using System;

namespace FUnitTest.Attributes
{
    [AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class FTestClass : System.Attribute
    {
    }
}
