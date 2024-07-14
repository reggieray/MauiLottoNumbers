﻿using System.Globalization;

namespace LottoNumbers.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !((bool)value);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
