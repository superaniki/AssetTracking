namespace AssetTracking;

public class Computer : Asset
{
  public Computer(string brand, string model, DateTime date, int price, string office, string currency)
  {
    Brand = brand;
    Model = model;
    DateOfPurchase = date;
    Price = price;
    Office = office;
    Currency = currency;
  }
}
