using System;
using System.Reflection;

namespace UnitTestUtilities
{
    public static class MethodUtilities
    {
        public static T CallInternal<T>(object instance, string name, params object[] arguments )
        {
            MethodInfo methodInfo = instance.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
            
            if (methodInfo == null)
                throw new Exception($"Cannot call {name} as it is not a member of the class {instance.GetType().FullName}");
            return (T)methodInfo.Invoke(instance, arguments); 
        }
    }
}