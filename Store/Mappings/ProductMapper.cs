using System.Collections.Generic;
using System.Linq;
using Store.Data.Repositories.Abstract;
using Store.Entities.Concrete;
using Store.ViewModels;

namespace Store.Mappings
{
	public class ProductMapper
	{
		private IEntityBaseRepository<Product> _productsRepository;

		public ProductMapper(IEntityBaseRepository<Product> productsRepository)
		{
			_productsRepository = productsRepository;
		}

		public ProductViewModel ProductToProductVm(Product sourceProduct)
		{
			var destProduct = new ProductViewModel
			{
				Id = sourceProduct.Id,
				Currency = sourceProduct.Currency,
				Images = sourceProduct.Images,
				Description = sourceProduct.Description,
				Name = sourceProduct.Name,
				Price = sourceProduct.Price,
				TagsNames = (from tag in sourceProduct.Tags select tag.Name).ToList(),
				UrlName = GetUrlName(sourceProduct)
			};
			return destProduct;
		}

		private string GetUrlName(Product product)
		{
			var countWithSameName = _productsRepository.All.Count(p => p.Name == product.Name) - 1;
			var urlNamePostfix = (countWithSameName > 0) ? " " + product.Id : "";
			return (product.Name + urlNamePostfix).Replace(' ', '_');
		}

		public IEnumerable<ProductViewModel> ProductToProductVm(IEnumerable<Product> sourceList)
		{
			return sourceList.Select(ProductToProductVm);
		}

		public Product GetProductByUrlName(string name)
		{
			int possibleId;
			var lastSymbols = name.Split('_').Last();
			if (int.TryParse(lastSymbols, out possibleId))
			{
				var nameWithoutId = name.Substring(0, name.LastIndexOf("_"+lastSymbols));

				var possibleProduct =
					_productsRepository.All.ToList().FirstOrDefault(p => (p.Id == possibleId) && (GetUrlName(p) == nameWithoutId));
				if (possibleProduct!=null)
				{
					return possibleProduct;
				}
			}
			var product = _productsRepository.All.ToList().FirstOrDefault(p => GetUrlName(p) == name);
			return product;
		}
	}
}