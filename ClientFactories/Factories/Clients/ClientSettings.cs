namespace ClientFactories.Factories.Clients
{
    public class ClientSettings
    {
        public BigData BigData { get; set; }
        public Lake Lake { get; set; }
    }

    public class BigData : Settings
    {
        public string BaseUrl { get; set; }
    }

    public class Lake : Settings
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
    }

    public class Settings
    {

    }
}
