namespace Models.Topping
{
    public abstract class ToppingMenu : IMenuItem
    {
        public abstract string Name { get; }
        public abstract int Price { get; }
    }
}
