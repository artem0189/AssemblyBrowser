using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    internal class TypeNode : IAssemblyNode
    {
        public string Name { get; }
        public List<IAssemblyNode> Nodes { get; }

        internal TypeNode(string name)
        {
            Name = name;
            Nodes = new List<IAssemblyNode>();
        }
    }
}
