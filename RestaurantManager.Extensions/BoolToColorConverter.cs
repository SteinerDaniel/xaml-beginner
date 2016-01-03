using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {

        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //return (bool)value ? Colors.Red : Colors.Transparent;
            return (bool)value ? TrueColor : FalseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool returnValue = default(bool);

            if (value is Color)
            {
                if ((Color)value == FalseColor)
                    returnValue = false;
                else if ((Color)value == TrueColor)
                    returnValue = true;
            }
            return returnValue;
        }
    }
}
