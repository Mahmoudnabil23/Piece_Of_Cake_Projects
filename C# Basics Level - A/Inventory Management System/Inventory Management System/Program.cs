using System.Xml.Linq;

namespace Inventory_Management_System
{
    internal class Program
    {
        const int numberOfProducts = 100; 
        static string[,] products = new string[numberOfProducts, 3];
        static int productIndex = -1; 

        enum UpdateProductChoice
        {
            NAME = 1,
            QUANTITY = 2,
            PRICE = 4,
            ALL = 8
        }
        static void Main(string[] args)
        {
            //product has {id name quantity price}
            //add product
            //update product
            //view product
            //exit
            do
            {
                DisplayMenu();
                int userChoice;
                Console.Write("Choose number from 1 to 4: ");
                while (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.Write("Invalid input. Enter a number: ");
                }
                try
                {
                    switch (userChoice)
                    {
                        case 1:
                            AddProduct();
                            break;

                        case 2:
                            UpdateProductByName();
                            break;

                        case 3:
                            ViewProducts();
                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Choose number from 1 to 4: ");
                            break;
                    }
                }
                catch (Exception ex)
{
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (true);
          

        }

        static void DisplayMenu()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("   Inventory Management System");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Exit");
        }

        static void AddProduct()
        {
            if (productIndex + 1 == numberOfProducts)
            {
                throw new Exception("You have reached the storage limit!");
            }

            productIndex++;

            string[] product = GetProductInput();
            

            for(int i = 0; i < product.Length; i++)
            {
                products[productIndex, i] = product[i];
            }

            Console.WriteLine("Product is added!");
        }

        static string[] GetProductInput()
        {
            string[] product = new string[3];
            Console.Write("Enter Product Name: ");
            product[0] = Console.ReadLine();
            Console.Write("Enter Product Quantity: ");
            product[1] = GetValidNumberInput();
            Console.Write("Enter Product Price: ");
            product[2] = GetValidNumberInput();

            return product;
        }
        
        static void UpdateProduct(int index)
        {
            Console.WriteLine("Which field would you like to update? (Name, Quantity, Price, All):");
            string input = Console.ReadLine();
            if (Enum.TryParse(input, true, out UpdateProductChoice choice)){
                switch (choice) {

                    case UpdateProductChoice.NAME:
                        Console.Write("Enter the new Name: ");
                        products[index, 0] = Console.ReadLine();
                        Console.WriteLine("Name is updated!");
                        break;

                    case UpdateProductChoice.QUANTITY:
                        Console.Write("Enter the new Quantity: ");
                        products[index, 1] = GetValidNumberInput();
                        Console.WriteLine("Quantity is updated");
                        break;

                    case UpdateProductChoice.PRICE:
                        Console.Write("Enter the new Price: ");
                        products[index, 2] = GetValidNumberInput();
                        Console.WriteLine("Price is updated!");
                        break;

                    case UpdateProductChoice.ALL:
                        Console.Write("Enter the new Name: ");
                        products[index, 0] = Console.ReadLine();
                        Console.Write("Enter the new Quantity: ");
                        products[index, 1] = GetValidNumberInput();
                        Console.Write("Enter the new Price: ");
                        products[index, 2] = GetValidNumberInput();

                        Console.WriteLine("Product is updated!");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Invalid field");
            }

        }

        static void UpdateProductByName()
        {
            if (productIndex == -1)
            {
                throw new Exception("No products available!");
            }

            Console.Write("Enter the name of the product you want to update: ");
            string name = Console.ReadLine();
            int index = GetProductIndex(name);

            if(index < 0)
            {
                Console.WriteLine("No sush product name is found");
            }
            else
            {
                UpdateProduct(index);
            }


        }

        static void ViewProducts()
        {
            if (productIndex == -1) {
                throw new Exception("No products available!");
            }
            for (int i = 0; i <= productIndex; i++) {
                Console.WriteLine($"Product ID: {i+1}, Product Name: {products[i, 0]},Product Quantity: {products[i, 1]},Product Proce: {products[i, 2]}");
            }
        }

        static int GetProductIndex(string name)
        {
            int index = -1;
            for (int i = 0; i <= productIndex; i++)
            {
                if (products[i, 0].Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

       
        static string GetValidNumberInput()
        {
            string input;
            decimal value;
            while (true)
            {
                input = Console.ReadLine();  
                if (decimal.TryParse(input, out value))
                {
                    return input;
                }
                Console.Write("Invalid input. Please enter a number: ");
            }
        }

    }
}
