using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Repo.Interface;

namespace WebAppTemplate.Repo
{
    public class GeneralRepo<TEntity> : IGeneralRepo<TEntity> where TEntity : class, new()
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly DbSet<TEntity> _dbSet;

        public GeneralRepo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = unitOfWork.DataBaseContext.Set<TEntity>();
        }

        public void Add(TEntity model)
        {
            _dbSet.Add(model);
        }

        public void Update(TEntity model)
        {
            var entry = _unitOfWork.DataBaseContext.Entry(model);
            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity model)
        {
            _dbSet.Remove(model);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
