using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UniversalPlatformTools
{
    public static class ValueHelper
    {
        public static Visibility BooleanToVisibility(bool value)
        {
            return value ? Visibility.Visible : Visibility.Collapsed;
        }
        public static bool VisibilityToBoolean(Visibility value)
        {
            return value == Visibility.Visible;
        }

    }
}
