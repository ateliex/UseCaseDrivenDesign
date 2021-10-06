using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ateliex
{
    public class ConvertItemToIndex : IValueConverter
    {
        #region IValueConverter Members
        //Convert the Item to an Index
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                DataGridRow row = value as DataGridRow;
                if (row == null)
                    throw new InvalidOperationException($"This converter class can only be used with DataGridRow elements. {value}");

                return row.GetIndex() + 1;

                //CollectionView cv = (CollectionView)dg.Items;
                ////Get the CollectionView from the DataGrid that is using the converter
                //DataGrid dg = (DataGrid)Application.Current.MainWindow.FindName("planosComerciaisDataGrid");
                ////Get the index of the item from the CollectionView
                //int rowindex = cv.IndexOf(value) + 1;

                //return rowindex.ToString();
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        //One way binding, so ConvertBack is not implemented
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
