using System.Collections.Generic;
using Store.Entities.Abstract;

namespace Store.Entities.Concrete
{
	public class Tag : IEntityBase
	{
		public Tag()
		{
			Products = new List<Product>();
		}
		public int Id { set; get; }
		public string Name { set; get; }
		public virtual ICollection<Product> Products { set; get; }
	}
}
