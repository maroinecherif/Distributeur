using Distributeur.Entities;

namespace Distributeur.Services.Implementation
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly List<Recipe> _recipes;
        private static readonly Ingredient coffee = new Ingredient { Name = "Coffee", PricePerDose = 1.0m };
        private static readonly Ingredient sugar = new Ingredient { Name = "Sugar", PricePerDose = 0.1m };
        private static readonly Ingredient cream = new Ingredient { Name = "Cream", PricePerDose = 0.5m };
        private static readonly Ingredient tea = new Ingredient { Name = "Tea", PricePerDose = 2.0m };
        private static readonly Ingredient water = new Ingredient { Name = "Water", PricePerDose = 0.2m };
        private static readonly Ingredient chocolate = new Ingredient { Name = "Chocolate", PricePerDose = 1.0m };
        private static readonly Ingredient milk = new Ingredient { Name = "Milk", PricePerDose = 0.4m };
        public RecipeRepository()
        {
            _recipes = new List<Recipe>
            {
                new Recipe { Name = "Expresso", Ingredients = new Dictionary<Ingredient, int> { { coffee, 1 }, { water, 1 } } },
                new Recipe { Name = "Allongé", Ingredients = new Dictionary<Ingredient, int> { { coffee, 1 }, { water, 2 } } },
                new Recipe { Name = "Capuccino", Ingredients = new Dictionary<Ingredient, int> { { coffee, 1 }, { chocolate, 1 }, { water, 1 }, { cream, 1 } } },
                new Recipe { Name = "Chocolat", Ingredients = new Dictionary<Ingredient, int> { { chocolate, 3 }, { milk, 2 }, { water, 1 }, { sugar, 1 } } },
                new Recipe { Name = "The", Ingredients = new Dictionary<Ingredient, int> { { tea, 1 }, { water, 2 } } }
            };
        }

        public Recipe GetRecipeByName(string name)
        {
            return _recipes.Find(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public List<Recipe> Recipes => _recipes;
        //public Task AddRecipeAsync(Recipe recipe)
        //{
        //    RecipeList.Add(recipe);
        //    return Task.CompletedTask;
        //}
    }
}
