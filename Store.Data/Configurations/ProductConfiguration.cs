using Store.Entities.Concrete;

namespace Store.Data.Configurations
{
	public class ProductConfiguration : EntityBaseConfiguration<Product>
	{
		public ProductConfiguration()
		{
			Property(p => p.Name).IsRequired().HasMaxLength(100);
			Property(p => p.Description).IsRequired();
			Property(p => p.Price).IsRequired();
		}
	}
}
