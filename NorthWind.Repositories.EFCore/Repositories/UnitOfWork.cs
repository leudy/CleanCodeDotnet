using Nortwind.Entities.Intefaces;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthWindContext context;

        public UnitOfWork(NorthWindContext context)
        {
            this.context = context;
        }
        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync(); 
        }
    }
}
