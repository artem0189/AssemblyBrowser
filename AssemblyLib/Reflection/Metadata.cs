using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AssemblyLib.Reflection
{
    internal static class Metadata
    {
        private const BindingFlags _flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly;

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

        internal static MethodInfo[] GetMethods(Type type)
        {
            return type.GetMethods(_flags).Where(method => !method.IsSpecialName).ToArray();
        }

        internal static FieldInfo[] GetFields(Type type)
        {
            return type.GetFields(_flags).Where(field => !field.IsDefined(typeof(CompilerGeneratedAttribute))).ToArray();
        }

        internal static PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties(_flags).Where(property => !property.IsSpecialName).ToArray();
        }
    }
}
