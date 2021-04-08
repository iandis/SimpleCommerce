using SimpleCommerce.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommerce.Services.ProductService
{
    public class ProductService : IProductService
    {
        public static ProductService Instance { get; } = new ProductService();
        public async Task<IEnumerable<Products>> GetProducts()
        {
            List<Products> products = new List<Products>();

            string uri = "https://fakestoreapi.com/products";

            string response = await RequestProvider.RequestProvider.Instance.GetAsync(uri);

            if (!string.IsNullOrEmpty(response))
            {
                JArray resp = JArray.Parse(response);
                foreach (JObject r in resp)
                {
                    var prod = new Products()
                    {
                        Id = (int)r["id"],
                        ProductTitle = (string)r["title"],
                        ProductPrice = "$" + (string)r["price"],
                        ProductImageUrl = (string)r["image"],
                    };
                    products.Add(prod);
                }
            }
            return await Task.FromResult(products);
        }
    }
}
