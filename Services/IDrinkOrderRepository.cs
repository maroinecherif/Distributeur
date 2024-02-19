using Distributeur.Entities;

namespace Distributeur.Services
{
    public interface IDrinkOrderRepository
    {
        decimal GetDrinkPrice(Order order);
    }
}
