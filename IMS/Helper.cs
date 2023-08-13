using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IMS
{
    static class Helper
    {
        public static int GetMenuChoice()
        {
            //Console.ReadKey().Key == ConsoleKey.Escape
            int menuChoice = -1;
            Console.WriteLine("Choose from following options -");
            Console.WriteLine($"Show all products:\t{1}");
            Console.WriteLine($"Add new product:\t{2}");
            Console.WriteLine($"Edit product:\t\t{3}");
            Console.WriteLine($"Delete product:\t\t{4}");
            Console.WriteLine($"Find product:\t\t{5}");
            Console.WriteLine($"Exit application:\t0");

            menuChoice = Convert.ToInt32(Console.ReadLine());
            return menuChoice;
        }
        //****************************************************************************************************

        public static void GetAllProducts()
        {
            BAL bal = new BAL();
            IEnumerable<Product> products = new List<Product>();
            products = bal.GetAllProducts();
            Console.WriteLine($"Following products found in database.");
            GetProductTableHeader();
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
                DrawSingleLine();
            }
        }
        //****************************************************************************************************

        public static void AddProduct()
        {
            //Console.Clear();
            BAL bal = new BAL();
            Product product = new Product();

            Console.Write($"Product Id:\t");
            product.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Product Name:\t");
            product.Name = Console.ReadLine();

            Console.Write($"Product Description:\t");
            product.Description = Console.ReadLine();

            Console.Write($"Manufacturer:\t");
            product.Make = Console.ReadLine();

            Console.Write($"Product Price:\t");
            product.Price = Convert.ToDecimal(Console.ReadLine());

            bal.AddProduct(product);
        }
        //***************************************************************************************************

        public static void DeleteProduct(int deleteId)
        {
            BAL bal = new BAL();
            Product product = bal.Find(deleteId);
            if (product.Id > 0)
            {
                Console.WriteLine($"Following product will be removed from database.");
                GetProductTableHeader();
                Console.WriteLine(product.ToString());
                DrawSingleLine();
                bal.DeleteProduct(product);
            }
        }
        //***************************************************************************************************
        public static void Find(int id)
        {
            BAL bal = new BAL();
            Product product = bal.Find(id);
            if (product.Id > 0)
            {
                Console.WriteLine($"Following product found in database.");
                GetProductTableHeader();
                Console.WriteLine(product.ToString());
                DrawSingleLine();
            }
            else
            {
                Console.WriteLine($"Oops! no product found in database at ID:{id}");
            }
        }
        //***************************************************************************************************

        public static void EditProduct(int id)
        {
            BAL bal = new BAL();
            Product product = bal.Find(id);
            if (product.Id > 0)
            {
                Console.WriteLine($"Following product will be removed from database.");
                GetProductTableHeader();
                Console.WriteLine(product.ToString());
                DrawSingleLine();
                Console.WriteLine("Enter new data for above selected product");
                //-----------------------------------------------------------------

                Console.Write($"Product Id:\t");
                product.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Product Name:\t");
                product.Name = Console.ReadLine();

                Console.Write($"Product Description:\t");
                product.Description = Console.ReadLine();

                Console.Write($"Manufacturer:\t");
                product.Make = Console.ReadLine();

                Console.Write($"Product Price:\t");
                product.Price = Convert.ToDecimal(Console.ReadLine());
                //-----------------------------------------------------------------
                bal.EditProduct(product);
            }
        }
        public static void GetApplicationHeader()
        {
            Console.WriteLine("\n\t\t***********************************");
            Console.WriteLine("\n\t\t--- Inventory Management System ---");
            Console.WriteLine("\n\t\t***********************************");
        }
        //***************************************************************************************************

        public static void GetProductTableHeader()
        {
            DrawDoubleLine();
            Console.WriteLine($"|ID\t|Product Name\t|Product Description\t| Product Maker\t|Product Price\t|");
            DrawDoubleLine();
        }
        //***************************************************************************************************

        public static void DrawSingleLine()
        {
            Console.WriteLine($"|________________________________________________" +
                $"_______________________________|");
        }
        //***************************************************************************************************

        public static void DrawDoubleLine()
        {
            Console.WriteLine($"+=======+" +
                $"===============+" +
                $"=======================+" +
                $"===============+" +
                $"===============+");
        }
        //***************************************************************************************************

    }
}
