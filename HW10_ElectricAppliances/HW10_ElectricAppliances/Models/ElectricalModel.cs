namespace HW10_ElectricAppliances.Models
{
    public class ElectricalModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Electricity {  get; set; }
        public bool Toggle { get; set; }
    }
}
