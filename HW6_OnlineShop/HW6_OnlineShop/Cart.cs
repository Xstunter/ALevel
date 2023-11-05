using HW6_OnlineShop.Models;

namespace HW6_OnlineShop
{
    public class Cart
    {
        public Order CurrentOrder { get; set; }

        public Cart()
        {
            CurrentOrder = new Order();
        }
        public void GetProduct()
        {
            Products dish = new Products();

            bool confirm = false;

            do 
            {
                dish.ShowProduct(Products.products);

                Console.WriteLine();

                dish.ShowPrice(dish.price);

                Console.WriteLine();

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Enter product what do you want in 1 to {Products.products.Length}:");

                    int index = int.Parse(Console.ReadLine()) - 1;

                    Product selectedProducts = new Product(dish[index], dish.price[index]);

                    CurrentOrder.Products.Add(selectedProducts);

                    CurrentOrder.TotalPrice += selectedProducts.Price;
                }

                dish.ShowProduct(CurrentOrder.Products.Select(x=>x.Name).ToList());

                Console.WriteLine();

                Console.WriteLine($"Total price: {CurrentOrder.TotalPrice}грн.");

                Console.WriteLine("Confirm your order. Y or N.");

                if (Console.ReadLine() == "Y")
                {
                    confirm = true;
                    Console.WriteLine($"Your order confirm! OrderID:{CurrentOrder.Id}");
                }
                else
                { 
                    CurrentOrder.Products.Clear();
                    CurrentOrder.TotalPrice = 0;
                    Console.Clear();
                }            
            }
            while (!confirm);
        }

    }
}
