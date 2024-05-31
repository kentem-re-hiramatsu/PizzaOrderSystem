namespace PizzaOrderSystem.Model.Pizza
{
    public class SeafoodPizza : IMenuItem
    {
        string _name = "シーフードピザ";
        int _price = 1400;

        public int GetPrice()
        {
            return _price;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetCalculatePezza()
        {

        }
    }
}
