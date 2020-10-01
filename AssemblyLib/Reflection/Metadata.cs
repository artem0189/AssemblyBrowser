using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using AssemblyLib.AssemblyNode;

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

        internal static List<IAssemblyNode> SortByNamespaces(Type[] types)
        {
            List<IAssemblyNode> result = new List<IAssemblyNode>();
            for (int i = 0; i < types.Length; i++)
            {
                NamespaceNode newNode = new NamespaceNode(types[i].Namespace);
                newNode.Nodes.Add(new TypeNode(types[i].Name));
                int index = result.IndexOf(newNode);
                if (index >= 0)
                {
                    result[index].Nodes.Add(new TypeNode(types[i].Name));
                }
                else
                {
                    result.Add(newNode);
                }
            }
            return result;
        }
    }
}
