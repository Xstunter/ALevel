using HW8_Salad.Models.Abstracts;

namespace HW8_Salad.Models
{
    public class Nut : Ingredient
    {
        public string Hardness { get; set; }
        public Nut(string name, double calories, decimal price, string hardness) : base(name, calories, price)
        {
            Hardness = hardness;
        }

        public override void ShowIngredients()
        {
            base.ShowIngredients();
            Console.Write($"Hardness: {Hardness}");
        }
    }
}
