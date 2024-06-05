namespace Models.Pizza
{
    public abstract class PizzaMenu : IMenuItem
    {
        public abstract string Name { get; }
        public abstract int Price { get; }
        public abstract int GetCountDefaultToppingList();
        public abstract IMenuItem GetDefaultTopping(int index);
    }
}
