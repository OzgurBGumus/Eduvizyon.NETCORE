using System.Collections.Generic;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class StateManager : IStateService
    {
        private IStateRepository _stateRepository;
        private ICountryRepository _countryRepository;
        public StateManager(IStateRepository stateRepository,ICountryRepository countryRepository)
        {
            _stateRepository=stateRepository;
            _countryRepository = countryRepository;
        }

        public string ErrorMessage { get; set; }

        public bool Create(State entity)
        {
            if(Validation(entity,false))
            {
                _stateRepository.Create(entity);
                return true;
            }
            return false;
        }

        public bool Delete(State entity)
        {
            if(Validation(entity,true))
            {
                _stateRepository.DeleteWithSubEntities(entity);
                return true;
            }
            return false;
        }

        public List<State> GetAll()
        {
            return _stateRepository.GetAll();
        }

        public State GetById(int id)
        {
            if(id > 0)
            {
                return _stateRepository.GetById(id);
            }
            return null;
            
        }

        public List<State> GetByIds(List<int> ids)
        {
            if(ids != null)
            {
                return _stateRepository.GetByIds(ids);
            }
                return new List<State>();
        }

        public State GetStateDetails(int id)
        {
            if(id > 0)
            {
                return _stateRepository.GetStateDetails(id);
            }
            return null;
        }

        public bool Update(State entity)
        {
            if(Validation(entity,true))
            {
                _stateRepository.Update(entity);
                return true;
            }
            return false;
        }

        public bool Create(State entity, int countryId)
        {
            if(ValidationWithDetails(entity, countryId, false))
            {
                _stateRepository.Create(entity, countryId);
                return true;
            }
            return false;
        }

        public bool Update(State entity, int countryId)
        {
            if(ValidationWithDetails(entity, countryId, true))
            {
                _stateRepository.UpdateDetails(entity, countryId);
                return true;
            }
            return false;
        }

        public bool Validation(State entity, bool IdValidation)
        {
            bool isValid = true;
            if(IdValidation == true)
            {
                if(entity.StateId < 1 || _stateRepository.GetById(entity.StateId)==null)
                {
                    ErrorMessage += "StateId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Name))
            {
                isValid=false;
                ErrorMessage+="State Name is Empty Or Null";
            }
            return isValid;
        }
        public bool ValidationWithDetails(State entity, int countryId, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.StateId == 0 || _stateRepository.GetById(entity.StateId)==null)
                {
                    ErrorMessage += "StateId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage +="Name is Invalid."; isValid= false;
            }
            if((countryId !=0 && _countryRepository.GetById(countryId) == null) || countryId == 0)
            {
                ErrorMessage +="countryId Is Invalid"; isValid= false;
            }
            return isValid;
        }

        public List<State> GetAllWithDetails()
        {
            return _stateRepository.GetAllWithDetails();
        }
    }
}