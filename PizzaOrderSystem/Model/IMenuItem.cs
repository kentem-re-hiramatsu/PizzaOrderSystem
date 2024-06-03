using PizzaOrderSystem.Enum;

namespace PizzaOrderSystem.Model.Pizza
{
    public interface IMenuItem
    {
        int GetPrice();
        PizzaEnum GetName();
    }
}
