using System;
using System.Linq;
using System.Reflection;

namespace AssemblyLib.Reflection
{
    internal static class Metadata
    {
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
    }
}
