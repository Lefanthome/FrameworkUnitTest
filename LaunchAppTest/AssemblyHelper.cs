using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LaunchAppTest
{
    public static class AssemblyHelper
    {
        public static IEnumerable<AssemblyName> GetDll(Predicate<string> filter)
        {
            //Get Classe
            Assembly assembly = Assembly.GetEntryAssembly();
            var context = DependencyContext.Load(assembly);

            foreach (var runtimeLibrary in context.RuntimeLibraries)
            {
                foreach (var runtimeAssembly in runtimeLibrary.GetDefaultAssemblyNames(context))
                {
                    if (filter.Invoke(runtimeAssembly.Name))
                    {
                        yield return runtimeAssembly;
                    }
                }
            }
        }

        public static IEnumerable<Type> GetListClass(IEnumerable<AssemblyName> assemblyTypes, Func<TypeInfo, bool> filter)
        {
            foreach (var assemblyType in assemblyTypes)
            {
                var assembly = Assembly.Load(assemblyType);
                foreach (var method in assembly.GetTypes())
                {
                    if(filter.Invoke(method.GetTypeInfo()))
                        yield return method;
               
                }
            }
        }

        public static IEnumerable<MethodInfo> GetMethods(Type classType, Func<MethodInfo, bool> predicate)
        {
            foreach (var method in classType.GetMethods().Where(predicate))
            {
                yield return method;
            }
        }

    }
}
