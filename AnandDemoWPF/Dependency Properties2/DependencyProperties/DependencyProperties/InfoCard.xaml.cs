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

namespace DependencyProperties
{
    /// <summary>
    /// Interaction logic for InfoCard.xaml
    /// </summary>
    public partial class InfoCard : UserControl
    {
        public InfoCard()
        {
            InitializeComponent();
        }

        public string Lable
        {
            get { return (string)GetValue(LableProperty); }
            set { SetValue(LableProperty, value); }
        }

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ButtonClickProperty); }
            set { SetValue(ButtonClickProperty, value); }
        }


        // Using a DependencyProperty as the backing store for LableProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LableProperty =
            DependencyProperty.Register(nameof(Lable), typeof(string), typeof(InfoCard), new PropertyMetadata("My Label"));


        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(InfoCard), new PropertyMetadata("My Value"));


        // Using a DependencyProperty as the backing store for ButtonClick.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonClickProperty =
            DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(InfoCard), new PropertyMetadata(null));

    }
}
