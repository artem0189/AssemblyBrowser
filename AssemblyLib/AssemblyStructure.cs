using System;
using System.Reflection;
using System.Collections.Generic;
using AssemblyLib.Reflection;
using AssemblyLib.AssemblyNode;

namespace AssemblyLib
{
    public class AssemblyStructure
    {
        private Assembly _assembly;

        public AssemblyStructure(Assembly assembly)
        {
            _assembly = assembly;
        }

        public List<IAssemblyNode> GetAssemblyStructure()
        {
            Type[] assemblyTypes = Metadata.GetAssemblyTypes(_assembly);
            for (int i = 0; i < assemblyTypes.Length; i++)
            {

            }
            return null;
        }
    }
}
