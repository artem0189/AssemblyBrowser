using System;
using System.Reflection;
using System.Collections.Generic;
using AssemblyLib.Reflection;
using AssemblyLib.AssemblyNode;

namespace AssemblyLib
{
    public class AssemblyStructure
    {
        private Assembly _assembly;

        public AssemblyStructure(Assembly assembly)
        {
            _assembly = assembly;
        }

        public List<IAssemblyNode> GetAssemblyStructure()
        {
            Type[] assemblyTypes = Metadata.GetAssemblyTypes(_assembly);
            List<IAssemblyNode> namespaces = Metadata.SortByNamespaces(assemblyTypes);
            return namespaces;
        }
    }
}
