using HW3._4_LINQ_2;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        var list = AddContacts();
        var workWithList = list.Where(x => x.FirstName.StartsWith('S'))
                               .Take(2)
                               .OrderBy(x => x.FirstName)
                               .Select(x => new Contact()
                               {
                                   FirstName = "Hello " + x.FirstName,
                                   LastName = x.LastName,
                                   Number = x.Number,
                               })
                               .FirstOrDefault(x => x.Number.Contains("#"));

            Console.WriteLine($"FirstName:{workWithList.FirstName}, LastName: {workWithList.LastName}, Number:{workWithList.Number}");
    }
    private static List<Contact> AddContacts()
    {
        var contacts = new List<Contact>();
        contacts.Add(new Contact()
        {
            FirstName = "Bogdan",
            LastName = "Datsenko",
            Number = "+3809999999"
        });
        contacts.Add(new Contact()
        {
            FirstName = "Egor",
            LastName = "Nyjnenko",
            Number = "+0449999999"
        });
        contacts.Add(new Contact()
        {
            FirstName = "Sima",
            LastName = "Klymenko",
            Number = "#3809999999"
        });
        contacts.Add(new Contact()
        {
            FirstName = "Svyato",
            LastName = "Dmitriev",
            Number = "3809999999"
        });
        contacts.Add(new Contact()
        {
            FirstName = "Sebas",
            LastName = "Lych",
            Number = "+3809999999"
        });
        contacts.Add(new Contact()
        {
            FirstName = "Eva",
            LastName = "Roro",
            Number = "9809999999"
        });
        return contacts;
    }
}
