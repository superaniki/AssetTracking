namespace AssetTracking;


public class Phone : Asset
{
  public Phone(string brand, string model, DateTime date, int price, string country, string currency)
  {
    Brand = brand;
    Model = model;
    DateOfPurchase = date;
    Price = price;
    Country = country;
    Currency = currency;
  }
}

