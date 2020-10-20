using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyLib;
using AssemblyLib.Node;

namespace AssemblyBrowser.Model
{
    public class Assembly : INotifyPropertyChanged
    {
        private AssemblyStructure _assemblyStructure;
        public List<AssemblyNode> Nodes
        {
            get
            {
                return _assemblyStructure?.GetAssemblyStructure();
            }
        }

        public Assembly(string assemblyName)
        {
            _assemblyStructure = new AssemblyStructure(assemblyName);
        }

        public void SetCustomNameFunc(TypeNode typeNode, Func<object, string> func)
        {
            _assemblyStructure.SetCustomNameFunc(typeNode, func);
            OnPropertyChanged("Nodes");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
