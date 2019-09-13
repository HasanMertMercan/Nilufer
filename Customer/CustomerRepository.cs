using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;
using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerService
{
    public class CustomerRepository : ICustomerRepository
    {
        private StoreDbContext _dbContext;
        public CustomerRepository(StoreDbContext dbContext)
        {
            //Inject StoreDbContext
            _dbContext = dbContext;
        }

        public async Task Delete(int id)
        {
            try
            {
                var customer = await _dbContext.Customer.SingleAsync(q => q.Id == id);
                _dbContext.Customer.Remove(customer);
                await Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<Customer> GetCustomerById(int id)
        {
            //Use linq queries to find the customer by id
            return _dbContext.Customer.Where(q => q.Id == id).SingleAsync();
        }

        public Task<List<Customer>> GetCustomers()
        {
            return _dbContext.Customer.ToListAsync();
        }

        public Task<Customer> GetCustomerByPhoneNumber(string phoneNumber)
        {
            return _dbContext.Customer.Where(q => q.PhoneNumber == phoneNumber).SingleAsync();
        }

        public Task<Customer> GetCustomerByEmail(string email)
        {
            return _dbContext.Customer.Where(q => q.EmailAddress == email).SingleAsync();
        }

        public async Task Insert(Customer customer)
        {
            _dbContext.Customer.Add(customer);
            await Save();
        }

        public async Task Update(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            await Save();
        }
        private async Task Save()
        {
            //Save the changes
            await _dbContext.SaveChangesAsync();
        }
    }
}
