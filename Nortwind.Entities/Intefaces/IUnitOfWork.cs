using System.Threading.Tasks;

namespace Nortwind.Entities.Intefaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
