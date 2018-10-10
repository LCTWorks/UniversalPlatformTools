using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;

namespace UniversalPlatformTools
{
    /// <summary>
    /// Provides some useful information about the current system.
    /// </summary>
    public static class SystemHelper
    {   
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
    }
}
