namespace Models.Topping
{
    public abstract class ToppingMenu : IMenuItem
    {
        protected string _name;
        protected int _price;

        public string Name { get { return _name; } }
        public int Price { get { return _price; } }
    }
}
