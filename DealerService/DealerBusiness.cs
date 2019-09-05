using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace DealerService
{
    public class DealerBusiness : IDealerBusiness
    {
        private IDealerRepository _repository;
        private ILogger<DealerBusiness> _logger;

        public DealerBusiness(IDealerRepository repository,
            ILogger<DealerBusiness> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public Task Delete(Dealer dealer)
        {
            try
            {
                _repository.Delete(dealer);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Dealer> GetDealerByEmailAddress(string email)
        {
            try
            {
                return _repository.GetDealerByEmailAddress(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Dealer> GetDealerById(int id)
        {
            try
            {
                return _repository.GetDealerById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Dealer> GetDealerByPhoneNumber(string phoneNumber)
        {
            try
            {
                return _repository.GetDealerByPhoneNumber(phoneNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Dealer> GetDealerByStoreName(string storeName)
        {
            try
            {
                return _repository.GetDealerByStoreName(storeName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Dealer> GetDealerByTotalBalance(decimal totalBalance)
        {
            try
            {
                return _repository.GetDealerByTotalBalance(totalBalance);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<Dealer>> GetDealers()
        {
            try
            {
                return _repository.GetDealers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Insert(Dealer dealer)
        {
            try
            {
                _repository.Insert(dealer);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Update(Dealer dealer)
        {
            try
            {
                _repository.Update(dealer);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
