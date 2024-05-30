namespace PizzaOrderSystem.Model.Topping
{
    public class Scallops : Topping
    {
        private string _name = "ホタテ";
        private int _price = 500;

        public override string GetName()
        {
            return _name;
        }

        public override int GetPrice()
        {
            return _price;
        }
    }
}
