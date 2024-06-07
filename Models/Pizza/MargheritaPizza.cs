using Models.Topping;

namespace Models.Pizza
{
    public class MargheritaPizza : PizzaMenu
    {
        const string NAME = "マルゲリータピザ";
        const int DEFAULTPRICE = 1500;

        public MargheritaPizza() : base()
        {
            _name = NAME;
            _price = DEFAULTPRICE;
        }

        protected override void SetDefaultTopping()
        {
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new Tomato(0));
            _toppingList.Add(new MozzarellaCheese(0));
            _toppingList.Add(new Basil(0));
        }
    }
}
