using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyBrowser.Command;
using AssemblyBrowser.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private AssemblyInfo _assemblyInfo;
        public AssemblyInfo AssemblyInfo
        {
            get
            {
                return _assemblyInfo;
            }
            set
            {
                _assemblyInfo = value;
                OnPropertyChanged("AssemblyInfo");
            }
        }

        private RelayCommand _loadAssemblyCommad;
        public RelayCommand LoadAssemblyCommand
        {
            get
            {
                return _loadAssemblyCommad ??
                    (new RelayCommand(obj =>
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Assembly |*.dll";
                        if (openFileDialog.ShowDialog() == true)
                        {
                            AssemblyInfo = new AssemblyInfo(openFileDialog.FileName);
                        }
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
