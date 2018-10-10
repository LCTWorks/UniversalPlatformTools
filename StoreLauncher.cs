using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace LCTWorks.UniversalPlatformTools
{
    /// <summary>
    /// Provides methods to launch the Store App with custom parameters.
    /// </summary>
    public static class StoreLauncher
    {
        #region Const
        private const string STOREURI_PDP_FORMAT = "ms-windows-store:PDP?PFN={0}";
        private const string STOREURI_REVIEW_FORMAT = "ms-windows-store:REVIEW?PFN={0}";
        #endregion

        //APPS PAGES
        /// <summary>
        /// Launches the current App page using the specified launch type.
        /// </summary>
        public static async void LaunchAppPage(AppPageLaunchType launchType)
        {
            await LaunchAppPageAsync(string.Empty, launchType);
        }
        /// <summary>
        /// Launches the specified App page using the specified launch type.
        /// </summary>
        public static async void LaunchAppPage(string packageFamilyName, AppPageLaunchType launchType)
        {
            await LaunchAppPageAsync(packageFamilyName, launchType);
        }

        //Private
        private static async Task LaunchAppPageAsync(string packageFamilyName, AppPageLaunchType launchType)
        {
            if (string.IsNullOrWhiteSpace(packageFamilyName))
            {
                packageFamilyName = Package.Current.Id.FamilyName;
            }
            string format = launchType == AppPageLaunchType.ProductDetailsPage ? STOREURI_PDP_FORMAT : STOREURI_REVIEW_FORMAT;
            string storeURI = string.Format(format, packageFamilyName);
            await LaunchUriAsync(storeURI);
        }
        private static async Task LaunchUriAsync(string uri)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri(uri));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum StorePage
    {
        /// <summary>
        /// The Home page
        /// </summary>
        Home = 0,
        /// <summary>
        /// The Apps page
        /// </summary>
        Apps = 2,
        /// <summary>
        /// The Games page
        /// </summary>
        Games = 4,
        /// <summary>
        /// The Music page
        /// </summary>
        Music = 8,
        /// <summary>
        /// The Video page
        /// </summary>
        Video = 16,
        /// <summary>
        /// The user's Download and Updates page
        /// </summary>
        DownloadsAndUpdates = 32,
        /// <summary>
        /// The Store Settings page
        /// </summary>
        Settings = 64
    }
    /// <summary>
    /// The product types in the Windows Store
    /// </summary>
    public enum StoreProductType
    {
        /// <summary>
        /// Apps
        /// </summary>
        Apps = 2,
        /// <summary>
        /// Games
        /// </summary>
        Games = 4,
        /// <summary>
        /// Music
        /// </summary>
        Music = 8,
        /// <summary>
        /// Videos
        /// </summary>
        Video = 16,
    }
    /// <summary>
    /// 
    /// </summary>
    public enum AppPageLaunchType
    {
        /// <summary>
        /// Specifies the launcher to open the product details page (PDP) for a product
        /// </summary>
        ProductDetailsPage,
        /// <summary>
        /// Specifies the launcher to open the write a review experience for a product.
        /// </summary>
        WriteAReview,
    }
}
