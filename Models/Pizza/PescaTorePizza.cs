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
            _toppingList.Add(new Cheese(0));
            _toppingList.Add(new SeafoodMix(0));
            _toppingList.Add(new Scallops(0));
        }
    }
}
