namespace ClientFactories.Factories.Clients.Interfaces
{
    public interface IClientFactory
    {
        IGenericClient<dynamic> CreateClient(RequestionSource source);
    }
}
