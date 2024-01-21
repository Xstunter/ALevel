using HW7_NewYearGift.Models;
using HW7_NewYearGift.Models.Abstracts;
using HW7_NewYearGift.Servicies;

Sweat firstSweat = new Candy("Nuts",50,20,"Chocolate");

Sweat secondSweat = new Gingerbread("SnowMan",40,50,"Star");

Sweat thirdSweat = new Fruct("Banana",30,10,"Africa");

Gift gift = new Gift();

gift.AddSweat(firstSweat);
gift.AddSweat(thirdSweat);
gift.AddSweat(secondSweat);

Console.WriteLine($"Total weight: {gift.GetWeight()}g.");

Console.WriteLine("All sweats in gift");

foreach (var sweat in gift.sweats)
{
    sweat.GetInfoAboutSweat();
}

Console.WriteLine("Sort gifts by price");

gift.Sort();

foreach (var sweat in gift.sweats)
{
    sweat.GetInfoAboutSweat();
}

Console.WriteLine("Find a candies in a gift that matches the given parameter criteria price <= 25:");

List<Sweat> sweats = gift.GetSweat(sweat => sweat.Price <= 25);

foreach (var sweat in sweats)
{
    sweat.GetInfoAboutSweat();
}