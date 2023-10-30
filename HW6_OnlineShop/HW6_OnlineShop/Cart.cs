namespace HW6_OnlineShop
{
    internal class Cart
    {
        public List<string> clientProducts = new List<string>();

        public List<double> priceProduct = new List<double>();
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

                    int product = int.Parse(Console.ReadLine());

                    clientProducts.Add(dish[product - 1]);

                    priceProduct.Add(dish.price[product - 1]);
                }

                dish.ShowProduct(clientProducts);

                Console.WriteLine();

                Console.WriteLine($"Total price: {priceProduct.Sum()}грн.");

                Console.WriteLine("Confirm your order. Y or N.");

                if (Console.ReadLine() == "Y")
                {
                    Random random = new Random();
                    int orderID = random.Next(int.MinValue + int.MaxValue, int.MaxValue);
                    confirm = true;
                    Console.WriteLine($"Your order confirm! OrderID:{orderID}");
                }
                else
                { 
                    clientProducts.Clear();
                    priceProduct.Clear();
                    Console.Clear();
                }

               
            }
            while (!confirm);
        }

    }
}
