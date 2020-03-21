using ClientFactories.Factories.Clients.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientFactories.Factories.Clients.Implementation
{
    public enum ClientProvider
    {
        HttpClient,
        GraphQLClient
    }

    public class ClientFactory : IClientFactory
    {
        private readonly IEnumerable<IClientMarkup> _clients;
        private readonly ClientSettings _settings;

        public ClientFactory(IEnumerable<IClientMarkup> clients, IOptions<ClientSettings> options)
        {
            _clients = clients;
            _settings = options.Value;
        }

        public IGenericClient<dynamic> CreateClient(RequestionSource source)
        {
            var client = source switch
            {
                RequestionSource.BigData => _clients.SingleOrDefault(e => (e as IGenericClient<dynamic>).ClientProvider == ClientProvider.HttpClient),
                RequestionSource.Lake => _clients.SingleOrDefault(e => (e as IGenericClient<dynamic>).ClientProvider == ClientProvider.GraphQLClient),
                _ => throw new ArgumentOutOfRangeException("Type not supported")
            };
            return client as IGenericClient<dynamic>;
        }
    }
}
