using System;
using System.Reflection;

namespace AssemblyLib.Reflection
{
    internal static class NameFormatter
    {
        private static string GetType(Type type)
        {
            string result = type.Name;
            if (type.IsGenericType)
            {
                result = result.Substring(0, result.LastIndexOf("`"));
                result += "<";
                Type[] genericArgs = type.GetGenericArguments();
                for (int i = 0; i < genericArgs.Length; i++)
                {
                    result += GetType(genericArgs[i]);
                    if (i != genericArgs.Length - 1)
                    {
                        result += ", ";
                    }
                }
                result += ">";
            }
            return result;
        }

        internal static string GetNamespaceName(object objectType)
        {
            return (objectType as Type).Namespace;
        }

        internal static string GetTypeName(object objectType)
        {
            Type type = objectType as Type;
            return GetType(type);
        }

        internal static string GetFieldName(object objectType)
        {
            FieldInfo field = objectType as FieldInfo;
            return GetType(field.FieldType) + " " + field.Name;
        }

        internal static string GetPropertyName(object objectType)
        {
            PropertyInfo property = objectType as PropertyInfo;
            return GetType(property.PropertyType) + " " + property.Name;
        }

        internal static string GetMethodSignature(object objectType)
        {
            MethodInfo method = objectType as MethodInfo;
            string result = GetType(method.ReturnType) + " " + method.Name;
            if (method.IsGenericMethod)
            {
                result += "<";
                Type[] genericArgs = method.GetGenericArguments();
                for (int i = 0; i < genericArgs.Length; i++)
                {
                    result += GetType(genericArgs[i]);
                    if (i != genericArgs.Length - 1)
                    {
                        result += ", ";
                    }
                }
                result += ">";
            }
            result += "(";
            ParameterInfo[] parameters = method.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                result += GetType(parameters[i].ParameterType) + " " + parameters[i].Name;
                if (i != parameters.Length - 1)
                {
                    result += ", ";
                }
            }
            result += ")";
            return result;
        }
    }
}
