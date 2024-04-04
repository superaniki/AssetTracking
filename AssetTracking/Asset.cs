namespace AssetTracking;


public class Asset
{
  public string Brand { get; set; } = "";
  public string Model { get; set; } = "";
  public DateTime DateOfPurchase { get; set; }
  public int Price { get; set; }
  public string Office { get; set; } = "";
  public string Currency { get; set; } = "";

  public void Deconstruct(out string brand, out string model, out DateTime date, out int price, out string office, out string currency)
  {
    brand = Brand;
    model = Model;
    date = DateOfPurchase;
    price = Price;
    office = Office;
    currency = Currency;
  }
}