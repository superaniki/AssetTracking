using AssetTracking;

Office swe = new("Sweden", "SEK", 10.60f);
Office usa = new("USA", "USD", 1);
Office gr = new("Greece", "EUR", 0.92f);

List<Asset> assetList =
[
    new Computer("ASUS ROG", "B550-F", new DateTime(2021, 04, 03), 243, swe),
    new Computer("HP", "14S-FQ1010NO", new DateTime(2022, 01, 30), 679, usa),
    new Phone("Samsung", "S20 Plus", new DateTime(2023, 09, 12), 1500, swe),
    new Phone("Sony Xperia", "10 III", new DateTime(2020, 03, 06), 800,usa),
    new Phone("Iphone", "10", new DateTime(2021, 05, 01), 951, gr),
    new Computer("HP", "Elitebook", new DateTime(2021, 08, 30), 2234, gr),
    new Computer("HP", "Elitebook", new DateTime(2020, 07, 30), 2234, swe)
];

var groupedObjects = assetList.GroupBy(asset => asset.GetType());

Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase date".PadRight(18));
Console.WriteLine("Price".PadRight(12) + "Currency");
Console.Write("----".PadRight(15) + "-----".PadRight(15) + "-----".PadRight(15) + "------".PadRight(15) + "-------------".PadRight(18));
Console.WriteLine("-----".PadRight(12) + "--------");

Console.ForegroundColor = ConsoleColor.White;

DateTime today = DateTime.Today;
DateTime threeYearsAgo = today.AddYears(-3);
DateTime threeMonthsUntilThreeYears = threeYearsAgo.AddMonths(+3);
DateTime sixMonthsUntilThreeYears = threeYearsAgo.AddMonths(+6);

foreach (var group in groupedObjects)
{
  var orderedGroup = group.OrderByDescending(asset => asset.DateOfPurchase);

  foreach (Asset asset in orderedGroup)
  {
    var (brand, model, date, price, office, currency) = asset;
    var type = asset.GetType().Name;

    if (asset.DateOfPurchase <= threeMonthsUntilThreeYears && asset.DateOfPurchase >= threeYearsAgo)
      Console.ForegroundColor = ConsoleColor.Red;
    else if (asset.DateOfPurchase <= sixMonthsUntilThreeYears && asset.DateOfPurchase >= threeYearsAgo)
      Console.ForegroundColor = ConsoleColor.Yellow;
    else if (asset.DateOfPurchase >= threeYearsAgo)
      Console.ForegroundColor = ConsoleColor.DarkGray;

    Console.Write($"{type}".PadRight(15) + $"{brand}".PadRight(15) + $"{model}".PadRight(15) + $"{office}".PadRight(15) + $"{date.ToString("MM-dd-yyyy")}".PadRight(18));
    Console.WriteLine($"{Math.Round(price, 2)}".PadRight(12) + $"{currency}");

    Console.ResetColor();
  }
}

Console.WriteLine();

