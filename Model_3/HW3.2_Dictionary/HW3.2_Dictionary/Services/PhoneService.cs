using HW3._2_Dictionary.Models;
using HW3._2_Dictionary.Repositories.Abstracts;
using HW3._2_Dictionary.Services.Abstracts;
using System.Collections.Generic;

namespace HW3._2_Dictionary.Services
{
    public sealed class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }
        public void Add(List<Contact> contact)
        {
            _phoneRepository.Add(contact);
        }

        public void ShowDictionary()
        {
            _phoneRepository.ShowDictionary();
        }
    }
}
