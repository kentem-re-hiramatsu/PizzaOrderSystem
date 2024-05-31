namespace PizzaOrderSystem.Model.Pizza
{
    public class MargheritaPizza : IMenuItem
    {
        string _name = "マルゲリータピザ";
        int _price = 1500;

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
