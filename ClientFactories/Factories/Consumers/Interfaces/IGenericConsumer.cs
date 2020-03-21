using System.Threading.Tasks;

namespace ClientFactories.Factories.Consumers.Interfaces
{
    public interface IGenericConsumer<TInput, TOuput>
    {
        Task<TOuput> GetInfo(TInput input);
    }
}
