using HW8_Salad.Models;
using HW8_Salad.Models.Abstracts;
using HW8_Salad.Services.Abstracts;

namespace HW8_Salad.Services
{
    public class App
    {
        private readonly ISaladService _saladService;
        public App(ISaladService saladService)
        {
            _saladService = saladService;
        }
        public void AppStart()
        {

            Ingredient _nut = new Nut("Кешю", 20, 30, "Твердий");

            Ingredient _sous = new Sous("Майонез", 40, 25, false);

            Ingredient _vegatable = new Vegatable("СалатАйзберг", 10, 20, true);

            Console.WriteLine("Salad have:");

            _saladService.AddIgredient(_nut);

            _saladService.AddIgredient(_sous);

            _saladService.AddIgredient(_vegatable);

            _saladService.SaladContain();

            Console.WriteLine($"Total calories: {_saladService.CalculateCalories()}grn.");

            List<Ingredient> parameter = _saladService.FindByCriteries(x => x.Calories <= 20);

            Console.WriteLine($"Sort ingredients by price");

            _saladService.SortByParametr();

            _saladService.SaladContain();

            Console.WriteLine($"Find ingredients by Callories <= 20:");

            foreach (var parameterItem in parameter)
            {
                parameterItem.ShowIngredients();
                Console.WriteLine();
            }

        }
    }
}
