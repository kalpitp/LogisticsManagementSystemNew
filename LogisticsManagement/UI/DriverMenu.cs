using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.UI
{
    public class DriverMenu
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n<<<<<<< DRIVER MENU >>>>>>>");
            Console.WriteLine("1. View Assigned Orders");
            Console.WriteLine("2. Update Order Status");
            Console.WriteLine("3. Logout");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\nEnter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // View Assigned Orders
                    ViewAssignedOrders();
                    break;
                case 2:
                    UpdateOrderStatus();
                    break;
                case 3:
                    Console.WriteLine("Logout");
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void ViewAssignedOrders()
        {
            // Inside the Driver menu
            Console.WriteLine("\n<<<<<<< VIEW ASSIGNED ORDERS >>>>>>>");
            Console.WriteLine("1.Order1\n 2. Order2");

            Console.WriteLine("1. View Details of a Specific Order");
            Console.WriteLine("2. Back to Driver Menu");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // View Details of a Specific Order"
                    Console.Write("Enter Order ID:");
                    int orderId= Convert.ToInt32(Console.ReadLine());
                    break;
                case "2":
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }

        public static void UpdateOrderStatus()
        {
            Console.WriteLine("\n<<<<<<< UPDATE ORDER STATUS >>>>>>>");

            Console.Write("\nEnter Order ID: ");
            int orderId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Select Status: ");
            string orderStatus = Console.ReadLine();

            Console.WriteLine("1. Confirm Update");
            Console.WriteLine("2. Back to Manager Menu");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Status Updated");
            }
            else if (choice == "2")
            {
                ShowMenu();
            }
            else Console.WriteLine("Invalid Choice");
        }
    }
}
