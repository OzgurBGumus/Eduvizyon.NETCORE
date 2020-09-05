using System.Collections.Generic;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class TimeManager : ITimeService
    {
        private ITimeRepository _timeRepository;
        public TimeManager(ITimeRepository timeRepository)
        {
            _timeRepository=timeRepository;
        }

        public string ErrorMessage { get; set; }

        public bool Create(Time entity)
        {
            if(Validation(entity, false))
            {
                _timeRepository.Create(entity);
                return true;
            }
            return false;
        }

        public bool Delete(Time entity)
        {
            if(Validation(entity,false))
            {
                _timeRepository.DeleteWithSubEntities(entity);
                return true;
            }
            return false;
        }

        public List<Time> GetAll()
        {
            return _timeRepository.GetAll();
        }

        public Time GetById(int id)
        {
            if(id > 0)
            {
                return _timeRepository.GetById(id);
            }
            return null;
        }

        public List<Time> GetByIds(List<int> ids)
        {
            if(ids != null)
            {
                return _timeRepository.GetByIds(ids);
            }
                return new List<Time>();
        }

        public Time GetByIdWithDetails(int id)
        {
            if(id > 0)
            {
                return _timeRepository.GetByIdWithDetails(id);
            }
            return null;
        }

        public bool Update(Time entity)
        {
            if(Validation(entity, true))
            {
                _timeRepository.Update(entity);
                return true;
            }
            return false;
            
        }

        public bool Validation(Time entity, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.TimeId < 1 || _timeRepository.GetById(entity.TimeId)==null)
                {
                    ErrorMessage += "TimeId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage +="Name is Invalid."; isValid= false;
            }
            return isValid;
        }
    }
}