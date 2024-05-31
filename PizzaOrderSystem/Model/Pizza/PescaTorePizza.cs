namespace PizzaOrderSystem.Model.Pizza
{
    public class PescaTorePizza : IMenuItem
    {
        string _name = "ペスカトーレピザ";
        int _price = 1800;

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
