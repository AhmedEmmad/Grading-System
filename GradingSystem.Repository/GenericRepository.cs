using GradingSystem.Core.Entities;
using GradingSystem.Core.Repositories.Contact;
using GradingSystem.Repository.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GradingSystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly GradingSystemDbContext _dbContext;

        // To Implement These Methods, Use Constructor To Inject An Object From DbContext
        public GenericRepository(GradingSystemDbContext dbContext) // Ask CLR For Creating An Object From DbContext Implicitly
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if(typeof(T) == typeof(Admin))
                return (IEnumerable<T>) await _dbContext.Set<Admin>().Include(A => A.DrInstructions).ToListAsync();
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            if (typeof(T) == typeof(Admin))
                return await _dbContext.Set<Admin>().Where(A => A.Id == id).Include(A => A.DrInstructions).FirstOrDefaultAsync() as T;
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
