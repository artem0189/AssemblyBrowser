using System;
using System.Reflection;
using System.Collections.Generic;
using AssemblyLib.Node;

namespace AssemblyLib
{
    public class AssemblyStructure
    {
        private AssemblyTree _assemblyTree;

        public AssemblyStructure(string assemblyName)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyName);
            _assemblyTree = new AssemblyTree(assembly);
        }

        public void SetCustomNameFunc(TypeNode typeNode, Func<object, string> func)
        {
            _assemblyTree.SetCustomNameFunc(typeNode, func);
        }

        public List<AssemblyNode> GetAssemblyStructure()
        {
            return _assemblyTree.GetAssemblyTree();
        }
    }
}
