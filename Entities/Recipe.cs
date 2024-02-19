namespace Distributeur.Entities
{
    public class Recipe
    {
        public string Name { get; set; }
        public Dictionary<Ingredient, int> Ingredients { get; set; }
    }
}
