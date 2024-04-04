namespace AssetTracking;


public class Asset
{
  public string Brand { get; set; } = "";
  public string Model { get; set; } = "";
  public DateTime DateOfPurchase { get; set; }
  public int Price { get; set; }
  public string Country { get; set; } = "";
  public string Currency { get; set; } = "";

  public void Deconstruct(out string brand, out string model, out DateTime date, out int price, out string country, out string currency)
  {
    brand = Brand;
    model = Model;
    date = DateOfPurchase;
    price = Price;
    country = Country;
    currency = Currency;
  }
}