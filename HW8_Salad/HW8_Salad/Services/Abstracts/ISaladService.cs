using HW8_Salad.Models.Abstracts;

namespace HW8_Salad.Services.Abstracts
{
    public interface ISaladService
    {
        public void AddIgredient(Ingredient ingredient);
        public double CalculateCalories();
        public void SortByParametr();
        public List<Ingredient> FindByCriteries(Func<Ingredient, bool> func);
        public void SaladContain();

    }
}
