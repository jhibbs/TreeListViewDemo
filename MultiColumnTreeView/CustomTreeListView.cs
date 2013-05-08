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
using Microsoft.Windows.Controls;

namespace MultiColumnTreeView
{
    public class CustomTreeListView : TreeView
    {
        public GridViewColumnCollection Columns
        {
            get
            {
                if (columns == null)
                {
                    columns = new GridViewColumnCollection();
                }

                return columns;
            }
        }

        private GridViewColumnCollection columns;

    }

}
