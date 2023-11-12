using HW10_ElectricAppliances.Models;
using HW10_ElectricAppliances.Repository.Abstracts;
using HW10_ElectricAppliances.Services.Abstracts;

namespace HW10_ElectricAppliances.Services
{
    public class ElectricalService : IElectricalService
    {
        private readonly IElectricalRepository _repository;
        public ElectricalService(IElectricalRepository repository)
        {
            _repository = repository;
        }
        public List<string> AddElectricalDevices(List<ElectricalModel> divices)
        {
            return _repository.AddElectricalDevices(divices);
        }

        public ElectricalModel FindDevice(string parametr)
        {
            var electricalEntity = _repository.FindDevice(parametr);
            return new ElectricalModel()
            {
                Id = electricalEntity.Id,
                Name = electricalEntity.Name,
                Model = electricalEntity.Model,
                Toggle = electricalEntity.Toggle,
                Electricity = electricalEntity.Electricity,
            };
        }

        public ElectricalModel GetElectricalDevice(string id)
        {
            return _repository.GetElectricalDevice(id);
        }

        public double GetSumElectricity()
        {
            return _repository.GetSumElectricity();
        }

        public void PlugInDevice(ElectricalModel electricalDevice)
        {
            _repository.PlugInDevice(electricalDevice);
        }

        public void SortElectricalDevice()
        {
            _repository.SortElectricalDevice();
        }
    }
}
