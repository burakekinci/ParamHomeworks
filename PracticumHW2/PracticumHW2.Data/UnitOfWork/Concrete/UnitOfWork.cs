using PracticumHW2.Data.Context;
using PracticumHW2.Data.Model;
using PracticumHW2.Data.Repository.Abstract;
using PracticumHW2.Data.Repository.Concrete;

namespace PracticumHW2.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public bool disposed;

        public IGenericRepository<Customer> CustomerRepository { get; private set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            this._dbContext = dbContext;

            CustomerRepository = new GenericRepository<Customer>(this._dbContext);
        }

        //TODO
        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging                    
                    dbContextTransaction.Rollback();
                }
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
