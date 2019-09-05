using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace ExpenditureService
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private StoreDbContext _dbContext;
        public ExpenditureRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(Expenditure expenditure)
        {
            _dbContext.ExpenditureList.Remove(expenditure);
            await Save();
        }

        public Task<List<Expenditure>> GetAllExpendetures()
        {
            return _dbContext.ExpenditureList.ToListAsync();
        }

        public Task<Expenditure> GetExpenditureById(int id)
        {
            return _dbContext.ExpenditureList.Where(q => q.Id == id).SingleAsync();
        }

        public Task<Expenditure> GetExpenditureByOutgoingOrderId(int outgoingOrderId)
        {
            return _dbContext.ExpenditureList.Where(q => q.OutgoingOrderId == outgoingOrderId).SingleAsync();
        }

        public Task<List<Expenditure>> GetExpendituresByCreatedDate(DateTime date)
        {
            return _dbContext.ExpenditureList.Where(q => q.CreatedDate == date).ToListAsync();
        }

        public Task<List<Expenditure>> GetExpendituresByTotalAmount(decimal totalAmount)
        {
            return _dbContext.ExpenditureList.Where(q => q.TotalAmount == totalAmount).ToListAsync();
        }

        public async Task Insert(Expenditure expenditure)
        {
            _dbContext.ExpenditureList.Add(expenditure);
            await Save();
        }

        public async Task Update(Expenditure expenditure)
        {
            _dbContext.Entry(expenditure).State = EntityState.Modified;
            await Save();
        }

        private async Task Save()
        {
            //Save the changes
            await _dbContext.SaveChangesAsync();
        }
    }
}
