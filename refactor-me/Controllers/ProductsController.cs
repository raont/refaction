using System;
using System.Net;
using System.Web.Http;
using refactor_me.Core.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;

namespace refactor_me.Controllers
{
	[RoutePrefix("products")]
	public class ProductsController : ApiController
	{
		private readonly IProductHandler _prodHandler;
		private readonly IProductOptionHandler _prodOptionHandler;
		private readonly IProductsRepo _prodRepo;

		public ProductsController(IProductsRepo productsRepo)
		{
			_prodHandler = productsRepo.GetProductHandler();
			_prodOptionHandler = productsRepo.GetProductOptionHandler();
			_prodRepo = productsRepo;
		}

		[Route]
		[HttpGet]
		public IProducts GetAll()
		{
			return _prodRepo.GetNewProducts();
		}

		[Route]
		[HttpGet]
		public IProducts SearchByName(string name)
		{
			return _prodRepo.GetNewProducts().WhereNameIs(name);
		}

		[Route("{id}")]
		[HttpGet]
		public IProduct GetProduct(Guid id)
		{
			var product = _prodHandler.GetProduct(id);
			if (product.IsNew)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return product;
		}

		[Route]
		[HttpPost]
		public void Create(Product product)
		{
			_prodHandler.Save(product);
		}

		[Route("{id}")]
		[HttpPut]
		public void Update(Guid id, Product product)
		{
			var orig = _prodHandler.GetProduct(id);
			orig.Name = product.Name;
			orig.Description = product.Description;
			orig.Price = product.Price;
			orig.DeliveryPrice = product.DeliveryPrice;
			
			if (!orig.IsNew)
				_prodHandler.Save(orig);
		}

		[Route("{id}")]
		[HttpDelete]
		public void Delete(Guid id)
		{
			_prodHandler.Delete(id);
		}

		[Route("{productId}/options")]
		[HttpGet]
		public IProductOptions GetOptions(Guid productId)
		{
			return _prodRepo.GetNewProductOptions().WhereProdIdIs(productId.ToString());
		}

		[Route("{productId}/options/{id}")]
		[HttpGet]
		public IProductOption GetOption(Guid productId, Guid id)
		{
			var option = _prodRepo.GetNewProductOption();
			if (option.IsNew)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return option;
		}

		[Route("{productId}/options")]
		[HttpPost]
		public void CreateOption(Guid productId, ProductOption option)
		{
			option.ProductId = productId;
			_prodOptionHandler.Save(option);
		}

		[Route("{productId}/options/{id}")]
		[HttpPut]
		public void UpdateOption(Guid id, ProductOption option)
		{
			var orig = _prodOptionHandler.GetProductOption(id);
			orig.Name = option.Name;
			orig.Description = option.Description;

			if (!orig.IsNew)
				_prodOptionHandler.Save(orig);
		}

		[Route("{productId}/options/{id}")]
		[HttpDelete]
		public void DeleteOption(Guid id)
		{
			_prodOptionHandler.Delete(id);
		}
	}
}
