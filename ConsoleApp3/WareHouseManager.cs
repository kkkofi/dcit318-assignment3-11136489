﻿using System;

public class WareHouseManager
{
    private InventoryRepository<ElectronicItem> _electronics = new InventoryRepository<ElectronicItem>();
    private InventoryRepository<GroceryItem> _groceries = new InventoryRepository<GroceryItem>();

    public void SeedData()
    {
        _electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
        _electronics.AddItem(new ElectronicItem(2, "Phone", 15, "Samsung", 12));

        _groceries.AddItem(new GroceryItem(1, "Rice", 50, DateTime.Now.AddMonths(6)));
        _groceries.AddItem(new GroceryItem(2, "Milk", 20, DateTime.Now.AddDays(10)));
    }

    public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
    {
        foreach (var item in repo.GetAllItems())
        {
            Console.WriteLine($"{item.Id}: {item.Name} - Qty: {item.Quantity}");
        }
    }

    public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
    {
        try
        {
            var existing = repo.GetItemById(id);
            repo.UpdateQuantity(id, existing.Quantity + quantity);
            Console.WriteLine($"Stock updated for {existing.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
    {
        try
        {
            repo.RemoveItem(id);
            Console.WriteLine($"Item with ID {id} removed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void Run()
    {
        SeedData();

        Console.WriteLine("=== Grocery Items ===");
        PrintAllItems(_groceries);

        Console.WriteLine("\n=== Electronic Items ===");
        PrintAllItems(_electronics);

        
        try
        {
            _electronics.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 12)); 
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        try
        {
            _groceries.RemoveItem(999); 
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        try
        {
            _electronics.UpdateQuantity(2, -5); 
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
