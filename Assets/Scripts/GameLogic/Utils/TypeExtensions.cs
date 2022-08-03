using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core.Utils
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetSubType(this Type type)
        {
            return Assembly.GetAssembly(type).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(type));
        }
        public static IEnumerable<Type> GetTypeWithAttribute<T>() where T:Attribute
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                foreach(Type type in assembly.GetTypes()) {
                    if (type.GetCustomAttributes(typeof(T), true).Length > 0) {
                        yield return type;
                    }
                }
            }
           
        }
    }
}