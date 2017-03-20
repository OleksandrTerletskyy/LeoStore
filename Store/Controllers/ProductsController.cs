﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Http;
using System.Web.Http.Description;
using Store.Data.Repositories.Abstract;
using Store.Entities.Concrete;
using Store.Infrastructure.Core;
using Store.Mappings;
using Store.ViewModels;

namespace Store.Controllers
{
	[RoutePrefix("api/products")]
	public class ProductsController : ApiControllerBase
	{
		private readonly IEntityBaseRepository<Product> _productsRepository;
		private readonly ProductMapper _productMapper;

		public ProductsController(IEntityBaseRepository<Product> productRepository,
			IEntityBaseRepository<Error> errorRepository,
			ProductMapper productMapper)
			: base(errorRepository)
		{
			_productsRepository = productRepository;
			_productMapper = productMapper;
		}

		[Route("")]
		public IEnumerable<ProductViewModel> GetProducts()
		{
			return _productMapper.ProductToProductVm(_productsRepository.All);
		}

		// GET: api/Products
		[Route("{pageSize:int}/{pageNumber:int}")]
		public IHttpActionResult GetProducts(int pageSize, int pageNumber, string filterTagNames, string searchString, string orderBy, decimal? minPrice, decimal? maxPrice)
		{
			if (searchString == null)
			{
				searchString = "";
			}

			if (orderBy == null)
			{
				orderBy = "";
			}

			if (minPrice == null)
			{
				minPrice = 0;
			}

			// filter products by search string & price
			var products = _productsRepository.All.ToList().Where(p => p.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ).ToList();

			//filter by price
			if (maxPrice != null)
			{
				products = products.Where(p => p.Price <= maxPrice).ToList();
			}
			products = products.Where(p => p.Price >= minPrice).ToList();


			// filter products by tags
			if (!string.IsNullOrEmpty(filterTagNames))
			{
				string[] tagNamesArray = filterTagNames.Split('|');
				products = products.Where(p =>
				{
					return tagNamesArray.All(tag => p.Tags.Any(t => t.Name == tag));
				}).ToList();
			}
		
			var totalCount = products.Count();
			var totalPages = Math.Ceiling((double)totalCount / pageSize);

			if (orderBy == "asc")
			{
				products = products.OrderBy(p => p.Price).ToList();
			}
			if (orderBy == "desc")
			{
				products = products.OrderByDescending(p => p.Price).ToList();
			}


			var pageProducts = products.Skip((pageNumber - 1) * pageSize)
									.Take(pageSize).ToList();

			var result = new
			{
				totalCount,
				totalPages,
				contents = _productMapper.ProductToProductVm(pageProducts)
			};

			return Ok(result);
		}

		[ResponseType(typeof(ProductViewModel))]
		[Route("{name}")]
		public IHttpActionResult GetProduct(string name)
		{
			var product = _productMapper.GetProductByUrlName(name);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(_productMapper.ProductToProductVm(product));
		}

		#region put, post & delete
		//// PUT: api/Products/5
		//[ResponseType(typeof(void))]
		//public async Task<IHttpActionResult> PutProduct(int id, Product product)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	if (id != product.Id)
		//	{
		//		return BadRequest();
		//	}

		//	db.Entry(product).State = EntityState.Modified;

		//	try
		//	{
		//		await db.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!ProductExists(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}

		//	return StatusCode(HttpStatusCode.NoContent);
		//}

		//// POST: api/Products
		//[ResponseType(typeof(Product))]
		//public async Task<IHttpActionResult> PostProduct(Product product)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	db.Products.Add(product);
		//	await db.SaveChangesAsync();

		//	return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
		//}

		//// DELETE: api/Products/5
		//[ResponseType(typeof(Product))]
		//public async Task<IHttpActionResult> DeleteProduct(int id)
		//{
		//	Product product = await db.Products.FindAsync(id);
		//	if (product == null)
		//	{
		//		return NotFound();
		//	}

		//	db.Products.Remove(product);
		//	await db.SaveChangesAsync();

		//	return Ok(product);
		//}
		#endregion

		private bool ProductExists(int id)
		{
			return _productsRepository.All.Count(p => p.Id == id) > 0;
		}
	}
}
