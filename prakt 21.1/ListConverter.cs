using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace prakt_21._1
{
    public class ListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string content = string.Empty;
            var collection = value as POxuy;
            foreach (var item in collection.BindList)
            {
                content += item.ProductCatalog.Name + " " + item.Count + " "; 
            }
            return content;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
