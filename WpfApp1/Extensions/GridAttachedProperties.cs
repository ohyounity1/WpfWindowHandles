


using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Extensions
{
	internal static class GridAttachedProperties
	{
		//////////////////////////////////////////////////////////////////////////////
		/*These methods are generated with the T4 template, please DO NOT MODIFY!!! */
		//////////////////////////////////////////////////////////////////////////////
		private static DependencyProperty RegisterAttached<T>(string propertyName, PropertyChangedCallback cb) =>
			DependencyProperty.RegisterAttached(propertyName.Replace("Property", string.Empty), typeof(T), typeof(GridAttachedProperties), new PropertyMetadata(default(T), cb));
		private static DependencyProperty RegisterAttached<T>(string propertyName) =>
			DependencyProperty.RegisterAttached(propertyName.Replace("Property", string.Empty), typeof(T), typeof(GridAttachedProperties));
		public static readonly DependencyProperty GridMaxRowsProperty = 
			RegisterAttached<int>(nameof(GridMaxRowsProperty), OnGridMaxRowsPropertyChanged);
		public static int GetGridMaxRows(DependencyObject obj) =>
			(int)obj.GetValue(GridMaxRowsProperty);
		public static void SetGridMaxRows(DependencyObject obj, int gridMaxRows) =>
			obj.SetValue(GridMaxRowsProperty, gridMaxRows);
		public static readonly DependencyProperty GridAutoRowCountProperty = 
			RegisterAttached<int>(nameof(GridAutoRowCountProperty));
		public static int GetGridAutoRowCount(DependencyObject obj) =>
			(int)obj.GetValue(GridAutoRowCountProperty);
		public static void SetGridAutoRowCount(DependencyObject obj, int gridAutoRowCount) =>
			obj.SetValue(GridAutoRowCountProperty, gridAutoRowCount);
		public static readonly DependencyProperty GridAutoRowProperty = 
			RegisterAttached<bool>(nameof(GridAutoRowProperty), OnGridAutoRowPropertyChanged);
		public static bool GetGridAutoRow(DependencyObject obj) =>
			(bool)obj.GetValue(GridAutoRowProperty);
		public static void SetGridAutoRow(DependencyObject obj, bool gridAutoRow) =>
			obj.SetValue(GridAutoRowProperty, gridAutoRow);
		public static readonly DependencyProperty GridMaxColumnsProperty = 
			RegisterAttached<int>(nameof(GridMaxColumnsProperty), OnGridMaxColumnsPropertyChanged);
		public static int GetGridMaxColumns(DependencyObject obj) =>
			(int)obj.GetValue(GridMaxColumnsProperty);
		public static void SetGridMaxColumns(DependencyObject obj, int gridMaxColumns) =>
			obj.SetValue(GridMaxColumnsProperty, gridMaxColumns);
		public static readonly DependencyProperty GridAutoColumnCountProperty = 
			RegisterAttached<int>(nameof(GridAutoColumnCountProperty));
		public static int GetGridAutoColumnCount(DependencyObject obj) =>
			(int)obj.GetValue(GridAutoColumnCountProperty);
		public static void SetGridAutoColumnCount(DependencyObject obj, int gridAutoColumnCount) =>
			obj.SetValue(GridAutoColumnCountProperty, gridAutoColumnCount);
		public static readonly DependencyProperty GridAutoColumnProperty = 
			RegisterAttached<bool>(nameof(GridAutoColumnProperty), OnGridAutoColumnPropertyChanged);
		public static bool GetGridAutoColumn(DependencyObject obj) =>
			(bool)obj.GetValue(GridAutoColumnProperty);
		public static void SetGridAutoColumn(DependencyObject obj, bool gridAutoColumn) =>
			obj.SetValue(GridAutoColumnProperty, gridAutoColumn);
		private static void OnGridMaxRowsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		    if (d is Grid g)
		    {
		        var t = typeof(int);
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
		
		private static void OnGridAutoColumnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		    if (d is FrameworkElement fe)
		    {
		        if (fe.Parent is Grid g)
		        {
		            var currentColumn = GetGridAutoColumnCount(g);
		            Grid.SetColumn(fe, currentColumn);
		            SetGridAutoColumnCount(g, currentColumn + 1);
		        }
		    }
		}
	}
}