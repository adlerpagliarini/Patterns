using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ClientFactories.Factories.Consumers.Interfaces
{
    public interface IGenericConsumer<T>
    {
        RequestionSource Source { get; }

        Task<JObject> GetInfo(T input);

    }
}
