using System.Collections.Generic;
using System.Linq;
using Store.Entities.Concrete;
using Store.ViewModels;

namespace Store.Mappings
{
	public class TagMapper
	{
		public TagViewModel TagToTagVm(Tag tag)
		{
			return new TagViewModel()
			{
				Id = tag.Id,
				Name = tag.Name
			};
		}
		public IEnumerable<TagViewModel> TagToTagVm(IEnumerable<Tag> tags)
		{
			return tags.Select(TagToTagVm);
		}
	}
}