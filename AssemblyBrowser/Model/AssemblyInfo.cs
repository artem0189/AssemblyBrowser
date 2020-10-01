using System;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using AssemblyLib;

namespace AssemblyBrowser.Model
{
    public class AssemblyInfo : INotifyPropertyChanged
    {
        private Assembly _assembly;

        private ObservableCollection<object> _assemblyStruct;
        public ObservableCollection<object> AssemblyStruct
        {
            get
            {
                return _assemblyStruct;
            }
        }

        public string Name
        {
            get
            {
                return _assembly.GetName().Name;
            }
        }

        public AssemblyInfo(string assemblyName)
        {
            _assembly = Assembly.LoadFile(assemblyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
