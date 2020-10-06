using System.Reflection;
using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    internal class FieldNode : IAssemblyNode
    {
        public string Name { get; }
        public List<IAssemblyNode> Nodes { get; }

        internal FieldNode(FieldInfo field)
        {
            Name = field.FieldType.Name + " " + field.Name;
            Nodes = null;
        }
    }
}
