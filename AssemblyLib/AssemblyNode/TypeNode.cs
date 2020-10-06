using System;
using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    internal class TypeNode : IAssemblyNode
    {
        public string Name { get; }
        public List<IAssemblyNode> Nodes { get; }

        internal TypeNode(Type type)
        {
            Name = type.Name;
            Nodes = new List<IAssemblyNode>();
        }
    }
}
