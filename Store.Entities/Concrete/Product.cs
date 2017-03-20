using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Store.Entities.Abstract;

namespace Store.Entities.Concrete
{
	public class Product : IEntityBase
	{
		public Product()
		{
			Tags = new List<Tag>();
			Images = new List<string>();
		}
		public int Id { set; get; }
		public string Name { set; get; }
		public string Description { set; get; }
		public decimal Price { set; get; }
		public Currency Currency { set; get; }
		// TODO: Consider making an Image entity etc
		// JsonIgnore not need, better create and respective VM
		[JsonIgnore]
		public string ImagesDb
		{
			get { return string.Join(",", Images); }
			set { Images = value.Split(',').ToList(); }
		}
		public virtual ICollection<Tag> Tags { set; get; }
		public ICollection<string> Images { set; get; }
	}
}
