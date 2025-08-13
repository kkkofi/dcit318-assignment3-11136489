using System;

class Program
{
    static void Main()
    {
        var app = new FinanceApp();
        app.Run();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
