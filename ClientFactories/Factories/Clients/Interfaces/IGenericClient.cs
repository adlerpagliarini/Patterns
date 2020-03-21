using ClientFactories.Factories.Clients.Implementation;

namespace ClientFactories.Factories.Clients.Interfaces
{
    public interface IGenericClient<out TClient> : IClientMarkup
        where TClient : class
    {
        ClientProvider ClientProvider { get; }
        TClient GetClient();
    }
}