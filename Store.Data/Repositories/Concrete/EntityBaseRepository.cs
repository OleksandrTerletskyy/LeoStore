using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Store.Data.Repositories.Abstract;
using Store.Entities.Abstract;
using Store.Data.Infrastructure;
using Store.Data.Infrastructure.Abstract;

namespace Store.Data.Repositories.Concrete
{
	public class EntityBaseRepository<TEntity> : IEntityBaseRepository<TEntity>
		where TEntity : class, IEntityBase, new()
	{
		private DbContext _db;

		protected IDbContextFactory DbContextFactory
		{
			get;
			private set;
		}

		protected DbContext DbContext => _db ?? (_db = DbContextFactory.GetDbContext());

		public EntityBaseRepository(IDbContextFactory dbContextFactory)
		{
			DbContextFactory = dbContextFactory;
		}

		public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = DbContext.Set<TEntity>();
			return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}

		public IQueryable<TEntity> All => DbContext.Set<TEntity>();

		public TEntity GetById(int id)
		{
			return All.FirstOrDefault(x => x.Id == id);
		}

		public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
		{
			return DbContext.Set<TEntity>().Where(predicate);
		}

		public void Add(TEntity entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry<TEntity>(entity);
			DbContext.Set<TEntity>().Add(entity);
		}

		public void Delete(TEntity entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry<TEntity>(entity);
			dbEntityEntry.State = EntityState.Deleted;
		}

		public void Edit(TEntity entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry<TEntity>(entity);
			dbEntityEntry.State = EntityState.Modified;
		}
	}
}
