//To Draw Table in console application;
//  ->  https://stackoverflow.com/questions/856845/how-to-best-way-to-draw-table-in-console-app-c
//
using IMS;

public class Program
{
    //List<Product> database = new List<Product>();
    private static void Main(string[] args)
    {
        Helper.GetApplicationHeader();

        bool isTerminate = false;
        while (!isTerminate)
        {
            switch (Helper.GetMenuChoice())
            {
                case 1:
                    {
                        Console.Clear();
                        Helper.GetApplicationHeader();
                        Console.WriteLine("Show all product selected.");
                        Helper.GetAllProducts();
                        Console.WriteLine();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Helper.GetApplicationHeader();
                        Console.WriteLine("Add new product selected.");
                        Helper.AddProduct();
                        Console.WriteLine();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Helper.GetApplicationHeader();
                        Console.WriteLine("Edit product selected.");
                        Helper.GetAllProducts();
                        Console.Write("Select an ID from above products table to edit product.");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Helper.EditProduct(id);
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Helper.GetApplicationHeader();
                        Console.WriteLine("Delete product selected.");
                        Helper.GetAllProducts();
                        Console.Write("Select an ID from above products table to delete product.");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        Helper.DeleteProduct(deleteId);
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        Helper.GetApplicationHeader();
                        Console.WriteLine("Find product selected.");
                        Console.Write("Enter a number as \"Product ID\" to find a product in database.");
                        int findId = Convert.ToInt32(Console.ReadLine());
                        Helper.Find(findId);
                        break;
                    }
                case 0:
                    {
                        Console.Clear();
                        Console.WriteLine("Application is terminating.\n" +
                            "Press any key to exit.");
                        Console.ReadKey();
                        isTerminate = true;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}