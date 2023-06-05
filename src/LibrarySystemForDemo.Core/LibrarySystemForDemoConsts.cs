using LibrarySystemForDemo.Debugging;

namespace LibrarySystemForDemo
{
    public class LibrarySystemForDemoConsts
    {
        public const string LocalizationSourceName = "LibrarySystemForDemo";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "879481a9300c443baa6cc3c7540a65da";
    }
}
