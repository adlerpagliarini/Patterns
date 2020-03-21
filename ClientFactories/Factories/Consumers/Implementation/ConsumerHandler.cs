using ClientFactories.Factories.Consumers.Interfaces;
using System;
using System.Threading.Tasks;

namespace ClientFactories.Factories.Consumers.Implementation
{
    public class ConsumerHandler : IConsumerHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public ConsumerHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> ExecuteRequest<TRequest, TResponse>(TRequest request) where TRequest : Request
        {
            var obj = _serviceProvider.GetService(typeof(IGenericConsumer<TRequest, TResponse>));
            var consumer = obj as IGenericConsumer<TRequest, TResponse>;
            return await consumer.GetInfo(request);
        }
    }
}
