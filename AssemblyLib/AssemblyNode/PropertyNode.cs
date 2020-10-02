using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    internal class PropertyNode : IAssemblyNode
    {
        public string Name { get; }
        public List<IAssemblyNode> Nodes { get; }

        public PropertyNode(string name)
        {
            Name = name;
            Nodes = null;
        }
    }
}
