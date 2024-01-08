using HW10_ElectricAppliances.Models;

namespace HW10_ElectricAppliances.Services.Abstracts
{
    public interface IElectricalService
    {
        public List<string> AddElectricalDevices(List<ElectricalModel> divices);
        public ElectricalModel GetElectricalDevice(string id);
        public void PlugInDevice(ElectricalModel electricalDevice);
        public double GetSumElectricity();
        public void SortElectricalDevice();
        public ElectricalModel FindDevice(string parametr);
    }
}
