using Distributeur.Entities;

namespace Distributeur.Services
{
    public interface IRecipeRepository
    {
        Recipe GetRecipeByName(string name);
        // Task AddRecipeAsync(Recipe recipe);
    }
}
