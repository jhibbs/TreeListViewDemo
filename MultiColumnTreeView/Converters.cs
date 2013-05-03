using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.Globalization;
using System.Diagnostics;

namespace MultiColumnTreeView
{
    public class LevelToIndentConverter : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            int lvl = 0;
            if (value is BallastSpace)
            {
                BallastSpace curBS = (BallastSpace)value;
                while (curBS.Parent != null)
                {
                    // curBS = curBS.Parent;
                    lvl++;
                }
            }
            return new Thickness(lvl * indentSize, 0, 0, 0);
        }

        public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private const double indentSize = 18;
    }

    public class ValConverter : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {

            if (value is string)
            {
                return (string)value;
            }
            else
                return "This";
        }

        public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }

    /// <summary>
    /// This converter does nothing except breaking the
    /// debugger into the convert method
    /// </summary>
    public class DatabindingDebugConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            // Debugger.Break();
            return value;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {

            Debugger.Break();
            return value;
        }
    }

    public class SelectedColorConverter : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {

            Brush ret = Brushes.LightBlue;

            if (value is bool)
            {
                ret = ((bool)value ? Brushes.LightGreen : Brushes.Orange);
            }

            return ret.ToString();
        }

        public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }

}
