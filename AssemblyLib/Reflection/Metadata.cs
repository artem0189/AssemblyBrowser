using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using AssemblyLib.AssemblyNode;

namespace AssemblyLib.Reflection
{
    internal static class Metadata
    {
        private const BindingFlags _flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        internal static Type[] GetAssemblyTypes(Assembly assembly)
        {
            Type[] assemblyTypes = new Type[0];
            try
            {
                assemblyTypes = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                assemblyTypes = ex.Types.Where(type => type != null).ToArray();
            }
            return assemblyTypes;
        }

        internal static List<IAssemblyNode> GetMethods(Type type)
        {
            string name = "";
            List<IAssemblyNode> result = new List<IAssemblyNode>();
            MethodInfo[] methods = type.GetMethods(_flags | BindingFlags.DeclaredOnly);
            for (int i = 0; i < methods.Length; i++)
            {
                name = GetMethodSignature(methods[i]);
                result.Add(new MethodNode(name));
            }
            return result;
        }

        private static string GetMethodSignature(MethodInfo method)
        {
            string result = method.ReturnType.Name + " " + method.Name + "(";
            ParameterInfo[] parameters = method.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                result += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                if (i < parameters.Length - 1)
                {
                    result += ", ";
                }
            }
            return result + ")";
        }

        internal static List<IAssemblyNode> GetFields(Type type)
        {
            string name = "";
            List<IAssemblyNode> result = new List<IAssemblyNode>();
            FieldInfo[] fields = type.GetFields(_flags);
            for (int i = 0; i < fields.Length; i++)
            {
                name = fields[i].FieldType.Name + " " + fields[i].Name;
                result.Add(new FieldNode(name));
            }
            return result;
        }

        internal static List<IAssemblyNode> GetProperties(Type type)
        {
            string name = "";
            List<IAssemblyNode> result = new List<IAssemblyNode>();
            PropertyInfo[] properties = type.GetProperties(_flags);
            for (int i = 0; i < properties.Length; i++)
            {
                name = properties[i].PropertyType.Name + " " + properties[i].Name;
                result.Add(new PropertyNode(name));
            }
            return result;
        }
    }
}
