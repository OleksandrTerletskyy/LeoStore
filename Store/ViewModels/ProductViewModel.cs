using System.Collections.Generic;
using Store.Entities.Concrete;

namespace Store.ViewModels
{
	public class ProductViewModel
	{
		public int Id { set; get; }
		public string UrlName { set; get; }
		public string Name { set; get; }
		public string Description { set; get; }
		public decimal Price { set; get; }
		public Currency Currency { set; get; }
		public ICollection<string> Images { set; get; }
		public ICollection<string> TagsNames { set; get; }
	}
}