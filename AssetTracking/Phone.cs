
using System.Diagnostics.CodeAnalysis;

namespace AssetTracking;

[method: SetsRequiredMembers]
public class Phone(string brand, string model, DateTime dateOfPurchase, float price, Office office) : Asset(brand, model, dateOfPurchase, price, office)
{
}

