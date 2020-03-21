using ClientFactories.Factories.Consumers.Implementation;
using System.Threading.Tasks;

namespace ClientFactories.Factories.Consumers.Interfaces
{
    public interface IConsumerHandler
    {
        Task<TResponse> ExecuteRequest<TRequest, TResponse>(TRequest request) where TRequest : Request;
    }
}
