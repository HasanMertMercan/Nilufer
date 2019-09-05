using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValueTypes.Entity;

namespace ExpenditureService
{
    public class ExpenditureBusiness : IExpenditureBusiness
    {
        private IExpenditureRepository _repository;
        private ILogger<ExpenditureBusiness> _logger;
        public ExpenditureBusiness(ExpenditureRepository repository, ILogger<ExpenditureBusiness> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public Task Delete(Expenditure expenditure)
        {
            try
            {
                _repository.Delete(expenditure);
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<Expenditure>> GetAllExpendetures()
        {
            try
            {
                return _repository.GetAllExpendetures();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Expenditure> GetExpenditureById(int id)
        {
            try
            {
                return _repository.GetExpenditureById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<Expenditure> GetExpenditureByOutgoingOrderId(int outgoingOrderId)
        {
            try
            {
                return _repository.GetExpenditureByOutgoingOrderId(outgoingOrderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<Expenditure>> GetExpendituresByCreatedDate(DateTime date)
        {
            try
            {
                return _repository.GetExpendituresByCreatedDate(date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task<List<Expenditure>> GetExpendituresByTotalAmount(decimal totalAmount)
        {
            try
            {
                return _repository.GetExpendituresByTotalAmount(totalAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Insert(Expenditure expenditure)
        {
            try
            {
                _repository.Insert(expenditure);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Task Update(Expenditure expenditure)
        {
            try
            {
                _repository.Update(expenditure);
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
