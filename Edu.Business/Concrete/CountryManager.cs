using System.Collections.Generic;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private ICountryRepository _countryRepository;
        public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository=countryRepository;
        }

        public string ErrorMessage { get; set; }

        public bool Create(Country entity)
        {
            if(Validation(entity, false))
            {
                _countryRepository.Create(entity);
                return true;
            }
            return false;
        }
        public bool Delete(Country entity)
        {
            if(Validation(entity, false))
            {
                _countryRepository.DeleteWithSubEntities(entity);
                return true;
            }
            return false;
        }
        public List<Country> GetAll()
        {
            return _countryRepository.GetAll();
        }

        public Country GetById(int id)
        {
            if(id > 0)
            {
                return _countryRepository.GetById(id);
            }
            return null;
        }

        public List<Country> GetByIds(List<int> ids)
        {
            if(ids != null)
            {
                return _countryRepository.GetByIds(ids);
            }
            return new List<Country>();
        }

        public Country GetByIdWithDetails(int id)
        {
            if(id > 0)
            {
                return _countryRepository.GetByIdWithDetails(id);
            }
            return null;
        }

        public bool Update(Country entity)
        {
            if(Validation(entity,true))
            {
                _countryRepository.Update(entity);
                return true;
            }   
            return false;
        }

        public bool Validation(Country entity, bool IdValidation)
        {
            
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.CountryId < 1 || _countryRepository.GetById(entity.CountryId)==null)
                {
                    ErrorMessage += "CountryId is Invalid."; isValid= false;
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