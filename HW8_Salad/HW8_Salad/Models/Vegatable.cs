using HW8_Salad.Models.Abstracts;

namespace HW8_Salad.Models
{
    public class Vegatable : Ingredient
    {
        public bool IsEdibleRaw { get; set; }
        public Vegatable(string name, double calories, decimal price, bool isEdibleRaw) : base(name, calories, price)
        {
            IsEdibleRaw = isEdibleRaw;
        }

        public override void ShowIngredients()
        {
            base.ShowIngredients();
            Console.Write($"IsEdibleRaw: {IsEdibleRaw}");
        }
    }
}
