namespace Edu.Business.Abstract
{
    public interface IValidation<T>
    {
        string ErrorMessage{get; set;}
        bool Validation(T entity, bool IdValidation);
    }
}