using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace ExpenditureService
{
    public interface IExpenditureRepository
    {
        Task<List<Expenditure>> GetAllExpendetures();
        Task<Expenditure> GetExpenditureById(int id);
        Task<List<Expenditure>> GetExpendituresByCreatedDate(DateTime date);
        Task<Expenditure> GetExpenditureByOutgoingOrderId(int outgoingOrderId);
        Task<List<Expenditure>> GetExpendituresByTotalAmount(decimal totalAmount);
        Task Insert(Expenditure expenditure);
        Task Update(Expenditure expenditure);
        Task Delete(Expenditure expenditure);
    }
}
