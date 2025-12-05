using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
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
//using System.Runtime.CompilerServices;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for INotifyPropertyChangeWindow.xaml
    /// </summary>
    public partial class INotifyPropertyChangeWindow : Window, INotifyPropertyChanged
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        private int _userAge;
        public int UserAge
        {
            get { return _userAge; }
            set { _userAge = value; OnPropertyChanged(nameof(UserAge)); }
        }
        public INotifyPropertyChangeWindow()
        {
            InitializeComponent();

            this.UserName = "Anand";
            this.UserAge = 25;
            this.DataContext = this;
        }
        // 2. Define the Event (This is the "Shout" mechanism)
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            // 3. Raise the event (This is the "Shout Out Loud" action)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        bool changeName = false;
        private void ChangeName_Click(object sender, RoutedEventArgs e)
        {
            if (changeName == false)
            {
                // 2. We change the variable in memory.
                this.UserName = "Rahul";
                this.UserAge = 30;
                // 3. PROOF that the variable actually changed:
                //MessageBox.Show($"The variable is now: {UserName}\nBut look at the TextBlock behind this box... it still says Anand!");
            }
            else
            {
                this.UserName = "Anand";
                this.UserAge = 25;
            }
            changeName= !changeName;
        }
    }
}
