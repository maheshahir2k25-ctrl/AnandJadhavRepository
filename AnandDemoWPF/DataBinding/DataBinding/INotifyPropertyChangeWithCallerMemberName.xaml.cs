using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for INotifyPropertyChangeWithCallerMemberName.xaml
    /// </summary>
    public partial class INotifyPropertyChangeWithCallerMemberName : Window,INotifyPropertyChanged
    {
        public INotifyPropertyChangeWithCallerMemberName()
        {
            InitializeComponent();
            this.UserName = "Anand";
            this.UserAge = 25;
            this.DataContext = this;
        }

        private string _userName;
        public string UserName {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
            
        }

        private int _userAge;
        public int UserAge 
        {
            get { return _userAge; }
            set { _userAge = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ChangeName_Click(object sender, RoutedEventArgs e)
        {
            this.UserName = "Rahul";
            this.UserAge = 30;

        }
    }
}
