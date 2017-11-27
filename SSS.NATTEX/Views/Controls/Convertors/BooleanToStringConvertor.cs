using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Views.Controls.Convertors
{
    public class BooleanToStringConvertor
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = "No";
            if (value == null)
            {
                result = "No";
            }
            else if ((value != null) && (value is bool))
            {
                bool temp = (bool)value;
                if (temp == false)
                {
                    result = "No";
                }
                else
                {
                    result = "Yes";
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = false;
            if (value == null)
            {
                result = false;
            }
            else if ((value != null) && (value is string))
            {
                string temp = value.ToString();
                if (temp == "No")
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
