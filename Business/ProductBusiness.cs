using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBusiness
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            ProductData data = new ProductData();
            products = data.GetProducts();
            return products;
        }

        public List<Product> GetProductsInStock()
        {
            List<Product> products = new List<Product>();
            ProductData data = new ProductData();
            products = data.GetProducts();

            var result = products.Where(x => x.Stock > 0 && x.Active).ToList();
            return result;
        }

        public List<Product> GetProductsByName(string name)
        {
            List<Product> products = new List<Product>();
            ProductData data = new ProductData();
            products = data.GetProducts();

            var result = products.Where(x => x.Name.Contains(name) && x.Active).ToList();
            return result;
        }
    }
}
