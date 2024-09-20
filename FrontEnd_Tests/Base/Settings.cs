namespace FrontEnd_Tests.Base
{
    public class Settings
    {
        private readonly dynamic config;
        public Settings()
        {
            config ??= Newtonsoft.Json.Linq.JObject.Parse(File.ReadAllText($"{System.AppDomain.CurrentDomain.BaseDirectory}/../../../appSettings.json"));
        }
        public dynamic GetConfig()
        {
            return config;
        }
    }
}
