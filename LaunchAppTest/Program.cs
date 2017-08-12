using FUnitTest;
using FUnitTest.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace LaunchAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://proemmer.azurewebsites.net/2016/10/06/create-and-load-code-at-runtime-in-dotnet-core/
            //https://blogs.msdn.microsoft.com/luisdem/2017/03/19/net-core-1-1-how-to-publish-a-self-contained-application/
           var dlls = AssemblyHelper.GetDll(x => x.EndsWith("Test"));
           
           Console.WriteLine($"Launch App Test - Version {Assembly.GetEntryAssembly().GetName().Version}");
           
            Func<TypeInfo, bool> filter = x => { var attribute = x.GetCustomAttributes<FTestClass>().FirstOrDefault(); return attribute != null; };
            var classList = AssemblyHelper.GetListClass(dlls, filter);

            foreach (var classType in classList)
            {
                ClassInfo classInfo = new ClassInfo(classType.Name);
                classInfo.Type = classType;

                Func<MethodInfo, bool> attributeFilter = x => x.GetCustomAttributes<FTestMethod>().FirstOrDefault() != null;
                classInfo.MethodsInfo = AssemblyHelper.GetMethods(classType, attributeFilter).ToList();

                FUnitCore.Excecute(classInfo);
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }


    }
}