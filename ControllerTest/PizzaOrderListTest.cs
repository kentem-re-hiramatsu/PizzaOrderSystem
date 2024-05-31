using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderSystem.Controller;
using PizzaOrderSystem.Model.Pizza;
using PizzaOrderSystem.Model.Topping;

namespace ControllerTest
{
    [TestClass]
    public class PizzaOrderListTest
    {
        PizzaOrderManagement pizzaOrderMana = new PizzaOrderManagement();
        ToppingOrderManagement toppingOrderMana = new ToppingOrderManagement();

        [TestMethod]
        public void AddPizzaOrderListTest()
        {
            var listCount = pizzaOrderMana.GetPizzaOrderListCount();
            Assert.AreEqual(listCount, 0);

            pizzaOrderMana.AddPizzaOrderList(toppingOrderMana);
            pizzaOrderMana.AddPizzaOrderList(toppingOrderMana);

            listCount = pizzaOrderMana.GetPizzaOrderListCount();
            Assert.AreEqual(listCount, 2);
        }

        [TestMethod]
        public void RemovePizzaOrderListTest()
        {
            pizzaOrderMana.AddPizzaOrderList(toppingOrderMana);
            pizzaOrderMana.AddPizzaOrderList(toppingOrderMana);

            var listCount = pizzaOrderMana.GetPizzaOrderListCount();
            Assert.AreEqual(listCount, 2);

            pizzaOrderMana.RemovePizzaOrderList(1);
            listCount = pizzaOrderMana.GetPizzaOrderListCount();
            Assert.AreEqual(listCount, 1);
        }

        [TestMethod]
        public void PizzaTotalPricetTest()
        {
            toppingOrderMana.AddToppingOrderList(new PlainPizza());
            toppingOrderMana.AddToppingOrderList(new Tuna());
            toppingOrderMana.AddToppingOrderList(new Basil());

            pizzaOrderMana.AddPizzaOrderList(toppingOrderMana);

            var PizzaMenuTotalPrice = pizzaOrderMana.GetCalculatePizzaTotalPrice();

            var pizzaPrice = new PlainPizza().GetPrice();
            var tunaPrice = new Tuna().GetPrice();
            var basilPrice = new Basil().GetPrice();

            var TotalPrice = pizzaPrice + tunaPrice + basilPrice;

            Assert.AreEqual(PizzaMenuTotalPrice, TotalPrice);
        }
    }
}
