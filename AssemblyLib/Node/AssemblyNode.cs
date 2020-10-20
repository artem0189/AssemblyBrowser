using System.Collections.Generic;

namespace AssemblyLib.Node
{
    public enum TypeNode
    {
        Namespace,
        Type,
        Method,
        Field,
        Property
    }

    public class AssemblyNode
    {
        public TypeNode NodeType { get; }
        public object ObjectType { get; }
        public string Name { get; }
        public List<AssemblyNode> Childrens { get; }

        public AssemblyNode(TypeNode nodeType, object objectType, string name)
        {
            NodeType = nodeType;
            ObjectType = objectType;
            Name = name;
            Childrens = new List<AssemblyNode>();
        }

        public override bool Equals(object obj)
        {
            return (obj as AssemblyNode).Name == Name;
        }
    }
}
