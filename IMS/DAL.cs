using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    public class DAL
    {
        //products list serves as database
        //List<Product> products = new List<Product>();

        public IEnumerable<Product> GetProducts()
        {
            //return products;
            return Database.db;
        }
        //*****************************************************

        public bool AddProduct(Product _product)
        {
            if (_product != null)
            {
                //products.Add(_product);
                Database.db.Add(_product);
                return true;
            }
            else
            {
                return false;
            }
        }
        //*****************************************************

        public bool RemoveProduct(Product _product)
        {
            if (_product != null)
            {
                //if (products.Contains(_product))
                if (Database.db.Contains(_product))
                {
                    Database.db.Remove(_product);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //*****************************************************

        public bool EditProduct(Product _product)
        {
            //if (products.Count > 0 && _product != null)
            if (Database.db.Count > 0 && _product != null)
            {
                Product dbProduct = this.Find(_product.Id);
                if (dbProduct != null && dbProduct.Id > 0)
                {
                    dbProduct = _product;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //*****************************************************

        public Product Find(int id)
        {
            Product product = new Product();

            //if (id > 0 && products.Count > 0)
            if (id > 0 && Database.db.Count > 0)
            {
                //foreach (Product p in products)
                foreach(Product p in Database.db)
                {
                    if (p.Id == id)
                    {
                        product = p;
                        break;
                    }
                }
            }
            return product;
        }
        //*****************************************************

    }
}
