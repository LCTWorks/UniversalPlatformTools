using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Devices.Input;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.System;
using Windows.System.Profile;
using Windows.UI.ViewManagement;

namespace UniversalPlatformTools
{
    /// <summary>
    /// Provides useful information of the current device.
    /// </summary>
    public static class DeviceHelper
    {
        //Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation
        private const string DeviceFamilyDesktop = "Windows.Desktop";
        private const string DeviceFamilyMobile = "Windows.Mobile";
        private const string DeviceFamilyXBox = "Windows.XBox";
        private const string DeviceFamilyUniversal = "Windows.Universal";
        private const string DeviceFamilyTeam = "Windows.Team";
        private const string DeviceFamilyHolographic = "Windows.Holographic";

        private const double PhoneScreenSize = 7d;

        /// <summary>
        /// Gets the current device family.
        /// </summary>
        public static DeviceFamily Family
        {
            get
            {
                return GetDeviceFamily();
            }
        }
        /// <summary>
        /// Gets the processor architecture of the current device
        /// </summary>
        public static ProcessorArchitecture Architecture
        {
            get
            {
                return Package.Current.Id.Architecture;
            }
        }
        
        /// <summary>
        /// Gets whether the current device is a Phone by checking the hardware buttons and the screen size.
        /// </summary>
        public static bool IsPhone()
        {
            return ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") || (GetScreenSizeInInches() < PhoneScreenSize);
        }
        /// <summary>
        /// Get the size of the current device screen in inches. Get more display information by using <see cref="DisplayInformation"/>.
        /// </summary>
        /// <returns></returns>
        public static double GetScreenSizeInInches()
        {
            var display = DisplayInformation.GetForCurrentView();
            var size = display.DiagonalSizeInInches;
            if (size.HasValue && size.Value > 0)
            {
                return size.Value;
            }
            return 0;
        }
        /// <summary>
        /// Returns whether the current device is Touch Enabled. Get more touch capabilities information by using <see cref="TouchCapabilities"/>.
        /// </summary>
        public static bool IsTouchEnabled()
        {
            TouchCapabilities touch = new TouchCapabilities();
            return touch.TouchPresent > 0;
        }
        /// <summary>
        /// Returns whether a Keyboard is present on the current device. Get more keyboard capabilities information by using <see cref="KeyboardCapabilities"/>.
        /// </summary>
        public static bool IsKeyboardPresent()
        {
            KeyboardCapabilities keyboard = new KeyboardCapabilities();
            return keyboard.KeyboardPresent > 0;
        }
        /// <summary>
        /// Returns whether a Mouse is present on the current device. Get more mouse capabilities information by using <see cref="MouseCapabilities"/>.
        /// </summary>
        public static bool IsMousePresent()
        {
            MouseCapabilities mouse = new MouseCapabilities();
            return mouse.MousePresent > 0;
        }        

        private static DeviceFamily GetDeviceFamily()
        {
            string family = AnalyticsInfo.VersionInfo.DeviceFamily;
            var comparer = StringComparer.OrdinalIgnoreCase;
            switch (family)
            {
                case DeviceFamilyDesktop: return DeviceFamily.Desktop;
                case DeviceFamilyMobile: return DeviceFamily.Mobile;
                case DeviceFamilyXBox: return DeviceFamily.XBox;
                case DeviceFamilyUniversal: return DeviceFamily.Universal;
                case DeviceFamilyTeam: return DeviceFamily.Team;
                case DeviceFamilyHolographic: return DeviceFamily.Holographic;
                default: return DeviceFamily.Unknown;
            }
        }
    }
    /// <summary>
    /// Represents a screen resolution.
    /// </summary>
    public struct ScreenResolution
    {
        /// <summary>
        /// Resolution Width
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// Resolution Height
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// The scale Windows is using.
        /// </summary>
        public int ScalePercent { get; set; }

        /// <summary>
        /// Returns a string displaying Width and Height: WxH.
        /// </summary>
        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }
    /// <summary>
    /// Describes a device family
    /// </summary>
    public enum DeviceFamily
    {
        /// <summary>
        /// Desktop
        /// </summary>
        Desktop,
        /// <summary>
        /// Mobile
        /// </summary>
        Mobile,
        /// <summary>
        /// XBox
        /// </summary>
        XBox,
        /// <summary>
        /// Team (Surface Hub)
        /// </summary>
        Team,
        /// <summary>
        /// Universal (IoT Devices)
        /// </summary>
        Universal,
        /// <summary>
        /// Holographic (Hololens, Mixed reality devices)
        /// </summary>
        Holographic,
        /// <summary>
        /// An unknown Windows device family
        /// </summary>
        Unknown,
    }
}
