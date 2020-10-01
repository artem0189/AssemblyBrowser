using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    internal class NamespaceNode : IAssemblyNode
    {
        public string Name { get; }
        public List<IAssemblyNode> Nodes { get; }

        internal NamespaceNode(string name)
        {
            Name = name;
            Nodes = new List<IAssemblyNode>();
        }
    }
}
