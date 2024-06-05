using Models.Topping;

namespace Models.Pizza
{
    public class MargheritaPizza : PizzaMenu
    {
        public MargheritaPizza()
        {
            _name = "マルゲリータピザ";
            _price = 1500;
            SetDefaultTopping();
        }

        public override void SetDefaultTopping()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new Tomato(0));
            _defaultToppingList.Add(new MozzarellaCheese(0));
            _defaultToppingList.Add(new Basil(0));
        }
    }
}
