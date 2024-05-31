using PizzaOrderSystem.Model.Pizza;

namespace PizzaOrderSystem.Model.Topping
{
    public abstract class Topping : IMenuItem
    {
        public abstract int GetPrice();
        public abstract string GetName();
        public void SetCalculatePezza()
        {
        }
    }
}
