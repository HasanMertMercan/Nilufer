using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace SupplierService
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSupplierById(int id);
        Task<Supplier> GetSupplierByStoreName(string storeName);
        Task<Supplier> GetSupplierByPhoneNumber(string phoneNumber);
        Task<Supplier> GetSupplierByEmail(string email);
        Task<List<Supplier>> GetSuppliersByTotalBalance(decimal totalBalance);
        Task Insert(Supplier supplier);
        Task Delete(Supplier supplier);
        Task Update(Supplier supplier);
    }
}
