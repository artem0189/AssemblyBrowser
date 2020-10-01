using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    internal class FieldNode : IAssemblyNode
    {
        public string Name { get; }
        public List<IAssemblyNode> Nodes { get; }

        internal FieldNode(string name)
        {
            Name = name;
            Nodes = null;
        }
    }
}
