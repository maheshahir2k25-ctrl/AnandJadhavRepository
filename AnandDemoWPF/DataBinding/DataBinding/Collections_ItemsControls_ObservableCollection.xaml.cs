using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for Collections_ItemsControls.xaml
    /// </summary>
    public partial class Collections_ItemsControls : Window
    {
       public ObservableCollection<string> TodoItems { get; set; } = new ObservableCollection<string>();
        public Collections_ItemsControls()
        {
            InitializeComponent();
            TodoItems.Add("Learn C#");
            TodoItems.Add("Learn Design Patterns");
            this.DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(InputBox.Text))
            {
                TodoItems.Add(InputBox.Text);
                InputBox.Clear();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TodoItems.Count > 0)
                TodoItems.RemoveAt(0);
        }
    }
}
