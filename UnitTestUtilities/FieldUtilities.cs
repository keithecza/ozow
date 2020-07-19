using System;
using System.Reflection;

namespace UnitTestUtilities
{
    public static class FieldUtilities
    {
        #region METHODS
        
        public static T GetInternal<T>(object instance, string fieldName)
        {
            FieldInfo field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            
            if (field == null)
                throw new Exception($"Cannot get the value of the field {fieldName} as it is not a member of the class {instance.GetType().FullName}");
            return (T)Convert.ChangeType(field.GetValue(instance), typeof(T));
        }
        
        #endregion
    }
}