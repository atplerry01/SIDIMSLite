using System.Threading.Tasks;

namespace SIDIMSClient.Api.Persistence.Repository.Common
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}