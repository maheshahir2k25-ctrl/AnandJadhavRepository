using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace DependencyProperties.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstName;
        private string _lastName;

        public ICommand vmClickCommand { get; }

        public UserViewModel()
        {
            _firstName = "Mahesh";
            _lastName = "Ahir";
            vmClickCommand = new Utilities.RelayCommand(OnClick, CanClick);   
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnClick(object obj)
        {
            FirstName = "Updated First Name";
            LastName = "Updated Last Name";
        }

        public bool CanClick(object obj)
        {
            return true;
        }
    }
}
