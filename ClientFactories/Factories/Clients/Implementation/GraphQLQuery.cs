using ClientFactories.Factories.Clients.Interfaces;
using GraphQL.Client;
using System;

namespace ClientFactories.Factories.Clients.Implementation
{
    public class GraphQLQuery : IGenericClient<GraphQLClient>
    {
        public ClientProvider ClientProvider => ClientProvider.GraphQLClient;

        private readonly GraphQLClient _graphQLClient;
        public GraphQLQuery(GraphQLClient graphQLClient)
        {
            _graphQLClient = graphQLClient;
            _graphQLClient.EndPoint = new Uri("https://newurl");
        }

        public GraphQLClient GetClient() => _graphQLClient;
    }
}
