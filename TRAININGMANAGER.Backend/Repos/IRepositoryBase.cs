using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Responses;
using System.Linq.Expressions;

namespace TRAININGMANAGER.Backend.Repos
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetById(Guid id);
        Task<ControllerResponse> UpdateAsync(T entity);
        Task<ControllerResponse> DeleteAsync(Guid id);
        Task<ControllerResponse> InsertAsync(T entity);        
    }
}
