using Distributeur.Entities;
using Distributeur.Services;
using Distributeur.Services.Implementation;

var recipeRepository = new RecipeRepository();
var drinkOrder = new DrinkOrderRepository(recipeRepository);

while (true)

{
    Console.WriteLine("Bienvenue au distributeur automatique de boissons chaudes !");


    Console.WriteLine("Choisissez une option :");
    Console.WriteLine("1. Espresso");
    Console.WriteLine("2. Allongé");
    Console.WriteLine("3. Cappuccino");
    Console.WriteLine("4. Chocolat");
    Console.WriteLine("5. Thé");
    Console.WriteLine("0. Quitter");
    Console.Write("Saisissez le nom de la boisson que vous souhaitez commander : ");
    string option = Console.ReadLine();

    if (option.Equals("0"))
    {
        Console.WriteLine("Merci d'utiliser la Machine Distributrice de Boissons Chaudes. Au revoir !");
    }
    else if (int.TryParse(option, out int selectedOption))
    {
        switch (selectedOption)
        {
            case 1:
                DisplayDrinkPrice("Expresso", drinkOrder);
                break;
            case 2:
                DisplayDrinkPrice("Allongé", drinkOrder);
                break;
            case 3:
                DisplayDrinkPrice("Capuccino", drinkOrder);
                break;
            case 4:
                DisplayDrinkPrice("Chocolat", drinkOrder);
                break;
            case 5:
                DisplayDrinkPrice("The", drinkOrder);
                break;
            default:
                Console.WriteLine("Option non reconnue. Veuillez saisir une option valide.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Veuillez saisir un numéro valide.");
    }


    static void DisplayDrinkPrice(string drinkName, IDrinkOrderRepository drinkOrder)
    {
        var order = new Order { DrinkName = drinkName };

        try
        {
            decimal price = drinkOrder.GetDrinkPrice(order);
            Console.WriteLine($"Le prix de {drinkName} est : {price:C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
    }

}