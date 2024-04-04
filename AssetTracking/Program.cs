﻿

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
    var (brand, model, date, price, country, currency) = asset;
    var type = asset.GetType().Name;

    if (asset.DateOfPurchase <= threeMonthsUntilThreeYears && asset.DateOfPurchase >= threeYearsAgo)
      Console.ForegroundColor = ConsoleColor.Red;
    else
      if (asset.DateOfPurchase >= threeYearsAgo)
      Console.ForegroundColor = ConsoleColor.DarkGray;


    Console.Write($"{type}".PadRight(15) + $"{brand}".PadRight(15) + $"{model}".PadRight(15) + $"{country}".PadRight(15) + $"{date.ToString("MM-dd-yyyy")}".PadRight(18));
    Console.WriteLine($"{price}".PadRight(12) + $"{currency}".PadRight(12) + $"X");

    Console.ResetColor();
  }
}

Console.WriteLine();





// creating a set list of products, mostly for testing purposes


/*
productList.Add(new Computer("HP", "Elitebook", "Sweden", "2020-10-02", "SEK", 588));
productList.Add(new Computer("Asus", "W234", "USA", "2017-04-21", "USD", 1200));
productList.Add(new Computer("Lenovo", "Yoga 730", "USA", "2018-05-28", "USD", 835));
productList.Add(new Computer("Lenovo", "Yoga 730", "USA", "2019-05-21", "USD", 1030));
productList.Add(new Computer("HP", "Elitebook", "Spain", "2019-06-01", "EUR", 1423));

productList.Add(new Phone("iPhone", "8", "Spain", "2018-12-29", "EUR", 970));
productList.Add(new Phone("iPhone", "11", "Spain", "2020-09-25", "EUR", 990));
productList.Add(new Phone("iPhone", "X", "Sweden", "2018-07-15", "SEK", 1245));
productList.Add(new Phone("Motorola", "Razr", "Sweden", "2020-03-16", "SEK", 970));

assetList.Add(new Laptop("Dell", "XPS 13", "USA", new DateTime(2021, 01, 15), 200m, new Office("USA", "$")));
assetList.Add(new Laptop("Asus", "ZenBook", "USA", new DateTime(2020, 01, 15), 300m, new Office("USA", "$")));
assetList.Add(new Laptop("Lenovo", "ThinkPad", "Sweden", new DateTime(2022, 01, 15), 350m, new Office("Sweden", "SEK")));
assetList.Add(new Laptop("HP", "Elitebook", "Sweden", new DateTime(2021, 03, 15), 950m, new Office("Sweden", "SEK")));

assetList.Add(new MobilePhone("Samsung", "Galaxy S21", "Spain", new DateTime(2021, 12, 10), 150m, new Office("Spain", "€")));
assetList.Add(new MobilePhone("Apple", "iPhone 13", "Spain", new DateTime(2020, 12, 10), 250m, new Office("Spain", "€")));
assetList.Add(new MobilePhone("Samsung", "Galaxy S20", "Spain", new DateTime(2022, 02, 10), 100m, new Office("Spain", "€")));
*/


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