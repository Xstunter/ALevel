using HW10_ElectricAppliances.Exceptions;
using HW10_ElectricAppliances.Models;
using HW10_ElectricAppliances.Services.Abstracts;
using System.Xml.Linq;

namespace HW10_ElectricAppliances
{
    public class App
    {
        private readonly IElectricalService _service;
        public App(IElectricalService service)
        {
            _service = service;
        }
        public void AppStart()
        {
            ElectricalModel electricalDevice;
            try
            {
                var ids = _service.AddElectricalDevices(CreateElectricalDevice());

                Console.WriteLine("Пошук по ID:");
                electricalDevice = _service.GetElectricalDevice(ids[2]);
                Console.WriteLine($"Name: {electricalDevice.Name}, Model: {electricalDevice.Model}, Electricity: {electricalDevice.Electricity}ВАТ");
                
                _service.PlugInDevice(electricalDevice);
                Console.WriteLine($"Всi девайси включени у розетку.");

                Console.WriteLine($"Споживання електроенергiї всiх приборiв: {_service.GetSumElectricity()}ВАТ");
                
                Console.WriteLine("Метод Sort по Electricity");
                _service.SortElectricalDevice();

                Console.WriteLine("Знайти девайс за параметром:");
                electricalDevice = _service.FindDevice("Тос");
                Console.WriteLine($"Name: {electricalDevice.Name}, Model: {electricalDevice.Model}, Electricity: {electricalDevice.Electricity}ВАТ");

            }
            catch (NotFoundObject ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<ElectricalModel> CreateElectricalDevice()
        {
            var electricalDevices = new List<ElectricalModel>();

            electricalDevices.Add(new ElectricalModel()
            {
                Id = Guid.NewGuid(),
                Name = "Холодильник",
                Electricity = 50,
                Toggle = true,
                Model = "RydenX"
            });
            electricalDevices.Add(new ElectricalModel()
            {
                Id = Guid.NewGuid(),
                Name = "Мікрохвильовка",
                Electricity = 100,
                Toggle = true,
                Model = "Kaka"
            });
            electricalDevices.Add(new ElectricalModel()
            {
                Id = Guid.NewGuid(),
                Name = "Тостер",
                Electricity = 60,
                Toggle = false,
                Model = "Logitech"
            });
            return electricalDevices;
        }
    }
}
