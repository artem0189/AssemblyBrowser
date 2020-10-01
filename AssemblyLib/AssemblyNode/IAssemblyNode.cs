using System.Collections.Generic;

namespace AssemblyLib.AssemblyNode
{
    public interface IAssemblyNode
    {
        string Name { get; }
        List<IAssemblyNode> Nodes { get; }
    }
}
