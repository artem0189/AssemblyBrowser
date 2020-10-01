using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AssemblyLib;
using AssemblyLib.AssemblyNode;

namespace AssemblyBrowser.Model
{
    public class AssemblyInfo
    {
        public Assembly Assembly { get; }
        public List<IAssemblyNode> AssemblyStruct { get; }

        public AssemblyInfo(string assemblyName)
        {
            Assembly = Assembly.LoadFrom(assemblyName);
            AssemblyStruct = new AssemblyStructure(Assembly).GetAssemblyStructure();
        }
    }
}
