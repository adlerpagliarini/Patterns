using ClientFactories.Factories.Clients;
using ClientFactories.Factories.Clients.Interfaces;
using ClientFactories.Factories.Consumers.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientFactories.Factories.Consumers.Implementation
{
    public class BigDataConsumer : IGenericConsumer<BigDataRequest>
    {
        public RequestionSource Source => RequestionSource.BigData;
        private readonly HttpClient _httpClient;
        private readonly BigData _settings;
        public BigDataConsumer(IClientFactory clientFactory, IOptions<ClientSettings> options)
        {
            _httpClient = clientFactory.CreateClient(Source).GetClient();
            _settings = options.Value.BigData;
        }

        public async Task<JObject> GetInfo(BigDataRequest input)
        {
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
            var response = await _httpClient.GetAsync(input.Input);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<JObject>(data);
        }
    }
}
