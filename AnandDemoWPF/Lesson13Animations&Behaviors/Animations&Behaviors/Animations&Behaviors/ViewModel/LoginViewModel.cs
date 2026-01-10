using Animations_Behaviors.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Animations_Behaviors.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand CancelCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login); CancelCommand = new RelayCommand(Cancel);
        }

        private void Login(object obj)
        {
            MessageBox.Show($"Logging in as: {Username}...", "Welcome");
        }
        private void Cancel(object obj)
        {
            // Closes the entire application
            Application.Current.Shutdown();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
