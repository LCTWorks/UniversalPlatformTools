using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UniversalPlatformTools
{
    /// <summary>
    /// Convert from base data types to UI data types and vice versa
    /// </summary>
    public class UIConvert
    {
        /// <summary>
        /// Converts the specified boolean value to a <see cref="Visibility"/> value.
        /// </summary>
        /// <param name="value">The valuue to convert from</param>
        /// <returns><see cref="Visibility.Visible"/> if parameter is True, otherwise returns <see cref="Visibility.Collapsed"/></returns>
        public Visibility ToVisibility(bool value)
        {
            return (value) ? Visibility.Visible : Visibility.Collapsed;
        }
        /// <summary>
        /// Converts the specified <see cref="Visibility"/> value to a boolean value.
        /// </summary>
        /// <param name="visibility">Tge value to convert from</param>
        /// <returns>True if parameter is <see cref="Visibility.Visible"/> otherwise, False.</returns>
        public bool ToBoolean(Visibility visibility)
        {
            return (visibility == Visibility.Visible);
        }
    }
}
