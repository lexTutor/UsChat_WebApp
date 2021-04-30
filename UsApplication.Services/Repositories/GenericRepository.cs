using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Us.DataAccess;
using UsApplication.Core.Repository;

namespace UsApplication.Implementation.Repositories
{
    public class GenericRepository<TEntity>  : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _ctx;
        private readonly DbSet<TEntity> entities;
        public int TotalNumberOfItems { get; set; }

        public GenericRepository(DataContext ctx)
        {
            _ctx = ctx;
            entities = ctx.Set<TEntity>();
        }
        public async Task<bool> Add(TEntity entity)
        {
            entities.Add(entity);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteById(TEntity entity)
        {
            entities.Remove(entity);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<TEntity> GetById(object id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<bool> Modify(TEntity entity)
        {
            entities.Update(entity);
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
