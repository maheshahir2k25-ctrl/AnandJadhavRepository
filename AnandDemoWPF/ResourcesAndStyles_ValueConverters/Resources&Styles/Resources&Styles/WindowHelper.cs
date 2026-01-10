using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Resources_Styles
{
    public static class WindowHelper
    {
        // 1. Register an Attached Dependency Property
        public static readonly DependencyProperty StartupLocationProperty =
            DependencyProperty.RegisterAttached(
                "StartupLocation",
                typeof(WindowStartupLocation),
                typeof(WindowHelper),
                new PropertyMetadata(WindowStartupLocation.Manual, OnStartupLocationChanged));

        // Standard Get/Set accessors
        public static WindowStartupLocation GetStartupLocation(DependencyObject obj)
        {
            return (WindowStartupLocation)obj.GetValue(StartupLocationProperty);
        }

        public static void SetStartupLocation(DependencyObject obj, WindowStartupLocation value)
        {
            obj.SetValue(StartupLocationProperty, value);
        }

        // 2. The logic: When the property changes in the Style, update the real Window property
        private static void OnStartupLocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                window.WindowStartupLocation = (WindowStartupLocation)e.NewValue;
            }
        }
    }
}
