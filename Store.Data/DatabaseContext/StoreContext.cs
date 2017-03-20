using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Store.Data.Configurations;
using Store.Entities.Concrete;

namespace Store.Data.DatabaseContext
{
	public class StoreContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Tag> Tags { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Configurations.Add(new OrderConfiguration());
			modelBuilder.Configurations.Add(new ProductConfiguration());
			modelBuilder.Configurations.Add(new TagConfiguration());
		}
	}
}
