namespace FrontEnd_Tests.Base
{
    public class TestSettings
    {
        private static readonly Settings settings;
        static TestSettings()
        {
            settings ??= new Settings();
        }

        //Google
        public static string baseGoogleURL => settings.GetConfig().Google.baseURL.ToString();
        public static string exempleURL => settings.GetConfig().Google.exempleUrl.ToString();

    }
}
