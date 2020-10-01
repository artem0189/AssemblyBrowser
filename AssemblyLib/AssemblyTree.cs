using System.Reflection;
using System.Collections.Generic;
using AssemblyLib.AssemblyNode;

namespace AssemblyLib
{
    internal class AssemblyTree
    {
        private Assembly _assembly;

        internal AssemblyTree(Assembly assembly)
        {
            _assembly = assembly;
        }

        internal List<IAssemblyNode> GetAssemblyTree()
        {
            return null;
        }
    }
}
