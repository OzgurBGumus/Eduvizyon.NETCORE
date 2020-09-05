using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreLanguageRepository : EfCoreGenericRepository<Language, CourseContext>, ILanguageRepository
    {
        public List<Language> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<Language> languages = context.Language.Where(i=>i.IsDeleted==false).ToList();
                List<Language> SelectedLanguages = new List<Language>();
                foreach (var language in languages)
                {
                    if(ids.Any(i=>i==language.LanguageId))
                    {
                        SelectedLanguages.Add(language);
                    }  
                }
                return SelectedLanguages;
            }
        }
        public bool DeleteWithSubEntities(Language entity)
        {
            EfCoreCourseRepository courseRepository = new EfCoreCourseRepository();
            using( var context = new CourseContext())
            {
                Language language = context.Language.Where(i=>i.LanguageId == entity.LanguageId)
                                    .Include(i=>i.CourseLanguages)
                                        .ThenInclude(i=>i.Course).FirstOrDefault();
                foreach (var courseId in language.CourseLanguages.Select(i=>i.Course.CourseId))
                {
                    Course course = courseRepository.GetById(courseId);
                    courseRepository.Delete(course);
                }
                Delete(entity);
                return true;
            }
        }

        public Language GetByIdWithDetails(int id)
        {
            using(var context = new CourseContext())
            {
                return context.Language
                                .Where(i=>i.LanguageId==id && i.IsDeleted==false)
                                .Include(i=>i.CourseLanguages)
                                    .ThenInclude(i=>i.Course)
                                .FirstOrDefault();
            }
        }
        public List<Language> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<Language>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public Language GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity = context.Set<Language>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(Language entity)
        {
            if(entity != null)
            {
                entity.IsDeleted=true;
                return Update(entity);
            }
            return false;
        }
    }
}