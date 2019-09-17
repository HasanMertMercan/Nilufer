using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace DealerService
{
    public interface IDealerRepository
    {
        Task<List<Dealer>> GetDealers();
        Task<Dealer> GetDealerById(int id);
        Task<Dealer> GetDealerByStoreName(string storeName);
        Task<Dealer> GetDealerByPhoneNumber(string phoneNumber);
        Task<Dealer> GetDealerByEmailAddress(string email);
        Task<Dealer> GetDealerByTotalBalance(decimal totalBalance);
        Task Insert(Dealer dealer);
        Task Update(Dealer dealer);
        Task Delete(int id);
    }
}
