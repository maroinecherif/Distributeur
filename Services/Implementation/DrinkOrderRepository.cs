using Distributeur.Entities;

namespace Distributeur.Services.Implementation
{
    public class DrinkOrderRepository : IDrinkOrderRepository
    {
        private readonly IRecipeRepository _recipeRepository;

        public DrinkOrderRepository(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public decimal GetDrinkPrice(Order order)
        {
            Recipe recipe = _recipeRepository.GetRecipeByName(order.DrinkName);
            if (recipe == null)
            {
                throw new InvalidOperationException("Recipe not found");
            }

            decimal costPrice = CalculateCostPrice(recipe);
            decimal sellingPrice = costPrice * 1.3m; // 30% margin

            return sellingPrice;
        }

        private decimal CalculateCostPrice(Recipe recipe)
        {
            decimal costPrice = 0;

            foreach (var ingredient in recipe.Ingredients)
            {
                costPrice += ingredient.Key.PricePerDose * ingredient.Value;
            }

            return costPrice;
        }
    }
}
