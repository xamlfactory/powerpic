namespace PicBro.Shell.Windows.Converter
{
    using System.Globalization;
    using System.Windows.Data;
    public class SizeToFileSizeConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CultureInfo cultureValue = CultureInfo.CurrentUICulture;
            int size = System.Convert.ToInt32(value);
            const string format = "#,0.0";

            if (size < 1024)
            {
                return size.ToString("#,0", cultureValue);
            }

            size /= 1024;
            if (size < 1024)
            {
                return size.ToString(format, cultureValue) + " KB";
            }

            size /= 1024;
            if (size < 1024)
            {
                return size.ToString(format, cultureValue) + " MB";
            }

            size /= 1024;
            if (size < 1024)
            {
                return size.ToString(format, cultureValue) + " GB";
            }

            size /= 1024;
            return size.ToString(format, cultureValue) + " TB";
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
