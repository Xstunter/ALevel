namespace HW8_Salad.Models.Abstracts
{
    public abstract class Ingredient
    {
        public string Name { get; set; }
        public double Calories { get; set; }
        public decimal Price { get; set; }
        public Ingredient(string name, double calories, decimal price)
        {
            Name = name;
            Calories = calories;
            Price = price;
        }
        public virtual void ShowIngredients()
        {
            Console.Write($"Name: {Name}, Calories: {Calories} cal., Price: {Price} grn. ");
        }
    }
    
    
}
