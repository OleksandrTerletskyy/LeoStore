using System;
using System.Data.Entity;

namespace Store.Data.Infrastructure
{
	public interface IDbContextFactory : IDisposable
	{
		DbContext GetDbContext();
	}
}
