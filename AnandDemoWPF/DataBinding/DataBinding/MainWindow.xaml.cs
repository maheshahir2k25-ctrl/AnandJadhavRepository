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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMyInterface
    {
        public string UserName { get; set; }
        public int UserAge { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            string LastName = "";

            this.UserName = "Anand";
            this.UserAge = 25;
            LastName = "Jadhav";
            //txtUserName.Text = UserName;
            //txtAge.Text=UserAge.ToString();

            this.DataContext = this;
        }

        private void ChangeName_Click(object sender, RoutedEventArgs e)
        {
            // 2. We change the variable in memory.
            this.UserName = "Rahul";

            // 3. PROOF that the variable actually changed:
            MessageBox.Show($"The variable is now: {UserName}\nBut look at the TextBlock behind this box... it still says Anand!");
        }

        public void GetAge()
        {
            this.UserName = "Anand";
        }

        public void GetName()
        {
            this.UserAge = 25;
        }
    }
}
