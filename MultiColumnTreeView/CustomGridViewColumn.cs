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
    public class CustomGridViewColumn : GridViewColumn
    {
        public CustomGridViewColumn()
            : base()
        {
        }

        public static readonly DependencyProperty BindingNameProperty = DependencyProperty.Register("BindingName", typeof(Binding), typeof(CustomGridViewColumn), new PropertyMetadata(new PropertyChangedCallback(OnBindingChanged)));

        public Binding BindingName
        {
            get
            {
                return (Binding)GetValue(BindingNameProperty);
            }
            set
            {
                SetValue(BindingNameProperty, value);
            }
        }

        private static int curIndex = 0;
        private static void OnBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != "")
            {
                try
                {
                    string bName = e.NewValue.ToString();
                    string bDir = "";
                    if (e.NewValue.ToString().Contains(";"))
                    {
                        string[] sp = bName.Split(';');
                        bName = sp[0];
                        bDir = sp[1];
                    }

                    DataTemplate dt = new DataTemplate();
                    FrameworkElementFactory fef = null;
                    if (bDir != "oneway")
                    {
                        fef = new FrameworkElementFactory(typeof(TextBox));
                        fef.AddHandler(TextBox.GotFocusEvent, new RoutedEventHandler(tb_GetFocus));
                        fef.AddHandler(TextBox.LostFocusEvent, new RoutedEventHandler(tb_LostFocus));
                        fef.AddHandler(TextBox.KeyDownEvent, new KeyEventHandler(tb_KeyDown));
                        fef.SetValue(TextBox.TabIndexProperty, curIndex++);
                    }
                    else
                    {
                        fef = new FrameworkElementFactory(typeof(TextBlock));
                    }
                    Binding b = new Binding(e.NewValue.ToString());
                    fef.SetBinding(TextBox.TextProperty, b);
                    fef.SetValue(TextBox.BackgroundProperty, Brushes.Transparent);
                    fef.SetValue(TextBox.BorderBrushProperty, Brushes.Transparent);

                    dt.VisualTree = fef;
                    ((CustomGridViewColumn)d).CellTemplate = dt;
                }
                catch (Exception ex)
                {

                }
            }

        }

        public static void tb_GetFocus(Object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.Background = Brushes.Green;
            tb.Foreground = Brushes.White;
        }

        public static void tb_LostFocus(Object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Background = Brushes.Transparent;
            tb.Foreground = Brushes.Black;
        }

        public static void tb_KeyDown(Object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
        }

    }

}
