using HW3._2_Dictionary.Models;
using System.Collections.Generic;

namespace HW3._2_Dictionary.Repositories.Abstracts
{
    public interface IPhoneRepository
    {
        public void Add(List<Contact> contact);
        public void ShowDictionary();

    }
}
