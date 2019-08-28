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

        public async Task Delete(List<Customer> list)
        {
            _dbContext.CustomerList.RemoveRange(list);
            await Save();
        }

        public Task<Customer> GetCustomerById(int id)
        {
            //Use linq queries to find the customer by id
            return _dbContext.CustomerList.Where(q => q.Id == id).SingleAsync();
        }

        public Task<List<Customer>> GetCustomers()
        {
            return _dbContext.CustomerList.ToListAsync();
        }

        public Task<Customer> GetCustomerByPhoneNumber(string phoneNumber)
        {
            return _dbContext.CustomerList.Where(q => q.PhoneNumber == phoneNumber).SingleAsync();
        }

        public Task<Customer> GetCustomerByEmail(string email)
        {
            return _dbContext.CustomerList.Where(q => q.EmailAddress == email).SingleAsync();
        }

        public async Task Insert(List<Customer> list)
        {
            _dbContext.CustomerList.AddRange(list);
            await Save();
        }

        public async Task Update(List<Customer> list)
        {
            foreach (var customer in list)
            {
                _dbContext.Entry(customer).State = EntityState.Modified;
            }
            await Save();
        }
        private async Task Save()
        {
            //Save the changes
            await _dbContext.SaveChangesAsync();
        }
    }
}
