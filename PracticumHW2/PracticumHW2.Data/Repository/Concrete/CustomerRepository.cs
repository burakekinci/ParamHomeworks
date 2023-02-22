using Microsoft.EntityFrameworkCore;
using PracticumHW2.Data.Context;
using PracticumHW2.Data.Model;

namespace PracticumHW2.Data.Repository.Concrete
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<Customer> GetByIdAsync(int entityId)
        {
            return await base.GetByIdAsync(entityId);
        }

        public async Task<int> TotalRecordsAsync()
        {
            return await Context.Customers.CountAsync();
        }
    }
}
