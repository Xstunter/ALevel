using HW10_ElectricAppliances.Exceptions;
using HW10_ElectricAppliances.Models;
using HW10_ElectricAppliances.Repository.Abstracts;
using System.Linq;

namespace HW10_ElectricAppliances.Repositories
{
    public class ElectricalRepository : IElectricalRepository
    {
        private readonly List<ElectricalModel> _mockElectricalDevices = new List<ElectricalModel>();
        public List<string> AddElectricalDevices(List<ElectricalModel> divices)
        {
            var entityDevices = new List<ElectricalModel>();
            var ids = new List<string>();

            foreach (var item in divices)
            {
                ElectricalModel electricalDevice = new ElectricalModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Model = item.Model,
                    Electricity = item.Electricity,
                    Toggle = item.Toggle,
                };
                ids.Add(electricalDevice.Id.ToString());
                entityDevices.Add(electricalDevice);
                _mockElectricalDevices.Add(electricalDevice);
            }
            return ids;
        }

        public ElectricalModel FindDevice(string parametr)
        {
            if (_mockElectricalDevices.FirstOrDefault(x => x.Name.Contains(parametr)) != null)
            {
                return _mockElectricalDevices.FirstOrDefault(x => x.Name.Contains(parametr));
            }
            throw new NotFoundObject($"Divice with parametr {parametr} not found");
        }

        public ElectricalModel GetElectricalDevice(string id)
        {
            return _mockElectricalDevices.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public double GetSumElectricity()
        {
            double sum = 0;
            foreach (var item in _mockElectricalDevices)
            {
                sum += item.Electricity;
            }
            return sum;
        }

        public void PlugInDevice(ElectricalModel electricalDevice)
        {
            foreach (var item in _mockElectricalDevices)
            {
                if (item.Toggle == false)
                    item.Toggle = true;
            }
        }

        public void SortElectricalDevice()
        {
            var sortMockElectricityDevices = _mockElectricalDevices.OrderBy(x => x.Electricity).ToList();

            foreach (var item in sortMockElectricityDevices)
            {
                Console.WriteLine($"Name: {item.Name}, Electricity: {item.Electricity}");
            }
        }
    }
}
