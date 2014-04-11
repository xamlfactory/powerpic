//-----------------------------------------------------------------------
// <copyright file="SortBySelectonConverter.cs" company="XAML Factory">
//     All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace PicBro.Shell.Windows.Converter
{
    using System.Windows.Data;

    /// <summary>
    /// This converter used to convert from string to boolean
    /// </summary>
    public class SortBySelectonConverter : IMultiValueConverter
    {
        /// <summary>
        /// This method used to convert string to boolean object for SortType Menu Item Radio button selection
        /// </summary>
        /// <param name="values">SortType value</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">default parameter</param>
        /// <param name="culture">default culture</param>
        /// <returns>boolean value</returns>
        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values != null && values.Length > 0)
            {
                if (System.Convert.ToString(values[0]).Equals(System.Convert.ToString(values[1])))
                {
                    return true;   
                }
            }

            return false;
        }

        /// <summary>
        /// This method used to convert back 
        /// </summary>
        /// <param name="value">the value</param>
        /// <param name="targetTypes">target type</param>
        /// <param name="parameter">parameter type</param>
        /// <param name="culture">default culture</param>
        /// <returns>array of object</returns>
        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object[] { };
        }
    }
}
