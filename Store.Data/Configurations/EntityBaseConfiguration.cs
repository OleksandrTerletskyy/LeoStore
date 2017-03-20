using System.Data.Entity.ModelConfiguration;
using Store.Entities.Abstract;

namespace Store.Data.Configurations
{
	public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntityBase
	{
		public EntityBaseConfiguration()
		{
			HasKey(e => e.Id);
		}
	}
}
