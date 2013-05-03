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
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Ship ship = new Ship();

        public Window1()
        {
            InitializeComponent();

            ship.AddSpace(new Space("Region 1", "M 10,18  10,50 50,50 50,10 10,18"));
            ship.AddSpace(new Space("Region 2", "M 10,50  14,85 54,85 50,50 10,50"));
            ship.AddSpace(new Space("Region 3", "M 14,85  16,104 55,104 54,85 14,85"));
            ship.AddSpace(new Space("Region 4", "M 16,104  18,124 57,124 55,104 16,104"));
            ship.AddSpace(new Space("Region 5", "M 18,124  25,143 62,143 57,124 18,124"));
            ship.AddSpace(new Space("Region 6", "M 25,143  34,168 72,168 62,143 25,143"));
            ship.AddSpace(new Space("Region 7", "M 34,168 C 52,198 52,198 72,198 M 72,198 72,198 72,168 34,168"));
            ship.AddSpace(new Space("Region 8", "M 72,168  72,198 85,199 85,168 72,168"));

            ship.AddSpace(new Space("Region 9", "M 85,168  85,198 103,199 103,168 85,168"));
            ship.AddSpace(new Space("Region 10", "M 103,168  103,199 123,200 123,168 85,168"));

            ship.AddSpace(new Space("Region 11", "M 123,168  123,200 143,202 143,168 123,168"));

            ship.AddSpace(new Space("Region 12", "M 143,168  143,202 168,204 168,170 143,168"));

            ic.ItemsSource = ship.Spaces;

            /*
            BallastSpace th = new BallastSpace("Thing 1", 0, 0);
            th.AddChild(new BallastSpace("", 10, 12));
            th.AddChild(new BallastSpace("", 13, 14));

            things.Add(th);
            th = new BallastSpace("Thing 2", 0, 0);
            th.AddChild(new BallastSpace("", 14, 17));
            th.AddChild(new BallastSpace("", 17, 33));
            things.Add(th);

            th = new BallastSpace("Thing 3", 0, 0);
            th.AddChild(new BallastSpace("", 33, 38));
            th.AddChild(new BallastSpace("", 38,43));
            th.AddChild(new BallastSpace("", 43, 47));
            th.AddChild(new BallastSpace("", 47, 52));
            things.Add(th);
            */

            lv.ItemsSource = ship.BallastSpaces;

        }

        private void ic_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void ic_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (lv.SelectedItem != null)
                {
                    if (((System.Windows.FrameworkElement)sender).DataContext is Space)
                    {

                        Space sp = (Space)((System.Windows.FrameworkElement)sender).DataContext;
                        BallastSpace tt = null;
                        if (lv.SelectedValue is BallastSpace)
                            tt = (BallastSpace)lv.SelectedValue;
                        else if (lv.SelectedValue is SpaceChild)
                            tt = ((SpaceChild)lv.SelectedValue).Parent;
                        else
                            return;

                        sp.IsSelected = !sp.IsSelected;

                        tt.AddChild(new SpaceChild(tt, sp));
                    }
                }
                else
                {
                    MessageBox.Show("You have not selected a space");
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newName = "";

            if (GetString.getString("Space name", "New Space", ref newName))
            {
                ship.AddBallastSpace(new BallastSpace(newName));
                //things.Add(new BallastSpace(newName, 0, 0, null));
            }

            /*
            string ret = "";
            foreach (space s in (System.Collections.ObjectModel.ObservableCollection<space>)ic.ItemsSource)
            {
                ret += s.Name + "    " + s.IsSelected + "\n";
            }

            MessageBox.Show(ret);
             */
        }

    }

}
