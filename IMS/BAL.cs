using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    public class BAL
    {
        DAL dal = new DAL();
        public IEnumerable<Product> GetAllProducts()
        {
            return dal.GetProducts();
        }
        //****************************************************************************************************

        public void AddProduct(Product _product)
        {
            if (_product != null && _product.Id > 0)        //check if user provided right product data
            {
                Product dbProduct = dal.Find(_product.Id);  //check if a product exists on same id in db
                if (_product.Id == dbProduct.Id)            //if user proved id already occupied in db
                {
                    Console.WriteLine($"Oops! Following product already exists in database at ID:{_product.Id}\n" +
                        $"{dbProduct.ToString()}");
                }
                else
                {
                    if (dal.AddProduct(_product))           //if id available in db, add product in db
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Following product added in database successfully\n");
                        Helper.GetProductTableHeader();                 //print table header
                        Console.WriteLine($"{_product.ToString()}");     //print product
                        Helper.DrawSingleLine();                        //print row line
                    }
                    else
                    {
                        //if some error occured while adding product in db
                        Console.WriteLine($"Oops! something went wrong while adding product in database.");
                    }
                }
            }
        }
        //****************************************************************************************************

        public void DeleteProduct(Product _product)
        {
            Product product = dal.Find(_product.Id);
            if (product != null && product.Id == _product.Id)
            {
                dal.RemoveProduct(product);
                Console.WriteLine($"Following product has been removed from database\n" +
                    $"{product.ToString()}");
            }
            else
            {
                Console.WriteLine($"Oops! something went wrong while deleting product from database.");
            }
        }
        //****************************************************************************************************

        public void EditProduct(Product _product)
        {
            if (_product != null && _product.Id > 0)
            {
                if (dal.EditProduct(_product))
                {
                    Console.WriteLine($"Product edited successfully at ID:{_product.Id}");
                }
                else
                {
                    Console.WriteLine($"Oops! something went wrong while editing product at ID:{_product.Id}");
                }
            }
            else
            {
                Console.WriteLine($"Oops! invalid data provided by user.");
            }
        }
        //****************************************************************************************************

        public Product Find(int id)
        {
            Product product = new Product();
            if (id > 0)
            {
                product = dal.Find(id);
                return product;
            }
            else
            {
                return product;
            }
        }
        //****************************************************************************************************
    }
}
