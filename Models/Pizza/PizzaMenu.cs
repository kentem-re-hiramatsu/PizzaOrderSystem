namespace Models.Pizza
{
    public abstract class PizzaMenu : IMenuItem
    {
        public abstract int GetPrice();
        public abstract string GetName();
    }
}
