using System;
using System.Reflection;
using System.Collections.Generic;
using AssemblyLib.AssemblyNode;
using AssemblyLib.Reflection;
using AssemblyLib.Extension;

namespace AssemblyLib
{
    internal class AssemblyTree
    {
        private Assembly _assembly;
        private List<IAssemblyNode> _tree;
        private const BindingFlags _flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        internal AssemblyTree(Assembly assembly)
        {
            _assembly = assembly;
            _tree = new List<IAssemblyNode>();     
        }

        private void CreateTree()
        {
            IAssemblyNode currentNode;
            Type[] types = Metadata.GetAssemblyTypes(_assembly);
            for (int i = 0; i < types.Length; i++)
            {
                currentNode = _tree.GetOrAdd(new NamespaceNode(types[i].Namespace));
                currentNode = currentNode.Nodes.GetOrAdd(new TypeNode(types[i].Name));
                currentNode.Nodes.AddRange(GetMembers(types[i]));
            }
        }

        private List<IAssemblyNode> GetMembers(Type type)
        {
            List<IAssemblyNode> result = new List<IAssemblyNode>();
            return result;
        }

        internal List<IAssemblyNode> GetAssemblyTree()
        {
            CreateTree();
            return _tree;
        }
    }
}
