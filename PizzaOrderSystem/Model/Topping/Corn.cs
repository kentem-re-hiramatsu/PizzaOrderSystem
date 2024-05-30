namespace PizzaOrderSystem.Model.Topping
{
    public class Corn
    {
        private string _name = "コーン";
        private int _price = 250;

        public string GetName()
        {
            return _name;
        }

        public int GetPrice()
        {
            return _price;
        }
    }
}
