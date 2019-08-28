using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace CustomerService
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> GetCustomerByPhoneNumber(string phoneNumber);
        Task<Customer> GetCustomerByEmail(string email);
        Task Insert(List<Customer> list);
        Task Update(List<Customer> list);
        Task Delete(List<Customer> list);
    }
}
