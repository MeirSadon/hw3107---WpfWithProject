using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace hw3107___ValueConverter_Tickets___Exrice3_
{
    public class RemainingTicketsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value as string == "")
                return "--";

            int vacancy = (int)value;
            if (vacancy == 0)
                return "FULL";
            if (vacancy < 30)
                return "Almost Full";

            return "Vacancy!";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
