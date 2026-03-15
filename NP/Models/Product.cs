using System;

public class Product
{
    public int ID { get; set; }
    public int ShopAssistID { get; set; }
    public int? CategoryID { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public DateTime EntryDate { get; set; }
    public bool IsActive { get; set; }
}