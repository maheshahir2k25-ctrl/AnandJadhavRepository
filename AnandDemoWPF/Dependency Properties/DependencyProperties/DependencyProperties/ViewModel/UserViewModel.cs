using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DependencyProperties.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _isOnline;
        public ICommand ViewModelButtonClick { get;}
        public UserViewModel()
        {
            FirstName = "John";
            LastName = "Doe";
            IsOnline = "Online";
            ViewModelButtonClick = new Utilities.RelayCommand(ShowMessage, CanExecute); 
        }

        public void ShowMessage(object obj)
        {
            System.Windows.MessageBox.Show($"FirstName= {FullName}, LastName={LastName}, FullName={FullName},IsOnline={IsOnline.ToString()}");
        }
        public bool CanExecute(object obj)
        {
            return true;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); OnPropertyChanged("FullName"); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); OnPropertyChanged("FullName"); }
        }
        public string IsOnline
        {
            get { return _isOnline; }
            set { _isOnline = value; OnPropertyChanged(); }
        }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
