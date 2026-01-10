using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Resources_Styles.ViewModel
{
    public class UserStatusViewModel : INotifyPropertyChanged
    {
        public Model.UserStatus UserStatus { get; set; } = new Model.UserStatus();


        public bool IsOnline
        {
            get { return UserStatus.IsOnline; }
            set { UserStatus.IsOnline = value; OnPropertyChanged(); } 
        }

        private string _changeColor="Red";
        public string ChangeColor 
        {
            get { return _changeColor; }
            set { _changeColor = value; OnPropertyChanged(); }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
