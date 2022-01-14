using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace WPFProjectTemplate.Converters;

public class ListToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is IList list) {
            var result = new StringBuilder();
            foreach (var item in list) {
                result.Append($"{item}, ");
            }
            result.Replace(", ", ".", result.Length - 2, 2);
            return result.ToString();
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
