using System.Linq.Expressions;

namespace MeowTasksBackend.DAL.Repositories.Contract
{
  public interface IGenericRepository<T> where T : class
  {
    T? Get(Expression<Func<T, bool>> filter);
    Task<T> Create(T model);
    Task<bool> Update(T model);
    Task<bool> Delete(T model);
    IQueryable<T> Query(Expression<Func<T,  bool>> filter);
  }
}
