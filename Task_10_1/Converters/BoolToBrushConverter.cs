using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Task_10.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        public Brush SuccessBrush { get; set; } = Brushes.LightGreen;
        public Brush FailBrush { get; set; } = Brushes.IndianRed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
                return b ? SuccessBrush : FailBrush;

            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
