using System;
using System.Data.Entity;

namespace Store.Data.Infrastructure.Abstract
{
	public interface IDbContextFactory : IDisposable
	{
		DbContext GetDbContext();
	}
}
