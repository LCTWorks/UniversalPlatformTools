using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace UniversalPlatformTools
{
    /// <summary>
    /// Provides some useful information about the current system.
    /// </summary>
    public static class SystemHelper
    {
        private static readonly string[] _fontFamilies = new string[] { "Arial", "Calibri", "Cambria", "Comic Sans MS", "Courier New", "Ebrima", "Gadugi", "Georgia", "Leelawadee UI", "Lucida Console", "Malgun Gothic", "Microsoft JhengHei", "Microsoft Yahei", "Nirmala UI", "Segoe Print", "Segoe UI", "SimSun", "Times New Roman", "Trebuchet MS", "Verdana", "Yu Gothic" };

        /// <summary>
        /// Returns whether the system is in Tablet Mode.
        /// </summary>
        public static bool IsInTabletMode
        {
            get
            {
                 return UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Touch;
            }
        }

        /// <summary>
        /// Gets the resolution of the current screen. Get more display information by using <see cref="DisplayInformation"/>.
        /// </summary>
        public static ScreenResolution GetScreenResolution()
        {
            var display = DisplayInformation.GetForCurrentView();
            var width = display.ScreenWidthInRawPixels;
            var height = display.ScreenHeightInRawPixels;
            var scale = (int)display.ResolutionScale;
            return new ScreenResolution
            {
                Width = width,
                Height = height,
                ScalePercent = scale
            };
        }
        /// <summary>
        /// Gets info about the running Windows 10 Build.
        /// </summary>
        /// <returns></returns>
        public static WindowsVersion GetOSVersion()
        {
            return WindowsVersion.CurrentVersion;
        }
        
        /// <summary>
        /// Returns the user specific System Accent Color.
        /// </summary>
        public static Color GetSystemAccentColor()
        {
            return GetSystemColor(UIColorType.Accent);
        }
        /// <summary>
        /// Returns the color value of the specific color type in the system.
        /// </summary>
        public static Color GetSystemColor(UIColorType colorType)
        {
            UISettings settings = new UISettings();
            return settings.GetColorValue(colorType);
        }

        /// <summary>
        /// Returns a collection of font families guaranteed across all Windows 10 versions and devices.
        /// </summary>
        public static ICollection<string> GetStandardFontFamilies()
        {
            return _fontFamilies.ToArray();
        }

    }
}
