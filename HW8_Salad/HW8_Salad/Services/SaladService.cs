using HW8_Salad.Models.Abstracts;
using HW8_Salad.Services.Abstracts;

namespace HW8_Salad.Services
{
    public class SaladService : ISaladService
    {

        protected List<Ingredient> salad;
        public SaladService()
        {
            salad = new List<Ingredient>();

        }
        public void AddIgredient(Ingredient ingredient)
        {
            salad.Add(ingredient);
        }

        public double CalculateCalories()
        {
            double calories = 0;

            foreach (var ingredient in salad)
            {
                calories += ingredient.Calories;
            }

            return calories;
        }

        public List<Ingredient> FindByCriteries(Func<Ingredient, bool> func)
        {
            return salad.Where(func).ToList();
        }

        public void SortByParametr()
        {

            salad = salad.OrderBy(x => x.Price).ToList();
        }

        public void SaladContain()
        {
            foreach (var item in salad)
            {
                item.ShowIngredients();
                Console.WriteLine();
            }
        }

    }
}
