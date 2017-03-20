using System;
using System.Collections.Generic;
using Store.Entities.Abstract;

namespace Store.Entities.Concrete
{
	public class Order : IEntityBase
	{
		public Order()
		{
			Products = new List<Product>();
		}
		public int Id { get; set; }
		public string CustomerName { set; get; }
		public string CustomerPhone { set; get; }
		public string CustomerDetails { set; get; }
		public DateTime OrderDate { set; get; }
		public ICollection<Product> Products { set; get; }
	}
}
