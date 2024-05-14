using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MeowTasksBackend.DAL.DBContext;
using MeowTasksBackend.DAL.Repositories.Contract;

namespace MeowTasksBackend.DAL.Repositories
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly MeowtasksdbContext _mwtdbContext;

    public GenericRepository(MeowtasksdbContext mwtdbContext)
    {
      _mwtdbContext = mwtdbContext;
    }

    public async Task<T> Create(T model)
    {
      try
      {
        _mwtdbContext.Set<T>().Add(model);
        await _mwtdbContext.SaveChangesAsync();

        return model;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> Delete(T model)
    {
      try
      {
        _mwtdbContext.Set<T>().Remove(model);
        await _mwtdbContext.SaveChangesAsync();

        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public T? Get(Expression<Func<T, bool>> filter)
    {
      try
      {
        return _mwtdbContext.Set<T>().Where(filter).SingleOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> filter)
    {
      try
      {
        var query = filter == null ? _mwtdbContext.Set<T>() : _mwtdbContext.Set<T>().Where(filter);

        return query;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> Update(T model)
    {
      try
      {
        _mwtdbContext.Set<T>().Update(model);
        await _mwtdbContext.SaveChangesAsync();

        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
