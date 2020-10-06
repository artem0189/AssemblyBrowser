using System;
using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    internal class NamespaceNode : IAssemblyNode
    {
        public string Name { get; }
        public List<IAssemblyNode> Nodes { get; }

        internal NamespaceNode(Type type)
        {
            Name = type.Namespace;
            Nodes = new List<IAssemblyNode>();
        }

        public override bool Equals(object obj)
        {
            return (obj as NamespaceNode).Name == this.Name;
        }
    }
}
