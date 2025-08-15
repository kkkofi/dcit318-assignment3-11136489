using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== DCIT 318 Assignment 3 ===");
            Console.WriteLine("1. Q1 - Finance Management System");
            Console.WriteLine("2. Q2 - Healthcare System");
            Console.WriteLine("3. Q3 - Warehouse Inventory System");
            Console.WriteLine("4. Q4 - School Grading System");
            Console.WriteLine("5. Q5 - Inventory Records");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var financeApp = new FinanceApp();
                    financeApp.Run();
                    break;

                case "2":
                    var healthApp = new HealthSystemApp();
                    healthApp.Run();
                    break;

                case "3":
                    var warehouseManager = new WareHouseManager();
                    warehouseManager.Run();
                    break;

                case "4":
                    var schoolApp = new SchoolApp();
                    schoolApp.Run();
                    break;

                case "5":
                    var inventoryApp = new InventoryApp();
                    inventoryApp.Run();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
