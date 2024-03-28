using System;
using System.Collections.Generic;
using System.Linq;

class Item
{
    private string name;
    public string Name { set { name = value; } get { return name; } }
    private int quantity;
    public int Quantity
    {
        set { quantity = value; }
        get { return quantity; }
    }
    private DateTime createTime;
    public DateTime CreateTime
    {
        private set { createTime = value; }
        get { return createTime; }
    }

    public Item(string name, int quantity, DateTime createTime = default)
    {
        if (quantity > 0)
        {
            Quantity = quantity;
        }
        else { Console.WriteLine("The amount cannot be negative"); }

        this.name = name;
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
    private int maxCapacity;

    public Store(int capacity)
    {
        maxCapacity = capacity;
    }
    public enum Order
    {
        ASC,
        DESC
    }


    public void AddItem(Item item)
    {
        if (GetCurrentVolume() + item.Quantity > maxCapacity)
        {
            Console.WriteLine("Cannot add item. Store is at maximum capacity.");
            return;
        }
        bool isExist = items.Any(check => check.Name == item.Name);
        if (isExist)
        {
            Console.WriteLine("The item already exists");
        }
        else
        {
            items.Add(item);
        }
    }
    public Dictionary<string, List<Item>> GroupByDate()
    {
        var now = DateTime.Now;
        var cutoffDate = now.AddMonths(-3);

        var groupedItems = items.GroupBy(item => item.CreateTime >= cutoffDate ? "New Arrival" : "Old")
                                .ToDictionary(g => g.Key, g => g.ToList());

        return groupedItems;
    }
    public Item? FindItemByName(string name)
    {
        Item? findItem = items.FirstOrDefault(item => item.Name == name);
        if (findItem == null)
        {
            Console.WriteLine("There is no item with the given name");
        }
        return findItem;
    }
    public void DeleteItem(string name)
    {
        Item? findItem = items.FirstOrDefault(item => item.Name == name);
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
    public IEnumerable<Item> SortByDate(Order OrderChoice)
    {
        if (OrderChoice == Order.ASC)
        {
            return items.OrderBy(item => item.CreateTime);


        }
        else
        {
            return items.OrderByDescending(item => item.CreateTime);
        }
    }


    public int GetCurrentVolume()
    {
        return items.Sum(item => item.Quantity);
    }

    public List<Item> SortByNameAsc()
    {
        return items.OrderBy(item => item.Name).ToList();
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


        // items example - You do not need to follow exactly the same
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);


        var store = new Store(300);

        store.AddItem(waterBottle);
        store.AddItem(chocolateBar);
        store.AddItem(notebook);
        store.AddItem(pen);
        store.AddItem(tissuePack);
        store.AddItem(chipsBag);
        store.AddItem(sodaCan);
        store.AddItem(soap);
        store.AddItem(shampoo);
        store.AddItem(toothbrush);
        store.AddItem(coffee);
        store.AddItem(sandwich);
        store.AddItem(batteries);
        store.AddItem(umbrella);
        store.AddItem(sunscreen);


        Console.WriteLine($"Current volume: {store.GetCurrentVolume()}");

        store.FindItemByName("Chocolate Bar");
        store.FindItemByName("Batteries");

        store.DeleteItem("Chocolate Bar");
        Console.WriteLine($"Current volume after deletion: {store.GetCurrentVolume()}");

        List<Item> sortedItems = store.SortByNameAsc();
        Console.WriteLine("_________________________________________________");
        Console.WriteLine("items after sorting by name: \n ");
        foreach (var item in sortedItems)
        {
            Console.WriteLine(item);
        }
        var collectionSortedByDate = store.SortByDate(Store.Order.DESC);
        Console.WriteLine("______________________________________________________");
        Console.WriteLine("items after order it by date:\n ");
        foreach (var item in collectionSortedByDate)
        {
            Console.WriteLine($"{item}");
        }
        Console.WriteLine("______________________________________________________");
        Console.WriteLine("items organized depend on date: \n");
        var groupByDate = store.GroupByDate();
        foreach (var group in groupByDate)
        {
            Console.WriteLine($"{group.Key} Items:");
            foreach (var item in group.Value)
            {
                Console.WriteLine($" - {item.Name}, Created: {item.CreateTime.ToShortDateString()}");
            }
        }
    }
}
