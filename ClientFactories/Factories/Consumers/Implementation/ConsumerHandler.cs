using ClientFactories.Factories.Consumers.Interfaces;
using Newtonsoft.Json.Linq;
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

        public async Task<JObject> ExecuteRequest<T>(T request) where T : Request
        {
            return await RequestData(request);
        }

        private async Task<JObject> RequestData<T>(T request) where T : Request
        {
            var obj = _serviceProvider.GetService(typeof(IGenericConsumer<T>));

            return await ((IGenericConsumer<T>)obj).GetInfo(request);
        }
    }
}
