using ClientFactories.Factories.Clients.Implementation;
using ClientFactories.Factories.Clients.Interfaces;
using ClientFactories.Factories.Clients.SpecificClients;
using ClientFactories.Factories.Clients.SpecificClients.Interfaces;
using ClientFactories.Factories.Consumers.Implementation;
using ClientFactories.Factories.Consumers.Interfaces;
using GraphQL.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace ClientFactories.Factories
{
    public static class IoC
    {
        public static void ClientFactories(this IServiceCollection services)
        {
            // Generic Clients
            services.AddScoped<IClientFactory, ClientFactory>();

            services.AddScoped<IGenericClient<HttpClient>, Http>();
            services.AddScoped<IClientMarkup, Http>();
            services.AddTransient(_ => new HttpClient());

            services.AddScoped<IGenericClient<GraphQLClient>, GraphQLQuery>();
            services.AddScoped<IClientMarkup, GraphQLQuery>();
            services.AddTransient(_ => new GraphQLClient("https://localhost"));

            // Specific Clients
            services.AddTransient<IBigDataClient, BigDataClient>();

            // Consumers
            services.AddScoped<IConsumerHandler, ConsumerHandler>();
            services.RegisterInterfaceImplementations(typeof(IGenericConsumer<,>)); // The same as: services.AddScoped<IGenericConsumer<BigDataRequest, BigDataOuput>, BigDataConsumer>();
        }

        private static void RegisterInterfaceImplementations(this IServiceCollection services, Type interfaceType)
        {
            Assembly assembly = interfaceType.Assembly;

            foreach (var _type in assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract))
            {
                foreach (var i in _type.GetInterfaces())
                {
                    if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGenericConsumer<,>))
                    {
                        var _interfaceType = interfaceType.MakeGenericType(i.GetGenericArguments());
                        services.AddScoped(_interfaceType, _type);
                    }
                }
            }
        }
    }
}
