using System;
using System.Linq;
using System.Linq.Expressions;
using Store.Entities.Abstract;

namespace Store.Data.Repositories.Abstract
{
	public interface IEntityBaseRepository<TEntity>
		where TEntity : class, IEntityBase, new()
	{
		IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
		IQueryable<TEntity> All { get; }
		TEntity GetById(int id);
		IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
		void Add(TEntity entity);
		void Delete(TEntity entity);
		void Edit(TEntity entity);
	}
}
