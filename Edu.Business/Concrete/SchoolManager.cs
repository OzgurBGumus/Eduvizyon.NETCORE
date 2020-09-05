using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.data.Concrete.EfCore;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class SchoolManager : ISchoolService
    {
        private ISchoolRepository _schoolRepository;
        public SchoolManager(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public string ErrorMessage { get; set; }

        public bool Create(School entity)
        {
            if(Validation(entity,false))
            {
                _schoolRepository.Create(entity);
                return true;
            }
            return false;
        }

        public bool CreateFull(School entity)
        {
            if(Validation(entity,false))
            {
                _schoolRepository.Create(entity);
                return true;
            }
            return false;
        }

        public bool Delete(School entity)
        {
            if(Validation(entity,true))
            {
                _schoolRepository.DeleteWithSubEntities(entity);
                return true;
            }
            return false;
        }

        // public void DeleteAllSchoolDetails(School model)
        // {
        //     _schoolRepository.DeleteAllSchoolDetails(model);
        // }

        public List<School> GetAll()
        {
            return _schoolRepository.GetAll();
        }

        public School GetById(int id)
        {
            if(id > 0)
            {
                return _schoolRepository.GetById(id);
            }
            return null;
        }

        public List<School> GetByIds(List<int> ids)
        {
            if(ids != null)
            {
                return _schoolRepository.GetByIds(ids);
            }
                return new List<School>();
        }

        public School GetSchoolDetails(int id)
        {
            if(id > 0)
            {
                return _schoolRepository.getSchoolDetails(id);
            }
            return null;
        }

        public bool Update(School entity)
        {
            if(Validation(entity,true))
            {
                _schoolRepository.Update(entity);
                return true;
            }
            return false;
        }

        public bool Validation(School entity, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.SchoolId < 1 || _schoolRepository.GetById(entity.SchoolId)==null)
                {
                    ErrorMessage += "SchoolId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage +="Name is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Url))
            {
                ErrorMessage +="Url is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Description))
            {
                ErrorMessage +="Description is Invalid."; isValid= false;
            }
            return isValid;
        }
    }
}