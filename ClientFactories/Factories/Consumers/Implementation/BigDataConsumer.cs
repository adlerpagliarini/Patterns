using ClientFactories.Factories.Clients.SpecificClients.Interfaces;
using ClientFactories.Factories.Consumers.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientFactories.Factories.Consumers.Implementation
{
    public class BigDataRequest : Request
    {
        public string Input { get; set; }
    }

    public class BigDataResponse
    {
        public JObject Response { get; set; }
    }

    public class BigDataConsumer : IGenericConsumer<BigDataRequest, BigDataResponse>
    {
        private readonly HttpClient _httpClient;
        public BigDataConsumer(IBigDataClient bigDataClient)
        {
            _httpClient = bigDataClient.GetConfiguredClient();
        }

        public async Task<BigDataResponse> GetInfo(BigDataRequest input)
        {
            var response = await _httpClient.GetAsync(input.Input);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var bigDataOutput = new BigDataResponse
            {
                Response = JsonConvert.DeserializeObject<JObject>(data)
            };
            return bigDataOutput;
        }
    }
}
