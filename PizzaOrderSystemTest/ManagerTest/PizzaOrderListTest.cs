using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Manager;
using Models.Pizza;
using Models.Topping;

namespace PizzaOrderSystemTest.ManagerTest
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

            var pizzaPrice = new PlainPizza().Price;
            var tunaPrice = new Tuna().Price;
            var basilPrice = new Basil().Price;

            var TotalPrice = pizzaPrice + tunaPrice + basilPrice;

            Assert.AreEqual(PizzaMenuTotalPrice, TotalPrice);
        }
    }
}
