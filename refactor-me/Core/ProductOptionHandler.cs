using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using refactor_me.Core.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;

namespace refactor_me.Core
{
	public class ProductOptionHandler : IProductOptionHandler
	{
		private readonly IProductsRepo _prodRepo;

		public ProductOptionHandler(IProductsRepo prodRep)
		{
			_prodRepo = prodRep;
		}

		/// <summary>
		/// Save <paramref name="productOption"/> to store
		/// </summary>
		/// <param name="productOption"><see cref="IProductOption"/></param>
		public void Save(IProductOption productOption)
		{
			var conn = Helpers.NewConnection();
			var cmd = productOption.IsNew ?
				new SqlCommand($"insert into productoption (id, productid, name, description) values ('{productOption.Id}', '{productOption.ProductId}', '{productOption.Name}', '{productOption.Description}')", conn) :
				new SqlCommand($"update productoption set name = '{productOption.Name}', description = '{productOption.Description}' where id = '{productOption.Id}'", conn);

			conn.Open();
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Delete a product option with <paramref name="id"/>
		/// </summary>
		/// <param name="id"><see cref="Guid"/></param>
		public void Delete(Guid id)
		{
			var conn = Helpers.NewConnection();
			conn.Open();
			var cmd = new SqlCommand($"delete from productoption where id = '{id}'", conn);
			cmd.ExecuteReader();
		}

		/// <summary>
		/// Gets products from store
		/// </summary>
		/// <returns><see cref="IList{IProduct}"/></returns>
		public IList<IProductOption> GetProductOptions(string prodIdFilter)
		{
			var items = new List<IProductOption>();
			var conn = Helpers.NewConnection();
			var cmd = new SqlCommand($"select id from productoption {prodIdFilter}", conn);
			conn.Open();

			var rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				var id = Guid.Parse(rdr["id"].ToString());
				items.Add(new ProductOption(id));
			}

			return items;
		}

		/// <summary>
		/// Gets a <see cref="IProductOption"/> based on <paramref name="id"/> 
		/// </summary>
		/// <param name="id"><see cref="Guid"/></param>
		/// <returns><see cref="IProductOption"/></returns>
		public IProductOption GetProductOption(Guid id)
		{
			var prodOp = _prodRepo.GetNewProductOption();
			
			var conn = Helpers.NewConnection();
			var cmd = new SqlCommand($"select * from productoption where id = '{id}'", conn);
			conn.Open();

			var rdr = cmd.ExecuteReader();
			if (!rdr.Read())
				return prodOp;

			prodOp.IsNew = false;
			prodOp.Id = Guid.Parse(rdr["Id"].ToString());
			prodOp.ProductId = Guid.Parse(rdr["ProductId"].ToString());
			prodOp.Name = rdr["Name"].ToString();
			prodOp.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
			return prodOp;
		}
	}
}