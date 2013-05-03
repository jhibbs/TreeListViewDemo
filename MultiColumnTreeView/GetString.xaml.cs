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
using System.Windows.Shapes;

namespace MultiColumnTreeView
{
    /// <summary>
    /// Interaction logic for GetString.xaml
    /// </summary>
    public partial class GetString : Window
    {
        public static bool  getString(string label, string defaultValue, ref string newValue)
        {
            GetString gs = new GetString();
            gs.la.Content = label;
            gs.tb.Text = defaultValue;

            bool ret = false;

            if (gs.ShowDialog().Value)
            {
                newValue = gs.tb.Text;
                ret = true;
            }
            else
            {
                newValue = "";
            }

            return ret;
        }

        public GetString()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
