using HW8_Salad.Models.Abstracts;

namespace HW8_Salad.Models
{
    public class Sous : Ingredient
    {
        public bool WithLactose { get; set; }
        public Sous(string name, double calories, decimal price, bool withLactose) : base(name, calories, price)
        {
            WithLactose = withLactose;
        }

        public override void ShowIngredients()
        {
            base.ShowIngredients();
            Console.Write($"WithLactose: {WithLactose}");
        }
    }
}
