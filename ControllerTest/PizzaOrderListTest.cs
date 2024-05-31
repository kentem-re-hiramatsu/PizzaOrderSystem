using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderSystem.Controller;
using PizzaOrderSystem.Model.Pizza;

namespace ControllerTest
{
    [TestClass]
    public class PizzaOrderListTest
    {
        PizzaOrderManagement pizzaorderMana = new PizzaOrderManagement();

        [TestMethod]
        public void AddPizzaOrderListTest()
        {
            var listCount = pizzaorderMana.GetPizzaOrderListCount();
            Assert.AreEqual(listCount, 0);

            pizzaorderMana.AddPizzaOrderList(new BambinoPizza());
            pizzaorderMana.AddPizzaOrderList(new MargheritaPizza());

            listCount = pizzaorderMana.GetPizzaOrderListCount();
            Assert.AreEqual(listCount, 2);
        }

        [TestMethod]
        public void RemovePizzaOrderListTest()
        {
            pizzaorderMana.AddPizzaOrderList(new BambinoPizza());
            pizzaorderMana.AddPizzaOrderList(new MargheritaPizza());

            var listCount = pizzaorderMana.GetPizzaOrderListCount();
            Assert.AreEqual(listCount, 2);

            pizzaorderMana.RemovePizzaOrderList(1);
            listCount = pizzaorderMana.GetPizzaOrderListCount();
            Assert.AreEqual(listCount, 1);
        }
    }
}
