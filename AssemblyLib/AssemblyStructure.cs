using System;
using System.Reflection;
using System.Collections.Generic;
using AssemblyLib.Reflection;
using AssemblyLib.AssemblyNode;

namespace AssemblyLib
{
    public class AssemblyStructure
    {
        private AssemblyTree _assemblyTree;

        public AssemblyStructure(Assembly assembly)
        {
            _assemblyTree = new AssemblyTree(assembly);
        }

        public List<IAssemblyNode> GetAssemblyStructure()
        {
            return _assemblyTree.GetAssemblyTree();
        }
    }
}
