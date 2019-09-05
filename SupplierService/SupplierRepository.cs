﻿using Database;
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
        public async Task Delete(Supplier supplier)
        {
            _dbContext.SupplierList.Remove(supplier);
            await Save();
        }

        public Task<List<Supplier>> GetAllSuppliers()
        {
            return _dbContext.SupplierList.ToListAsync();
        }

        public Task<Supplier> GetSupplierByEmail(string email)
        {
            return _dbContext.SupplierList.Where(q => q.EmailAddress == email).SingleAsync();
        }

        public Task<Supplier> GetSupplierById(int id)
        {
            return _dbContext.SupplierList.Where(q => q.Id == id).SingleAsync();
        }

        public Task<Supplier> GetSupplierByPhoneNumber(string phoneNumber)
        {
            return _dbContext.SupplierList.Where(q => q.PhoneNumber == phoneNumber).SingleAsync();
        }

        public Task<Supplier> GetSupplierByStoreName(string storeName)
        {
            return _dbContext.SupplierList.Where(q => q.StoreName == storeName).SingleAsync();
        }

        public Task<List<Supplier>> GetSuppliersByTotalBalance(decimal totalBalance)
        {
            return _dbContext.SupplierList.Where(q => q.TotalBalance == totalBalance).ToListAsync();
        }

        public async Task Insert(Supplier supplier)
        {
            _dbContext.SupplierList.Add(supplier);
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
