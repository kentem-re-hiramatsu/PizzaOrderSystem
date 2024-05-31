namespace PizzaOrderSystem.Model.Pizza
{
    public class BambinoPizza : IMenuItem
    {
        string _name = "バンビーノピザ";
        int _price = 1600;

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
