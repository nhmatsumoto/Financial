using nhmatsumoto.financial.api.Context.Tables;
using System.Linq.Expressions;

namespace nhmatsumoto.financial.api.Context.Interfaces
{
    public interface IRepository<T> : IDisposable where T : EntityBase
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetByExpression(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
