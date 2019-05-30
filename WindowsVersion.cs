using System;
using Windows.System.Profile;

namespace UniversalPlatformTools
{
    /// <summary>
    /// Represents a Windows build, it contains version and commercial information.
    /// </summary>
    public class WindowsVersion
    {
        private static readonly Version VERSION_RTM = new Version(10, 0, 10240, 0);
        private static readonly Version VERSION_NOVEMBER = new Version(10, 0, 10586, 0);
        private static readonly Version VERSION_ANNIVERSARY = new Version(10, 0, 14393, 0);
        private static readonly Version VERSION_CREATORS = new Version(10, 0, 15063, 0);
        private static readonly Version VERSION_FALLCREATORS = new Version(10, 0, 16299, 0);
        private static readonly Version VERSION_APRIL2018 = new Version(10, 0, 17134, 0);
        private static readonly Version VERSION_OCTOBER2018 = new Version(10, 0, 17763, 0);
        private static readonly Version VERSION_MAY2019 = new Version(10, 0, 18362, 0);
        //Add new versions here:
        private static Version[] VERSIONS_SORTED = new[]
        {
            VERSION_RTM,
            VERSION_NOVEMBER,
            VERSION_ANNIVERSARY,
            VERSION_CREATORS,
            VERSION_FALLCREATORS,
            VERSION_APRIL2018,
            VERSION_OCTOBER2018,
            VERSION_MAY2019
        };

        private static WindowsVersion current;
        /// <summary>
        /// Represents the current running version of Windows.
        /// </summary>
        public static WindowsVersion CurrentVersion
        {
            get
            {
                if (current == null)
                {
                    InitializeCurrent();
                }
                return current;
            }
        }

        /// <summary>
        /// The Name of the Windows build.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The actual version of the Windows build.
        /// </summary>
        public Version Build { get; set; }
        /// <summary>
        /// The commercial name given to the version of the Windows build.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// The version of the Universal API Contract. 
        /// This may be helpful to check if some APIs or Controls are present in the running Windows build.
        /// </summary>
        public int ApiContractLevel { get; set; }

        /// <summary>
        /// Returns wether this version is bigger or equal than the known Windows version.
        /// </summary>
        /// <param name="knownVersion">The known Windows version</param>
        public bool IsCompatibleWith(KnownWindowsVersion knownVersion)
        {
            var compatibleVersion = GetKnownVersion(knownVersion);
            return Build >= compatibleVersion.Build;
        }
        /// <summary>
        /// Get version details based on a known Windows version.
        /// </summary>
        /// <param name="version">The known Windows version</param>
        public static WindowsVersion GetKnownVersion(KnownWindowsVersion version)
        {
            switch (version)
            {
                default:
                case KnownWindowsVersion.RTM:
                    {
                        return new WindowsVersion()
                        {
                            Name = "RTM",
                            Build = VERSION_RTM,
                            Version = "1506",
                            ApiContractLevel = 1,
                        };
                    }
                case KnownWindowsVersion.NovemberUpdate:
                    {
                        return new WindowsVersion()
                        {
                            Name = "November Update",
                            Build = VERSION_NOVEMBER,
                            Version = "1511",
                            ApiContractLevel = 2,
                        };
                    }
                case KnownWindowsVersion.AnniversaryUpdate:
                    {
                        return new WindowsVersion()
                        {
                            Name = "Anniversary Update",
                            Build = VERSION_ANNIVERSARY,
                            Version = "1607",
                            ApiContractLevel = 3,
                        };
                    }
                case KnownWindowsVersion.CreatorsUpdate:
                    {
                        return new WindowsVersion()
                        {
                            Name = "Creators Update",
                            Build = VERSION_CREATORS,
                            Version = "1703",
                            ApiContractLevel = 4,
                        };
                    }
                case KnownWindowsVersion.FallCreatosUpdate:
                    {
                        return new WindowsVersion()
                        {
                            Name = "Fall Creators Update",
                            Build = VERSION_CREATORS,
                            Version = "1709",
                            ApiContractLevel = 5,
                        };
                    }
                case KnownWindowsVersion.April2018Update:
                    {
                        return new WindowsVersion()
                        {
                            Name = "April 2018 Update",
                            Build = VERSION_APRIL2018,
                            Version = "1803",
                            ApiContractLevel = 6,
                        };
                    }
                case KnownWindowsVersion.October2018Update:
                    {
                        return new WindowsVersion()
                        {
                            Name = "OCTOBER 2018 Update",
                            Build = VERSION_OCTOBER2018,
                            Version = "1809",
                            ApiContractLevel = 7,
                        };
                    }
                case KnownWindowsVersion.May2019Update:
                    {
                        return new WindowsVersion()
                        {
                            Name = "MAY 2019 Update",
                            Build = VERSION_MAY2019,
                            Version = "1903",
                            ApiContractLevel = 8,
                        };
                    }
            }
        }

