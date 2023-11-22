using HW3._2_Dictionary.Models;
using HW3._2_Dictionary.Services.Abstracts;
using System.Collections.Generic;

namespace HW3._2_Dictionary
{
    public sealed class App
    {
        private readonly IPhoneService _phoneService;
        public App(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        public void Start()
        {
            _phoneService.Add(AddContacts());
            _phoneService.ShowDictionary();
        }
        private List<Contact> AddContacts()
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
                FirstName = "Dima",
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
                FirstName = "Svyato",
                LastName = "Dmitriev",
                Number = "+3809999999"
            });
            contacts.Add(new Contact()
            {
                FirstName = "Svyato",
                LastName = "Dmitriev",
                Number = "9809999999"
            });
            return contacts;
        }
    }
}
