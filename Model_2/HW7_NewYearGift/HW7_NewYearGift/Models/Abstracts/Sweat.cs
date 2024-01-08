namespace HW7_NewYearGift.Models.Abstracts
{
    public abstract class Sweat
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }

        public Sweat(string name, double weight, double price)
        {
            Name = name;
            Weight = weight;
            Price = price;
        }

        public virtual void GetInfoAboutSweat()
        {
            Console.Write($"Название: {Name}, Вес: {Weight}г., Цена: {Price}грн. ");
        }
    }
}
