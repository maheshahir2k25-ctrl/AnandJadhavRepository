using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Resources_Styles.Converters
{
    // 1. Implement the Interface
    public class BoolToColorConverter : IValueConverter
    {
        // 2. Convert: Data (ViewModel) -> UI (View)
        // value: The data coming IN (the bool)
        // targetType: What the UI is expecting (Brush)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // A. Safely cast the input value
            if (value is bool isOnline)
            {
                // B. Return the appropriate UI value
                if (isOnline)
                    return Brushes.SeaGreen; // True
                else
                    return Brushes.Crimson;  // False
            }
            if (value is string BackgroundColor)
            {
                // B. Return the appropriate UI value
                if (BackgroundColor == "Green")
                    return Brushes.SeaGreen; // True
                else if (BackgroundColor == "Red")
                    return Brushes.Crimson;  // False
                else if (BackgroundColor == "Show")
                    return Visibility.Visible;
                else if (BackgroundColor == "Hide")
                    return Visibility.Hidden;
            }
            

            // Fallback if binding fails
            return Brushes.Gray;
        }

        // 3. ConvertBack: UI -> Data
        // We rarely use this (mostly for TwoWay inputs). 
        // For OneWay bindings, we can just throw an exception or return Binding.DoNothing.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
