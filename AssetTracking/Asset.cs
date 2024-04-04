using System.Diagnostics.CodeAnalysis;

namespace AssetTracking;


public class Asset
{
  public string Brand { get; set; } = "";
  public string Model { get; set; } = "";
  public DateTime DateOfPurchase { get; set; }
  public float Price { get; set; }
  public required Office Office { get; set; }

  [SetsRequiredMembers]
  public Asset(string brand, string model, DateTime dateOfPurchase, float price, Office office)
  {
    Brand = brand;
    Model = model;
    DateOfPurchase = dateOfPurchase;
    Price = price;
    Office = office;
  }

  public void Deconstruct(out string brand, out string model, out DateTime date, out float price, out string office, out string currency)
  {
    brand = Brand;
    model = Model;
    date = DateOfPurchase;
    price = Price * Office.ExchangeRateFromDollar;
    office = Office.Country;
    currency = Office.Currency;
  }
}
