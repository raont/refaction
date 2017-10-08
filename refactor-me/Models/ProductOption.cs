using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace refactor_me.Models
{
	public class ProductOption : IProductOption
	{
		public Guid Id { get; set; }

		public Guid ProductId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		[JsonIgnore]
		public bool IsNew { get; set; }

		public ProductOption()
		{
			Id = Guid.NewGuid();
			IsNew = true;
		}

		public ProductOption(Guid id)
		{
			IsNew = true;
			var conn = Helpers.NewConnection();
			var cmd = new SqlCommand($"select * from productoption where id = '{id}'", conn);
			conn.Open();

			var rdr = cmd.ExecuteReader();
			if (!rdr.Read())
				return;

			IsNew = false;
			Id = Guid.Parse(rdr["Id"].ToString());
			ProductId = Guid.Parse(rdr["ProductId"].ToString());
			Name = rdr["Name"].ToString();
			Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
		}
	}
}