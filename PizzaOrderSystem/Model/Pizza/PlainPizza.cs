namespace PizzaOrderSystem.Model.Pizza
{
    public class PlainPizza : IMenuItem
    {
        string _name = "プレーンピザ";
        int _price = 1200;

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
