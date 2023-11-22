using HW3._2_Dictionary.Models;
using System.Collections.Generic;

namespace HW3._2_Dictionary.Services.Abstracts
{
    public interface IPhoneService
    {
        public void Add(List<Contact> contact);
        public void ShowDictionary();
    }
}
