namespace HW10_ElectricAppliances.Entity
{
    public class ElectricalEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Electricity { get; set; }
        public bool Toggle { get; set; }
    }
}
