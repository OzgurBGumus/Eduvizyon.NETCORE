using System.Collections.Generic;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private ILanguageRepository _languageRepository;
        public LanguageManager(ILanguageRepository languageRepository)
        {
            _languageRepository=languageRepository;
        }

        public string ErrorMessage { get; set; }

        public bool Create(Language entity)
        {
            if(Validation(entity,false))
            {
                _languageRepository.Create(entity);
                return true;
            }
            return false;
        }

        public bool Delete(Language entity)
        {
            if(Validation(entity,true))
            {
                _languageRepository.DeleteWithSubEntities(entity);
                return true;
            }
            return false;
        }

        public List<Language> GetAll()
        {
            return _languageRepository.GetAll();
        }

        public Language GetById(int id)
        {
            if(id>0)
            {
                return _languageRepository.GetById(id);
            }
            return null;
        }

        public List<Language> GetByIds(List<int> ids)
        {
            if(ids != null)
            {
                return _languageRepository.GetByIds(ids);
            }
                return new List<Language>();
        }

        public Language GetByIdWithDetails(int id)
        {
            if(id > 0)
            {
                return _languageRepository.GetByIdWithDetails(id);
            }
            return null;
        }

        public bool Update(Language entity)
        {
            if(Validation(entity,true))
            {
                _languageRepository.Update(entity);
                return true;
            }
            return false;
        }

        public bool Validation(Language entity, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.LanguageId < 1 || _languageRepository.GetById(entity.LanguageId)==null)
                {
                    ErrorMessage += "LanguageId is Invalid."; isValid= false;
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