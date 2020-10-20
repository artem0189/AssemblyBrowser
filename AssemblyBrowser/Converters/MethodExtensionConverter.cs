using System;
using System.Reflection;
using System.Globalization;
using System.Windows.Data;
using System.Runtime.CompilerServices;

namespace AssemblyBrowser.Converters
{
    public class MethodExtensionConverter : IValueConverter
    {
        public object Convert(object value, Type targeType, object parameter, CultureInfo culture)
        {
            MethodInfo method = value as MethodInfo;
            return method.IsDefined(typeof(ExtensionAttribute));
        }

        public object ConvertBack(object value, Type targeType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
