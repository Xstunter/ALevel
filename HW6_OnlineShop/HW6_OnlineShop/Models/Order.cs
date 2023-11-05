namespace HW6_OnlineShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }

        public Order()
        {
            Random random = new Random();
            Id = random.Next(int.MinValue + int.MaxValue, int.MaxValue);
            Products = new List<Product>();
            TotalPrice = 0;
        }

    }
}
