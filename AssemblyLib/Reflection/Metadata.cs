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
            List<IAssemblyNode> result = new List<IAssemblyNode>();
            MethodInfo[] methods = type.GetMethods(_flags | BindingFlags.DeclaredOnly).;
            for (int i = 0; i < methods.Length; i++)
            {
                result.Add(new MethodNode(methods[i].Name));
            }
            return result;
        }

        internal static List<IAssemblyNode> GetFields(Type type)
        {
            List<IAssemblyNode> result = new List<IAssemblyNode>();
            FieldInfo[] fields = type.GetFields(_flags);
            for (int i = 0; i < fields.Length; i++)
            {
                result.Add(new FieldNode(fields[i].Name));
            }
            return result;
        }

        internal static List<IAssemblyNode> GetProperties(Type type)
        {
            List<IAssemblyNode> result = new List<IAssemblyNode>();
            PropertyInfo[] properties = type.GetProperties(_flags);
            for (int i = 0; i < properties.Length; i++)
            {
                result.Add(new PropertyNode(properties[i].Name));
            }
            return result;
        }
    }
}
