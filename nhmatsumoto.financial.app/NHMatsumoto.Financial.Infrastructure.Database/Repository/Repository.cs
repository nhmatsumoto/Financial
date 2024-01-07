using Microsoft.EntityFrameworkCore;
using nhmatsumoto.financial.infrastructure.database.Context;
using nhmatsumoto.financial.infrastructure.database.Interfaces;
using nhmatsumoto.financial.infrastructure.database.Tables;
using System.Linq.Expressions;

namespace nhmatsumoto.financial.infrastructure.database.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public T GetById(int id) =>
            _dbSet.Find(id);

        public IQueryable<T> GetAll() => _dbSet.AsQueryable();

        public IQueryable<T> GetByExpression(Expression<Func<T, bool>> predicate) =>
            _dbSet.Where(predicate);

        public async Task Add(T entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose() => _dbContext.Dispose();
    }
}