        private WindowsVersion()
        {
        }
        private static void InitializeCurrent()
        {
            WindowsVersion baseVersion = GetBaseVersion();
            current = new WindowsVersion
            {
                Name = baseVersion.Name,
                ApiContractLevel = baseVersion.ApiContractLevel,
                Build = GetOSVersion(),
                Version = baseVersion.Version,
            };
        }
        private static Version GetOSVersion()
        {
            string deviceFamilyVersion = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
            ulong version = ulong.Parse(deviceFamilyVersion);
            ulong major = (version & 0xFFFF000000000000L) >> 48;
            ulong minor = (version & 0x0000FFFF00000000L) >> 32;
            ulong build = (version & 0x00000000FFFF0000L) >> 16;
            ulong revision = (version & 0x000000000000FFFFL);
            return new Version((int)major, (int)minor, (int)build, (int)revision);
        }
        private static WindowsVersion GetBaseVersion()
        {
            Version actualBuild = GetOSVersion();
            Version baseVersion = VERSION_RTM;
            int i = 0;
            while (i < VERSIONS_SORTED.Length - 1 && actualBuild >= VERSIONS_SORTED[i+1])
            {
                baseVersion = VERSIONS_SORTED[++i];
            }
            var knownVersion = GetKnownVersion(baseVersion);
            return GetKnownVersion(knownVersion);
        }
        private static KnownWindowsVersion GetKnownVersion(Version version)
        {
            if (version == VERSION_RTM)
                return KnownWindowsVersion.RTM;
            if (version == VERSION_NOVEMBER)
                return KnownWindowsVersion.NovemberUpdate;
            if (version == VERSION_ANNIVERSARY)
                return KnownWindowsVersion.AnniversaryUpdate;
            if (version == VERSION_CREATORS)
                return KnownWindowsVersion.CreatorsUpdate;
            if (version == VERSION_FALLCREATORS)
                return KnownWindowsVersion.FallCreatosUpdate;
            if (version == VERSION_APRIL2018)
                return KnownWindowsVersion.April2018Update;
            return KnownWindowsVersion.October2018Update;
        }
    }
    /// <summary>
    /// Known Windows 10 versions
    /// </summary>
    public enum KnownWindowsVersion
    {
        /// <summary>
        /// Represents the RTM. v10.0 Build 10.0.10240
        /// </summary>
        RTM,
        /// <summary>
        /// Represents the November Update. v10.0 Build 10.0.10586
        /// </summary>
        NovemberUpdate,
        /// <summary>
        /// Represents the Anniversary Update. v10.0 Build 10.0.14393
        /// </summary>
        AnniversaryUpdate,
        /// <summary>
        /// Represents the Creators Update. v10.0 Build 10.0.15063
        /// </summary>
        CreatorsUpdate,
        /// <summary>
        /// Represents the Fall Creators Update. v10.0 Build 16299
        /// </summary>
        FallCreatosUpdate,
        /// <summary>
        /// Represents the April (2018) Creators Update. v10.0 Build 17134
        /// </summary>
        April2018Update,
        /// <summary>
        /// Represents the October (2018) Creators Update. v10.0 Build 17134
        /// </summary>
        October2018Update,
        /// <summary>
        /// Represents the May 2019 Update. v10.0 Build 18362
        /// </summary>
        May2019Update,
    }
}