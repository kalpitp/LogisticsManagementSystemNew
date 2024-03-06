using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.UI
{
    public class CustomerMenu
    {

        // Main customer menu
        public static void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("\n<<<<<<< CUSTOMER MENU >>>>>>>>");
            Console.WriteLine("\n1. View Products");
            Console.WriteLine("2. View Orders");
            Console.WriteLine("3. Logout");
            Console.WriteLine("4. Exit");

            Console.WriteLine("\nEnter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    // Submenu for product
                    ProductMenu();
                    break;
                case 2:
                    // Submenu for order
                    OrderMenu();
                    break;
                case 3:
                    Console.WriteLine("Logout");
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }
        }


        // Product
            
        // Submenu for View Product
        public static void ProductMenu()
        {
            //Console.Clear();
            Console.WriteLine("product1\nproduct2\nproduct3");
            Console.WriteLine("\n1. View Product Details ");
            Console.WriteLine("2. Back to customer ");

            Console.WriteLine("\nEnter your choice: ");


            string choice=Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nEnter product serial number you want to view details of:");
                    int sNo = Convert.ToInt32(Console.ReadLine());
                    ProductDetailsMenu(sNo);
                    break;
                case "2":
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }
        }

        // Submenu for product details
        public static void ProductDetailsMenu(int sNo=0)
        {
            Console.WriteLine("\n<<<<<<< PRODUCT DETAILS >>>>>>>>");
            Console.WriteLine($"Name:");
            Console.WriteLine($"Price:");
            Console.WriteLine($"Description:");

            Console.WriteLine("1. Buy Product");
            Console.WriteLine("2. Back to Browse Products");
            Console.WriteLine("3. Back to Customer Menu");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Buy the product
                    Console.WriteLine(sNo);
                    BuyProductMenu();
                    break;
                case 2:
                    // Back to Browse Products
                    ProductMenu(); // Method to display the browse products menu
                    break;
                case 3:
                    // Back to Customer Menu
                    ShowMenu(); // Method to display the main customer menu
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }


        }

        // Submenu for buy product
        public static void BuyProductMenu()
        {
            // When the user selects "Buy Product"
            Console.WriteLine("\n<<<<<<< BUY PRODUCT >>>>>>>>");

            Console.WriteLine("Enter Quantity");
            int quantity= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1. Confirm Purchase");
            Console.WriteLine("2. Back to Product Details");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    // Confirm Purchase
                    Console.WriteLine("Purchase confirmed. Thank you!");
                    // Logic to complete the purchase
                    break;
                case 2:
                    // Back to Product Details
                    ProductDetailsMenu(); // Method to display the product details page
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }


        //ORDER

        // Submenu for View order
        public static void OrderMenu()
        {
            Console.WriteLine("order1\norder2\norder3");

            Console.WriteLine("1. View Order Details");
            Console.WriteLine("2. Back to Customer Menu");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nEnter order serial number you want to view details of:");
                    int sNo = Convert.ToInt32(Console.ReadLine());
                    OrderDetailsMenu(sNo);
                    break;
                case 2:
                    // Back to Customer Menu
                    ShowMenu(); 
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        // Submenu for order details
        public static void OrderDetailsMenu(int sNo=0)
        {
            Console.WriteLine("\n<<<<<<< ORDER DETAILS >>>>>>>>");
            Console.WriteLine($"Order ID:");
            Console.WriteLine($"Date:");
            Console.WriteLine($"Total Amount: $");
            Console.WriteLine($"Status:");

            Console.WriteLine("1. Back to Orders Menu");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Back to browse order
                    Console.WriteLine(sNo);
                    OrderMenu();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }
    }
}
