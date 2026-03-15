using System;

public class Order
{
    public int ID { get; set; }
    public int CustomerID { get; set; }
    public int ShopAssistID { get; set; }
    public int ProductID { get; set; }
    public DateTime EntryDate { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
    public string AddressPath { get; set; }
}