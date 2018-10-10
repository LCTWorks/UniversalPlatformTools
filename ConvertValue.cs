using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UniversalPlatformTools
{
    public static class ConvertValue
    {
        public static Visibility ToVisibility(bool value)
        {
            return value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
