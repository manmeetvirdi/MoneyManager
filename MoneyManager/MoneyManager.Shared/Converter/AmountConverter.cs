﻿using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace MoneyManager.Converter {
    public class AmountConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            string numberString = value.ToString().Replace(".", ",");

            return System.Convert.ToDouble(numberString, new CultureInfo("de-CH").NumberFormat).ToString("F2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return value;
        }
    }
}