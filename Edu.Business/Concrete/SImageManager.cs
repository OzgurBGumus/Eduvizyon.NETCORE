using System.Collections.Generic;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class SImageManager : ISImageService
    {
        private ISImageRepository _sImageRepository;
        public SImageManager(ISImageRepository sImageRepository)
        {
            _sImageRepository=sImageRepository;
        }
        public string ErrorMessage { get; set; }

        public bool Create(SImage entity)
        {
            if(Validation(entity,false))
            {
                _sImageRepository.Create(entity);
                return true;
            }
            return false;
        }

        public bool Delete(SImage entity)
        {
            if(Validation(entity,true))
            {
                _sImageRepository.Delete(entity);
                return true;
            }
                return false;
        }

        public List<SImage> GetAll()
        {
            return _sImageRepository.GetAll();
        }

        public SImage GetById(int id)
        {
            if(id>0)
            {
                return _sImageRepository.GetById(id);
            }
            return null;
        }

        public List<SImage> GetByIds(List<int> ids)
        {
            if(ids != null)
            {
                return _sImageRepository.GetByIds(ids);
            }
            else{
                return new List<SImage>();
            }
            
        }

        public bool Update(SImage entity)
        {
            if(Validation(entity,true))
            {
                _sImageRepository.Update(entity);    
                return true;            
            }
            return false;

        }

        public bool Create(int schoolId, string name)
        {
            if(schoolId!= 0)
            {
                if(!string.IsNullOrEmpty(name))
                {
                    _sImageRepository.Create(schoolId, name);
                    return true;
                }
            }
            return false;
        }

        public bool Validation(SImage entity, bool IdValidation)
        {
            bool isValid = true;
            if(IdValidation == true)
            {
                if(entity.SImageId == 0 || _sImageRepository.GetById(entity.SImageId)==null)
                {
                    ErrorMessage += "SImageId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Url))
            {
                ErrorMessage += "Image Url Is Empty \n";
                isValid = false;
            }
            return isValid;
        }

        public SImage GetByIdWithDetails(int id)
        {
            return _sImageRepository.GetByIdWithDetails(id);
        }
    }
}