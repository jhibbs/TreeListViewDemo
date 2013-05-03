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
    public class CustomTreeListView : TreeView
    {
        public System.Windows.Controls.GridViewColumnCollection Columns
        {
            get
            {

                if (columns == null)
                {
                    columns = new System.Windows.Controls.GridViewColumnCollection();
                }

                return columns;
            }
        }

        private System.Windows.Controls.GridViewColumnCollection columns;

    }

}
