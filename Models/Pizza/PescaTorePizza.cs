using Models.Topping;

namespace Models.Pizza
{
    public class PescaTorePizza : PizzaMenu
    {
        public PescaTorePizza()
        {
            _name = "ペスカトーレピザ";
            _price = 1800;
            SetDefaultTopping();
        }

        public override void SetDefaultTopping()
        {
            _defaultToppingList.Add(new Cheese(0));
            _defaultToppingList.Add(new SeafoodMix(0));
            _defaultToppingList.Add(new Scallops(0));
        }
    }
}
