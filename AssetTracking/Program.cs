

using System.Reflection;
using AssetTracking;

List<Asset> assetList = new List<Asset> {
    new Computer("ASUS ROG", "B550-F", new DateTime(2021, 04, 03), 243, "Sweden", "SEK"),
    new Computer("HP", "14S-FQ1010NO", new DateTime(2022, 01, 30), 679, "USA", "USD"),
    new Phone("Samsung", "S20 Plus", new DateTime(2023, 09, 12), 1500, "Sweden", "SEK"),
    new Phone("Sony Xperia", "10 III", new DateTime(2020, 03, 06), 800,"USA", "USD"),
    new Phone("Iphone", "10", new DateTime(2021, 05, 01), 951, "Greece", "EUR"),
    new Computer("HP", "Elitebook", new DateTime(2021, 08, 30), 2234, "Greece", "EUR"),
    new Computer("HP", "Elitebook", new DateTime(2020, 07, 30), 2234, "Sweden", "SEK")
}; ;

var groupedObjects = assetList.GroupBy(asset => asset.GetType());

Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase date".PadRight(18));
Console.WriteLine("Price".PadRight(12) + "Currency".PadRight(12) + "Local Price Today");
Console.Write("----".PadRight(15) + "-----".PadRight(15) + "-----".PadRight(15) + "------".PadRight(15) + "-------------".PadRight(18));
Console.WriteLine("-----".PadRight(12) + "--------".PadRight(12) + "-----------------");

Console.ForegroundColor = ConsoleColor.White;

DateTime today = DateTime.Today;
DateTime threeYearsAgo = today.AddYears(-3);
DateTime threeMonthsUntilThreeYears = threeYearsAgo.AddMonths(+3);

foreach (var group in groupedObjects)
{
  var orderedGroup = group.OrderByDescending(asset => asset.DateOfPurchase);

  foreach (Asset asset in orderedGroup)
  {
    var (brand, model, date, price, office, currency) = asset;
    var type = asset.GetType().Name;

    if (asset.DateOfPurchase <= threeMonthsUntilThreeYears && asset.DateOfPurchase >= threeYearsAgo)
      Console.ForegroundColor = ConsoleColor.Red;
    else
      if (asset.DateOfPurchase >= threeYearsAgo)
      Console.ForegroundColor = ConsoleColor.DarkGray;


    Console.Write($"{type}".PadRight(15) + $"{brand}".PadRight(15) + $"{model}".PadRight(15) + $"{office}".PadRight(15) + $"{date.ToString("MM-dd-yyyy")}".PadRight(18));
    Console.WriteLine($"{price}".PadRight(12) + $"{currency}".PadRight(12) + $"X");

    Console.ResetColor();
  }
}

Console.WriteLine();


/*

Mini Project 1

# Asset Tracking
This project is the start of an Asset Tracking database. 
It should have input possibilities from a user and print out
functionality of user data.
Asset Tracking is a way to keep track of the company assets, like Laptops, Stationary computers, 
Phones and so on...
All assets have an end of life which for simplicity reasons is 3 years.

Level 1
Create a console app that have classes and objects. For example like below with computers and phones.
Laptop Computers
- MacBook
- Asus
- Lenovo
Mobile Phones
- Iphone
- Samsung
- Nokia
You will need to create the appropriate properties and constructors for each object, like purchase date, price,
model name etc.

Level 2
Create a program to create a list of assets (inputs) where the final result is to write the following to the console:
•Sorted list with Class as primary (computers first, then phones)
•Then sorted by purchase date
•Mark any item *RED* if purchase date is less than 3 months away from 3 years.

Level 3
Add offices to the model:
You should be able to place items in 3 different offices around the world which will use the appropriate currency
for that country. You should be able to input values in dollars and convert them to each currency (based on
todays currency charts)
When you write the list to the console:
•Sorted first by office
•Then Purchase date
•Items *RED* if date less than 3 months away from 3 years
•Items *Yellow* if date less than 6 months away from 3 years
•Each item should have currency according to country

*/