using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderSystem.Controller;
using PizzaOrderSystem.Model.Pizza;
using PizzaOrderSystem.Model.Topping;

namespace ControllerTest
{
    [TestClass]
    public class AppendToppingListTest
    {
        ToppingOrderManagement toppingOrderMana = new ToppingOrderManagement();

        [TestMethod]
        public void AddToppingListTest()
        {
            var listCount = toppingOrderMana.GetToppingOrderListCount();
            Assert.AreEqual(listCount, 0);

            toppingOrderMana.AddToppingOrderList(new Tomato());
            toppingOrderMana.AddToppingOrderList(new Bacon());

            listCount = toppingOrderMana.GetToppingOrderListCount();
            Assert.AreEqual(listCount, 2);
        }

        [TestMethod]
        public void RemovePizzaOrderListTest()
        {
            toppingOrderMana.AddToppingOrderList(new Cheese());
            toppingOrderMana.AddToppingOrderList(new FriedGarlic());

            var listCount = toppingOrderMana.GetToppingOrderListCount();
            Assert.AreEqual(listCount, 2);

            toppingOrderMana.RemoveToppingOrderList(1);
            listCount = toppingOrderMana.GetToppingOrderListCount();
            Assert.AreEqual(listCount, 1);
        }

        [TestMethod]
        public void PizzaTotalPricetTest()
        {
            toppingOrderMana.AddToppingOrderList(new PlainPizza());
            toppingOrderMana.AddToppingOrderList(new Tuna());
            toppingOrderMana.AddToppingOrderList(new Basil());


            var PizzaMenuTotalPrice = toppingOrderMana.GetTotalToppingPrice();

            var pizzaPrice = new PlainPizza().GetPrice();
            var tunaPrice = new Tuna().GetPrice();
            var basilPrice = new Basil().GetPrice();

            var TotalPrice = pizzaPrice + tunaPrice + basilPrice;

            Assert.AreEqual(PizzaMenuTotalPrice, TotalPrice);
        }
    }
}
