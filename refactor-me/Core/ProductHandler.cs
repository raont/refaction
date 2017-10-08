using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using refactor_me.Core.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;

namespace refactor_me.Core
{
	public class ProductHandler : IProductHandler
	{
		private readonly IProductsRepo _prodRepo;
		private readonly IProductOptionHandler _productOptionHandler;

		public ProductHandler(IProductsRepo prodRep)
		{
			_prodRepo = prodRep;
			_productOptionHandler = prodRep.GetProductOptionHandler();
		}

		public void Save(IProduct product)
		{
			var conn = Helpers.NewConnection();
			var cmd = product.IsNew ?
				new SqlCommand($"insert into product (id, name, description, price, deliveryprice) values ('{product.Id}', '{product.Name}', '{product.Description}', {product.Price}, {product.DeliveryPrice})", conn) :
				new SqlCommand($"update product set name = '{product.Name}', description = '{product.Description}', price = {product.Price}, deliveryprice = {product.DeliveryPrice} where id = '{product.Id}'", conn);

			conn.Open();
			cmd.ExecuteNonQuery();
		}

		public void Delete(Guid id)
		{
			foreach (var option in _prodRepo.GetNewProductOptions().WhereProdIdIs(id.ToString()).Items)
				_productOptionHandler.Delete(option.Id);

			var conn = Helpers.NewConnection();
			conn.Open();
			var cmd = new SqlCommand($"delete from product where id = '{id}'", conn);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Gets products from store
		/// </summary>
		/// <returns><see cref="IList{IProduct}"/></returns>
		public IList<IProduct> GetProducts(string nameFilter)
		{
			var items = new List<IProduct>();
			var conn = Helpers.NewConnection();
			var cmd = new SqlCommand($"select * from product {nameFilter}", conn);
			conn.Open();

			var rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				var prod = _prodRepo.GetNewProduct();
				PopulateProduct(rdr, prod);
				items.Add(prod);
			}

			return items;
		}

		/// <summary>
		/// Gets a product from store based on id <paramref name="id"/>
		/// </summary>
		/// <param name="id">Id of the product</param>
		/// <returns><see cref="IProduct"/></returns>
		public IProduct GetProduct(Guid id)
		{
			var prod = _prodRepo.GetNewProduct();
			var conn = Helpers.NewConnection();
			var cmd = new SqlCommand($"select * from product where id = '{id}'", conn);
			conn.Open();

			var rdr = cmd.ExecuteReader();
			if (!rdr.Read())
				return prod;
			PopulateProduct(rdr, prod);
			return prod;
		}

		private static void PopulateProduct(SqlDataReader rdr, IProduct prod)
		{
			prod.IsNew = false;
			prod.Id = Guid.Parse(rdr["Id"].ToString());
			prod.Name = rdr["Name"].ToString();
			prod.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
			prod.Price = decimal.Parse(rdr["Price"].ToString());
			prod.DeliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString());
		}
	}
}