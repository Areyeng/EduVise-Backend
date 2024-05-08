using EduVise.Debugging;

namespace EduVise
{
    public class EduViseConsts
    {
        public const string LocalizationSourceName = "EduVise";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "3022c713956646999ce0fb6dd0f43fa9";
    }
}
