using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using SalesDb.Models;

namespace SalesDb.Controllers
{
    public class ProductsController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            const string sql = "select TOP 100 * from dbo.Products";
            const string connection = "YOURCONNECTIONSTRING";
            var products = new List<Product>();

            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                using (var myCommand = new SqlCommand(sql, conn))
                {
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            var product = new Product
                            {
                                ProductId = Convert.ToInt32(myReader["ProductId"]),
                                Name = Convert.ToString(myReader["Name"]),
                                Price = Convert.ToDecimal(myReader["Price"])
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}
