namespace PizzaOrderSystem.Model.Topping
{
    public class Corn : Topping
    {
        private string _name = "コーン";
        private int _price = 250;

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
