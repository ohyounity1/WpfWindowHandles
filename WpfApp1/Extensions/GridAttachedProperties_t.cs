using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.CodeGenerators;
/////
/*
namespace WpfApp1.Extensions
{
    [DependencyPropertyClass(DependencyPropertyClassType.Static)]
    internal class GridAttachedProperties_t
    {
        [DependencyProperty(DependencyPropertyType.Attached)]
        public int GridMaxRowsProperty;

        private static void OnGridMaxRowsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Grid g)
            {
                try
                {
                    var maxRows = (int)e.NewValue;
                    for (var row = 0; row < maxRows; ++row)
                    {
                        g.RowDefinitions.Add(new RowDefinition());
                    }
                    SetGridAutoRowCount(g, 0);
                }
                catch (Exception)
                {

                }
            }
        }

        private static void OnGridAutoRowPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement fe)
            {
                if (fe.Parent is Grid g)
                {
                    var currentRow = GetGridAutoRowCount(g);
                    Grid.SetRow(fe, currentRow);
                    SetGridAutoRowCount(g, currentRow + 1);
                }
            }
        }

        private static void OnGridMaxColumnsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Grid g)
            {
                try
                {
                    var maxColumns = (int)e.NewValue;
                    for (var row = 0; row < maxColumns; ++row)
                    {
                        g.ColumnDefinitions.Add(new ColumnDefinition());
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
*/