using ClientFactories.Factories.Clients;
using ClientFactories.Factories.Clients.Implementation;
using ClientFactories.Factories.Clients.Interfaces;
using ClientFactories.Factories.Consumers.Implementation;
using ClientFactories.Factories.Consumers.Interfaces;
using GraphQL.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ClientFactories.Factories
{
    public static class IoC
    {
        public static void ClientFactories(this IServiceCollection services, IConfiguration configuration)
        {
            //Assembly assembly = typeof(IGenericClient<>).Assembly;

            //foreach (var type in assembly.GetTypes()
            //    .Where(t => t.IsClass && !t.IsAbstract))
            //{
            //    foreach (var i in type.GetInterfaces())
            //    {
            //        if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGenericClient<>))
            //        {
            //            // NOTE: Due to a limitation of Microsoft.DependencyInjection we cannot
            //            // register an open generic interface type without also having an open generic
            //            // implementation type.So, we convert to a closed generic interface
            //            // type to register.
            //            var interfaceType = typeof(IGenericClient<>).MakeGenericType(i.GetGenericArguments());
            //            services.AddScoped(interfaceType, type);
            //            services.AddScoped(typeof(IClientMarkup), type);
            //        }IClientMarkup
            //    }
            //}

            services.AddScoped<IClientFactory, ClientFactory>();

            services.AddScoped<IGenericClient<HttpClient>, Http>();
            services.AddScoped<IClientMarkup, Http>();
            services.AddTransient(_ => new HttpClient());

            services.AddScoped<IGenericClient<GraphQLClient>, GraphQLQuery>();
            services.AddScoped<IClientMarkup, GraphQLQuery>();
            services.AddTransient(_ => new GraphQLClient("https://localhost"));

            services.AddScoped<IConsumerHandler, ConsumerHandler>();
            services.AddScoped<IGenericConsumer<BigDataRequest>, BigDataConsumer>();

        }
    }
}
