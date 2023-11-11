using HW10_ElectricAppliances.Models;

namespace HW10_ElectricAppliances.Repository.Abstracts
{
    public interface IElectricalRepository
    {
        public List<string> AddElectricalDevices(List<ElectricalModel> divices);
        public ElectricalModel GetElectricalDevice(string id);
        public void PlugInDevice(ElectricalModel electricalDevice);
        public double GetSumElectricity();
        public void SortElectricalDevice();
        public ElectricalModel FindDevice(string parametr);

    }
}
