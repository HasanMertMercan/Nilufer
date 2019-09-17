using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace DealerService
{
    public class DealerRepository : IDealerRepository
    {
        private StoreDbContext _dbContext;

        public DealerRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(int id)
        {
            try
            {
                var dealer = await _dbContext.Dealer.SingleAsync(q => q.Id == id);
                _dbContext.Dealer.Remove(dealer);
                await Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Dealer> GetDealerByEmailAddress(string email)
        {
            return _dbContext.Dealer.Where(q => q.EmailAddress == email).SingleAsync();
        }

        public Task<Dealer> GetDealerById(int id)
        {
            return _dbContext.Dealer.Where(q => q.Id == id).SingleAsync();
        }

        public Task<Dealer> GetDealerByPhoneNumber(string phoneNumber)
        {
            return _dbContext.Dealer.Where(q => q.PhoneNumber == phoneNumber).SingleAsync();
        }

        public Task<Dealer> GetDealerByStoreName(string storeName)
        {
            return _dbContext.Dealer.Where(q => q.StoreName == storeName).SingleAsync();
        }

        public Task<Dealer> GetDealerByTotalBalance(decimal totalBalance)
        {
            return _dbContext.Dealer.Where(q => q.TotalBalance == totalBalance).SingleAsync();
        }

        public Task<List<Dealer>> GetDealers()
        {
            return _dbContext.Dealer.ToListAsync();
        }

        public async Task Insert(Dealer dealer)
        {
            _dbContext.Dealer.Add(dealer);
            await Save();
        }

        public async Task Update(Dealer dealer)
        {
            _dbContext.Entry(dealer).State = EntityState.Modified;
            await Save();
        }
        private async Task Save()
        {
            //Save the changes
            await _dbContext.SaveChangesAsync();
        }
    }
}
