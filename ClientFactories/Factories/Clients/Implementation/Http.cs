using ClientFactories.Factories.Clients.Interfaces;
using System.Net.Http;

namespace ClientFactories.Factories.Clients.Implementation
{
    public class Http : IGenericClient<HttpClient>
    {
        public ClientProvider ClientProvider => ClientProvider.HttpClient;

        private readonly HttpClient _httpClient;

        public Http(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpClient GetClient() => _httpClient;
    }
}
