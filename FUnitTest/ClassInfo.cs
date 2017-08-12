using System;
using System.Collections.Generic;
using System.Reflection;

namespace FUnitTest
{
    public class ClassInfo
    {
        public Type Type { get; set; }
        public readonly string ClassName;
        public List<MethodInfo> MethodsInfo { get; set; }

        public ClassInfo(string name)
        {
            ClassName = name;
        }
    }
}
