using Animations_Behaviors.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Animations_Behaviors.ViewModel
{
    public class AnimationViewModel : INotifyPropertyChanged
    {
        private string _statusText;

        public string StatusText
        {
            get { return _statusText; }
            set { _statusText = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
        public AnimationViewModel()
        {
            StatusText = "Hover over the gray box...";
            SaveCommand = new RelayCommand(SaveData);
        }

        private void SaveData(object obj)
        {
            StatusText = "Mouse Left! Data Saved automatically.";
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
