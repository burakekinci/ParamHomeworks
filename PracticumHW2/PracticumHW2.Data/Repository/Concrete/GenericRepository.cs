using Microsoft.EntityFrameworkCore;
using PracticumHW2.Data.Context;
using PracticumHW2.Data.Repository.Abstract;

namespace PracticumHW2.Data.Repository.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;
        private DbSet<TEntity> entities;


        public GenericRepository(AppDbContext dbContext)
        {
            this.Context = dbContext;
            this.entities = Context.Set<TEntity>();
        }

        #region Repository Methods
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int entityId)
        {
            return await entities.FindAsync(entityId);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);
        }

        public void DeleteAsync(TEntity entity)
        {
            var column = entity.GetType().GetProperty("IsDeleted");

            if (column is not null)
            {
                entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            }
            else
            {
                entities.Remove(entity);
            }
        }
        #endregion
    }
}
