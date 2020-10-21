using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyBrowser.Command;
using AssemblyBrowser.Model;

namespace AssemblyBrowser.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Assembly _assembly;
        public Assembly Assembly
        {
            get
            {
                return _assembly;
            }
            set
            {
                _assembly = value;
                OnPropertyChanged("Assembly");
            }
        }

        private RelayCommand _loadAssemblyCommad;
        public RelayCommand LoadAssemblyCommand
        {
            get
            {
                return _loadAssemblyCommad ??
                    (_loadAssemblyCommad = new RelayCommand(obj =>
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Assembly |*.dll";
                        if (openFileDialog.ShowDialog() == true)
                        {
                            Assembly = new Assembly(openFileDialog.FileName);
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
