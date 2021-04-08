using SimpleCommerce.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommerce.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> GetProducts();
    }
}
