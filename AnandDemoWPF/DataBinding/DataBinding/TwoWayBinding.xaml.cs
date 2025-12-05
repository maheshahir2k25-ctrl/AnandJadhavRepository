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
    /// Interaction logic for TwoWayBinding.xaml
    /// </summary>
    public partial class TwoWayBinding : Window, INotifyPropertyChanged
    {
        private string _echoText;
        public string EchoText {
            get { return _echoText; }
            set { _echoText = value; OnPropertyChanged(); } 
        }
        public TwoWayBinding()
        {
            InitializeComponent();
            this.EchoText = "Hello";
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string value = b.Content.ToString();
        }
    }
}
