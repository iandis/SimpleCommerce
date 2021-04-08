using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCommerce.Models
{
    public class Products : BaseModel
    {
        public int Id { get; set; } = 0;
        public string ProductTitle { get; set; } = "";
        public string ProductPrice { get; set; } = "";
        public string ProductImageUrl { get; set; } = "";

        public Products()
        {

        }
        //public Products(Products products)
        //{
        //    Id = products.Id;
        //    ProductTitle = products.ProductTitle;
        //    ProductPrice = products.ProductPrice;
        //    ProductImageUrl = products.ProductImageUrl;
        //}
    }
}
