using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTemplate.Repo.Interface
{
    public interface IGeneralRepo<TEntity> where TEntity : class, new()
    {

        void Delete(TEntity model);

        TEntity Find(params object[] keyValues);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        void Add(TEntity model);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity model);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
