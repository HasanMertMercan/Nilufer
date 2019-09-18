using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace SupplierService
{
    public class SupplierRepository : ISupplierRepository
    {
        private StoreDbContext _dbContext;
        public SupplierRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(int id)
        {
            var supplier = await _dbContext.Supplier.SingleAsync(q => q.Id == id);
            if(supplier != null)
            {
                _dbContext.Supplier.Remove(supplier);
            }
            await Save();
        }

        public Task<List<Supplier>> GetAllSuppliers()
        {
            return _dbContext.Supplier.ToListAsync();
        }

        public Task<Supplier> GetSupplierByEmail(string email)
        {
            return _dbContext.Supplier.Where(q => q.EmailAddress == email).SingleAsync();
        }

        public Task<Supplier> GetSupplierById(int id)
        {
            return _dbContext.Supplier.Where(q => q.Id == id).SingleAsync();
        }

        public Task<Supplier> GetSupplierByPhoneNumber(string phoneNumber)
        {
            return _dbContext.Supplier.Where(q => q.PhoneNumber == phoneNumber).SingleAsync();
        }

        public Task<Supplier> GetSupplierByStoreName(string storeName)
        {
            return _dbContext.Supplier.Where(q => q.StoreName == storeName).SingleAsync();
        }

        public Task<List<Supplier>> GetSuppliersByTotalBalance(decimal totalBalance)
        {
            return _dbContext.Supplier.Where(q => q.TotalBalance == totalBalance).ToListAsync();
        }

        public async Task Insert(Supplier supplier)
        {
            _dbContext.Supplier.Add(supplier);
            await Save();
        }

        public async Task Update(Supplier supplier)
        {
            _dbContext.Entry(supplier).State = EntityState.Modified;
            await Save();
        }

        private async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
