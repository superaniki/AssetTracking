using System.Diagnostics.CodeAnalysis;

namespace AssetTracking;

[method: SetsRequiredMembers]
public class Computer(string brand, string model, DateTime date, int price, Office office) : Asset(brand, model, date, price, office)
{
}
