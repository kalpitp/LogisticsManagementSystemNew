using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.UI
{
    public class AdminMenu
    {

        // Main menu for Admin
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n<<<<<<< ADMIN MENU >>>>>>>");
            Console.WriteLine("\n1. Manage Customers");
            Console.WriteLine("2. Manage Warehouse Managers");
            Console.WriteLine("3. Manage Drivers");
            Console.WriteLine("4. Logout");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\nEnter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ManageCustomerMenu();
                    break;
                case 2:
                    ManageManagerMenu();
                    break;
                case 3:
                    ManageDriverMenu();
                    break;
                case 4:
                    Console.WriteLine("Logout");
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }

        }

        // Submenu for manage customer
        public static void ManageCustomerMenu()
        {
            // Manage Customers submenu
            Console.WriteLine("\n<<<<<<< MANAGE CUSTOMER >>>>>>>");
            Console.WriteLine("1. View All Customers");
            //Console.WriteLine("2. Add New Customer");
            //Console.WriteLine("3. Update Customer");
            Console.WriteLine("2. Delete Customer");
            Console.WriteLine("3. Back to Admin Menu");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // View All Customers
                    CommonViewAllUser("customer");
                    break;
                case "2":
                    // Delete Customer
                    CommonDeleteUser("customer");
                    break;
                case "3":
                    // Back to Admin Menu
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        // Submenu for manage manager
        public static void ManageManagerMenu()
        {
            // Manage Customers submenu
            Console.WriteLine("\n<<<<<<< MANAGE WAREHOUSE MANAGER >>>>>>>");
            Console.WriteLine("1. View All Managers");
            Console.WriteLine("2. Manager Signup Approval");
            //Console.WriteLine("2. Add New Manager");
            //Console.WriteLine("3. Update Manager");
            Console.WriteLine("3. Delete Manager");
            Console.WriteLine("4. Back to Admin Menu");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // View All Customers
                    CommonViewAllUser("manager");
                    break;
                case "2":
                    // Manager's approval for signup
                    CommonApproveUser("manager");
                    break;
                case "3":
                    // Delete Customer
                    CommonDeleteUser("manager");
                    break;
                case "4":
                    // Back to Admin Menu
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        // Submenu for manage driver
        public static void ManageDriverMenu()
        {
            // Manage Driver submenu
            Console.WriteLine("\n<<<<<<< MANAGE Driver >>>>>>>");
            Console.WriteLine("1. View All Drivers");
            Console.WriteLine("2. Driver Signup Approval");
            //Console.WriteLine("2. Add New Manager");
            //Console.WriteLine("3. Update Manager");
            Console.WriteLine("3. Delete Driver");
            Console.WriteLine("4. Back to Admin Menu");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // View All Customers
                    CommonViewAllUser("driver");
                    break;
                case "2":
                    // Manager's approval for signup
                    CommonApproveUser("driver");
                    break;
                case "3":
                    // Delete Customer
                    CommonDeleteUser("driver");
                    break;
                case "4":
                    // Back to Admin Menu
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }


        //-------------------------------------------------------------------------

        //Menu for listing user
        public static void CommonViewAllUser(string userType)
        {
            if (userType == "customer")
            {
                //View customer
                Console.WriteLine("1. cust1 \n 2. cust2");
                ManageCustomerMenu();
            }
            else if (userType == "manager")
            {
                // view manager
                Console.WriteLine("1. mang1 \n 2. mang2");

            }
            else if (userType == "driver")
            {
                // view driver
                Console.WriteLine("1. drv1 \n 2. drv2");

            }
            else
            {
                Console.WriteLine("Invalid User Type");
            }


        }

        // Menu for approval of manager or driver
        public static void CommonApproveUser(string userType)
        {

            Console.WriteLine($"\n<<<<<<< {userType.ToUpper()} SIGNUP APPROVAl >>>>>>>");

            Console.WriteLine($"\n1.manager1\nmanager2");
            // Inside the Admin menu

            Console.WriteLine($"1. Approve {userType[0].ToString().ToUpper() + userType.Substring(1)} Signup");
            Console.WriteLine($"2. Reject {userType[0].ToString().ToUpper() + userType.Substring(1)} Signup");
            Console.WriteLine($"3. Back to Admin Menu");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Approve Manager Signup
                    Console.WriteLine($"\nEnter {userType[0].ToString().ToUpper() + userType.Substring(1)} serial number you want to approve:");
                    int sNoApprove = Int32.Parse(Console.ReadLine());

                    break;
                case "2":
                    // Reject Manager Signup
                    Console.WriteLine($"\nEnter {userType[0].ToString().ToUpper() + userType.Substring(1)} serial number you want to reject:");
                    int sNoReject = Int32.Parse(Console.ReadLine());
                    break;
                case "3":
                    // Back to Admin Menu
                    ShowMenu(); // Method to display the main Admin menu
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        public static void CommonDeleteUser(string userType)
        {
            Console.WriteLine($"\n<<<<<<< DELETE {userType.ToUpper()} >>>>>>>");

            Console.WriteLine($"1. Delete {string.Concat(userType[0].ToString().ToUpper(), userType.AsSpan(1))} ");
            Console.WriteLine($"2. Back to Manage {string.Concat(userType[0].ToString().ToUpper(), userType.AsSpan(1))}");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Enter ID to Delete
                    Console.WriteLine($"1. Enter {userType[0].ToString().ToUpper() + userType.Substring(1)} ID to Delete");
                    int id = Int32.Parse(Console.ReadLine());
                    break;
                case "2":
                    // Back to Manage Customers
                    if (userType == "customer") ManageCustomerMenu();
                    else if (userType == "manager") ManageManagerMenu();
                    else if(userType== "driver") ManageDriverMenu();
                
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

    }

}
