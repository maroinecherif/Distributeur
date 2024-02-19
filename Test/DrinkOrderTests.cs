using Distributeur.Entities;
using Distributeur.Services;
using Distributeur.Services.Implementation;
using Moq;
using NUnit.Framework;
using Xunit;


public class DrinkOrderTests
{
    [Fact]
    public void GetDrinkPrice_ShouldReturnCorrectPrice_ForKnownRecipe()
    {
        // Arrange
        var recipeRepositoryMock = new Mock<IRecipeRepository>();
        recipeRepositoryMock.Setup(r => r.GetRecipeByName(It.IsAny<string>())).Returns(GetMockRecipe("Espresso"));

        var drinkOrderInteractor = new DrinkOrderRepository(recipeRepositoryMock.Object);
        var order = new Order { DrinkName = "Espresso" };

        // Act
        decimal price = drinkOrderInteractor.GetDrinkPrice(order);

        // Assert
        Assert.Equals(1.3m, price);
    }
    private Recipe GetMockRecipe(string name)
    {
        return new Recipe
        {
            Name = name,
            Ingredients = new Dictionary<Ingredient, int>
            {
                { new Ingredient { Name = "Coffee", PricePerDose = 1.0m }, 1 },
                { new Ingredient { Name = "Water", PricePerDose = 0.2m }, 1 }
            }
        };
    }
}
