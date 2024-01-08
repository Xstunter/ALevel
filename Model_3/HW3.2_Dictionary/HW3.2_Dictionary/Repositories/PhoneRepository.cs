using HW3._2_Dictionary.Enums;
using HW3._2_Dictionary.Models;
using HW3._2_Dictionary.Repositories.Abstracts;
using System;
using System.Collections.Generic;

namespace HW3._2_Dictionary.Repositories
{
    public sealed class PhoneRepository : IPhoneRepository
    {
        private readonly Dictionary<KeysInDictionary, List<Contact>> dictionary;
        public PhoneRepository()
        {
            dictionary = new Dictionary<KeysInDictionary, List<Contact>>()
            {
                {KeysInDictionary.English, new List<Contact>() },
                {KeysInDictionary.Ukrainian, new List<Contact>() },
                {KeysInDictionary.Hash, new List<Contact>() },
                {KeysInDictionary.Number, new List<Contact>() },
            };
        }
        public void Add(List<Contact> contacts)
        {
            foreach (var item in contacts)
            {
                KeysInDictionary key = GetKeysInDictionary(item);
                dictionary[key].Add(item);
            }
        }
        public void ShowDictionary()
        {
            foreach (var item in dictionary)
            {
                foreach (var contact in item.Value)
                {
                    Console.WriteLine($"Key: {item.Key}, Number:{contact.Number}");
                }
            }
        }

        private KeysInDictionary GetKeysInDictionary(Contact contact)
        {
            if (contact.Number.Contains("+380"))            // Якщо ніякий номер не підходить, то поверне English                                                        
            {                                               // це по завданню (English by default if language is not specified)
                return KeysInDictionary.Ukrainian;
            }
            else if (contact.Number.Contains("#"))
            {
                return KeysInDictionary.Hash;
            }
            else if (CheckNumber(contact))
            {
                return KeysInDictionary.Number;
            }
            return KeysInDictionary.English;
        }
        private bool CheckNumber(Contact contact)           //Перевірка початка номера від 0-9
        {
            for (int i = 48; i <= 57; i++)
            {
                if (contact.Number.StartsWith((char)i))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
