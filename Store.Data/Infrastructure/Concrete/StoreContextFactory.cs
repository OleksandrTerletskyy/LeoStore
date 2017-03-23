using System.Data.Entity;
using Store.Data.DatabaseContext;
using Store.Data.Infrastructure.Abstract;

namespace Store.Data.Infrastructure.Concrete
{
	public class StoreContextFactory : Disposable, IDbContextFactory
	{
		private DbContext _db;

		public DbContext GetDbContext()
		{
			return _db ?? (_db = new StoreContext());
		}

		protected override void DisposeCore()
		{
			_db?.Dispose();
		}
	}
}
