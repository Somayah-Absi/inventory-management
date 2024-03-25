using System;
using System.Collections.Generic;
using System.Linq;

class Item
{
    private string Name;
    public string NameGet { get { return Name; } }
    private int Quantity;
    public int quantity
    {
        set { Quantity = value; }
        get { return Quantity; }
    }
    private DateTime CreateTime { set; get; }

    public Item(string name, int quantity, DateTime createTime = default)
    {
        if (quantity > 0)
        {
            Quantity = quantity;
        }
        else { Console.WriteLine("The amount cannot be negative"); }
        Name = name;
        CreateTime = createTime == default ? DateTime.Now : createTime;
    }

    public override string ToString()
    {
        return $"Item Name: {Name} \n Quantity: {Quantity} \n Date: {CreateTime}";
    }
}

class Store
{
    private List<Item> items = new List<Item>();
    public void AddItem(Item item)
    {
        bool isExist = items.Any(check => check.NameGet == item.NameGet);
        if (isExist)
        {
            Console.WriteLine("The item already exists");
        }
        else
        {
            items.Add(item);
        }
    }

    public Item FindItemByName(string name)
    {
        Item findItem = items.FirstOrDefault(item => item.NameGet == name);
        if (findItem == null)
        {
            Console.WriteLine("There is no item with the given name");
        }
        return findItem;
    }

    public void DeleteItem(string name)
    {
        Item findItem = items.FirstOrDefault(item => item.NameGet == name);
        if (findItem != null)
        {
            items.Remove(findItem);
            Console.WriteLine("Item removed successfully");
        }
        else
        {
            Console.WriteLine("There is no item with the given name");
        }
    }

    public int GetCurrentVolume()
    {
        return items.Sum(item => item.quantity);
    }

    public List<Item> SortByNameAsc()
    {
        return items.OrderBy(item => item.NameGet).ToList();
    }

    public void AllList()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}

public class MyProgram
{
    public static void Main(string[] args)
    {
        Store store = new Store();

        // Add items to the store
        store.AddItem(new Item("Water Bottle", 10, new DateTime(2023, 1, 1)));
        store.AddItem(new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1)));
        store.AddItem(new Item("Notebook", 5, new DateTime(2023, 3, 1)));
        store.AddItem(new Item("Pen", 20, new DateTime(2023, 4, 1)));
        store.AddItem(new Item("Tissue Pack", 30, new DateTime(2023, 5, 1)));
        store.AddItem(new Item("Chips Bag", 25, new DateTime(2023, 6, 1)));
        store.AddItem(new Item("Soda Can", 8, new DateTime(2023, 7, 1)));
        store.AddItem(new Item("Soap", 12, new DateTime(2023, 8, 1)));
        store.AddItem(new Item("Shampoo", 40, new DateTime(2023, 9, 1)));
        store.AddItem(new Item("Toothbrush", 50, new DateTime(2023, 10, 1)));
        store.AddItem(new Item("Coffee", 20));
        store.AddItem(new Item("Sandwich", 15));
        store.AddItem(new Item("Batteries", 10));
        store.AddItem(new Item("Umbrella", 5));
        store.AddItem(new Item("Sunscreen", 8));

        // Example usage of store methods
        Console.WriteLine($"Current volume: {store.GetCurrentVolume()}");

        Item foundItem = store.FindItemByName("Chocolate Bar");
        if (foundItem != null)
        {
            Console.WriteLine(foundItem);
        }

        store.DeleteItem("Chocolate Bar");
        Console.WriteLine($"Current volume after deletion: {store.GetCurrentVolume()}");

        List<Item> sortedItems = store.SortByNameAsc();
        foreach (var item in sortedItems)
        {
            Console.WriteLine(item);
        }
    }
}
