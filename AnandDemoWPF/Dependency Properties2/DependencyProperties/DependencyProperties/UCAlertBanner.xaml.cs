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
    /// Interaction logic for UCAlertBanner.xaml
    /// </summary>
    public partial class UCAlertBanner : UserControl
    {
        public UCAlertBanner()
        {
            InitializeComponent();
        }

        public string AlertMessage
        {
            get { return (string)GetValue(AlertMessageProperty); }
            set { SetValue(AlertMessageProperty, value); }
        }
        // --- DP 1: The Message String ---
        public static readonly DependencyProperty AlertMessageProperty =
            DependencyProperty.Register(
                "AlertMessage",
                typeof(string),
                typeof(UCAlertBanner),
                new PropertyMetadata("Default Message"));



        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }
        // --- DP 2: The Close Command ---
        // This allows the "X" button inside the control to trigger logic outside.
        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register(
                "CloseCommand",
                typeof(ICommand),
                typeof(UCAlertBanner),
                new PropertyMetadata(null));


    }
}
