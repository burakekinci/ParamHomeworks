using PracticumHW2.Data.Model;
using PracticumHW2.Data.Repository.Abstract;

namespace PracticumHW2.Data.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Customer> CustomerRepository { get; }

        Task CompleteAsync();
    }
}
