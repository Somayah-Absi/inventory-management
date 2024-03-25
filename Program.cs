using System;
using System.Runtime.CompilerServices;
class Item
{


    private string Name { get; }
    private int Quantity { set; get; }
    private DateTime CreateTime { set; get; }

    public Item(string name, int quantity, DateTime createTime = default)
    {
        if (quantity > 0)
        {
            Quantity = quantity;
        }
        else { Console.WriteLine("the amount cannot be negative"); }
        Name = name;

        CreateTime = createTime == default ? DateTime.Now : createTime;

    }

    public override string ToString()
    {
        return $"Item Name:{Name} \n Quantity: {Quantity} \n Date: {CreateTime}";
    }


}
public class MyProgram
{

    public static void Main(string[] args)
    {

    }
}
