namespace Models.Topping
{
    public abstract class ToppingMenu : IMenuItem
    {
        public abstract int GetPrice();
        public abstract string GetName();
    }
}
