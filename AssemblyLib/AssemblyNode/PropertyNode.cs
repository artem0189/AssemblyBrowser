using System.Reflection;
using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    internal class PropertyNode : IAssemblyNode
    {
        public string Name { get; }
        public List<IAssemblyNode> Nodes { get; }

        public PropertyNode(PropertyInfo property)
        {
            Name = property.PropertyType.Name + " " + property.Name;
            Nodes = null;
        }
    }
}
