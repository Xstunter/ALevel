using System.ComponentModel;
using System.Threading;

namespace HW6_OnlineShop
{
    public class Products
    {
        public static string[] products =
        {
            "Lazanya",
            "Borch",
            "Solyanka",
            "Pure",
            "Harcho",
            "Napoleon",
            "CocaCola",
            "Moxito"
        };
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index <= products.Length - 1)
                {
                    return products[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Not correct index!");
                }
            }
        }

        public double[] price =
        {
            42.55,
            30,
            40.25,
            20,
            50,
            34,
            20,
            30
        };
        public void ShowProduct(List<string> product) 
        {
            Console.WriteLine("Choosed products:");

            foreach (var item in product)
            {
                Console.Write(item + " ");
            }        
        }

        public void ShowProduct(string[] product)
        {
            foreach (var item in product)
            {
                Console.Write($"{item,-8}\t");
            }
        }

        public void ShowPrice(double[] mas)
        {
            foreach (var item in mas)
            {
                Console.Write($"{item}грн.   \t");
            }
        }
    }
}
