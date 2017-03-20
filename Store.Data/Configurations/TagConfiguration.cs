using Store.Entities.Concrete;

namespace Store.Data.Configurations
{
	public class TagConfiguration : EntityBaseConfiguration<Tag>
	{
		public TagConfiguration()
		{
			Property(t => t.Name).IsRequired().HasMaxLength(50);
		}
	}
}
