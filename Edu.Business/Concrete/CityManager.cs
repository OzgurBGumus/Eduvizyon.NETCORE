using System.Collections.Generic;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class CityManager : ICityService
    {
        
        private ICityRepository _cityRepository;
        private ICountryRepository _countryRepository;
        private IStateRepository _stateRepository;
        public CityManager(ICityRepository cityRepository, ICountryRepository countryRepository, IStateRepository stateRepository)
        {
            _cityRepository=cityRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
        }

        public string ErrorMessage { get; set; }

        public bool Create(City entity)
        {
            if(Validation(entity, false))
            {
                _cityRepository.Create(entity);
                return true;
            }   
            return false;
        }

        public bool Create(City entity, int countryId, int stateId)
        {
            if(ValidationWithDetails(entity, countryId, stateId, false))
            {
                _cityRepository.Create(entity, countryId, stateId);
                return true;
            }
            return false;
            
        }

        public bool Delete(City entity)
        {
            if(Validation(entity, true))
            {
                _cityRepository.DeleteWithSubEntities(entity);
                return true;
            }
            return false;
        }

        public List<City> GetAll()
        {
            return _cityRepository.GetAll();
        }

        public List<City> GetAllWithDetails()
        {
            return _cityRepository.GetAllWithDetails();
        }

        public City GetById(int id)
        {
            if(id > 0)
            {
                return _cityRepository.GetById(id);
            }
            return null;
        }

        public List<City> GetByIds(List<int> ids)
        {
            if(ids != null)
            {
                return _cityRepository.GetByIds(ids);
            }
            return new List<City>();
        }

        public City GetCityDetails(int id)
        {
            if(id > 0)
            {
                return _cityRepository.GetCityDetails(id);
            }
            return null;
        }

        public bool Update(City entity)
        {
            if(Validation(entity, true))
            {
                _cityRepository.Update(entity);
                return true;
            }
            return false;
        }

        public bool Update(City entity, int countryId, int stateId)
        {
            if(ValidationWithDetails(entity, countryId, stateId, true))
            {
                _cityRepository.Update(entity, countryId, stateId);
                return true;
            }
            return false;
        }

        public bool Validation(City entity, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.CityId < 1 || _cityRepository.GetById(entity.CityId)==null)
                {
                    ErrorMessage += "CityId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage +="Name is Invalid."; isValid= false;
            }
            return isValid;
        }
        public bool ValidationWithDetails(City entity, int countryId, int stateId, bool IdValidation)
        {
            bool isValid = true;
            if(IdValidation == true)
            {
                if(entity.CityId < 1 || _cityRepository.GetById(entity.CityId)==null)
                {
                    ErrorMessage += "CityId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage +="Name Is Invalid"; isValid= false;
            }
            if(countryId < 1 || _countryRepository.GetById(countryId) == null)
            {
                ErrorMessage +="countryId Is Invalid"; isValid= false;
            }
            if(stateId !=0 && _stateRepository.GetById(stateId) == null)
            {
                ErrorMessage +="stateId Is Invalid"; isValid= false;
            }
            
            return isValid;
        }
    }
}