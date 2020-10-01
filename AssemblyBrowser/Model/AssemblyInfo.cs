using System;
using System.Reflection;
using System.Collections.ObjectModel;
using AssemblyLib;

namespace AssemblyBrowser.Model
{
    public class AssemblyInfo
    {
        public Assembly Assembly { get; }
        public ObservableCollection<object> AssemblyStruct { get; }

        public AssemblyInfo(string assemblyName)
        {
            Assembly = Assembly.LoadFile(assemblyName);
            AssemblyStruct = AssemblyStructure.GetAssemblyStructure(Assembly);
        }
    }
}
