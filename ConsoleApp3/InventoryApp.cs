using System;

public class InventoryApp
{
    private InventoryLogger<InventoryItem> _logger;

    public InventoryApp()
    {
        _logger = new InventoryLogger<InventoryItem>("inventory.json");
    }

    public void SeedSampleData()
    {
        _logger.Add(new InventoryItem(1, "Laptop", 5, DateTime.Now));
        _logger.Add(new InventoryItem(2, "Phone", 10, DateTime.Now));
        _logger.Add(new InventoryItem(3, "Tablet", 7, DateTime.Now));
    }

    public void SaveData()
    {
        _logger.SaveToFile();
    }

    public void LoadData()
    {
        _logger.LoadFromFile();
    }

    public void PrintAllItems()
    {
        foreach (var item in _logger.GetAll())
        {
            Console.WriteLine($"{item.Id}: {item.Name} - Qty: {item.Quantity} (Added: {item.DateAdded})");
        }
    }

    public void Run()
    {
        SeedSampleData();
        SaveData();

        // Simulate new session
        _logger = new InventoryLogger<InventoryItem>("inventory.json");
        LoadData();
        PrintAllItems();
    }
}
