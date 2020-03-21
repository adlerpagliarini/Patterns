using ClientFactories.Factories.Consumers.Implementation;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ClientFactories.Factories.Consumers.Interfaces
{
    public interface IConsumerHandler
    {
        Task<JObject> ExecuteRequest<T>(T request) where T : Request;
    }
}
