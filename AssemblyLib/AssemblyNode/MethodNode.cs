using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    internal class MethodNode : IAssemblyNode
    {
        public string Name { get; }
        public List<IAssemblyNode> Nodes { get; }

        internal MethodNode(string name)
        {
            Name = name;
            Nodes = null;
        }
    }
}
