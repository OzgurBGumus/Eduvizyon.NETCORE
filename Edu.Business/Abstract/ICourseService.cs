using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface ICourseService:IValidation<Course>
    {
         Course GetById(int id);
         List<Course> GetAll();
         bool Create(Course entity);
         bool Update(Course entity);
         bool Delete(Course entity);
         Course GetCourseDetails(int id);
         bool Create(Course model, int LanguageId, int TimeId, int BranchId);
         bool Update(Course entity, int LanguageId, int TimeId);
         //void DeleteAllCourseDetails(Course model);
         List<Course> GetByIds (List<int> ids);
         bool ValidationWithDetails(Course entity, int LanguageId, int TimeId, bool IdValidation);
         bool ValidationWithDetails(Course entity, int LanguageId, int TimeId, int BranchId, bool IdValidation);

    }
}