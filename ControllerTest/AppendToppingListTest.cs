using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderSystem.Controller;
using PizzaOrderSystem.Model.Pizza;

namespace ControllerTest
{
    [TestClass]
    public class AppendToppingListTest
    {
        PizzaOrderManagement pizzaorderMana = new PizzaOrderManagement();
        //appendToppingList
        [TestMethod]
        public void AddToppingListTest()
        {
            var listCount = pizzaorderMana.GetToppingOrderListCount();
            Assert.AreEqual(listCount, 0);

            pizzaorderMana.AddToppingOrderList(new BambinoPizza());
            pizzaorderMana.AddToppingOrderList(new MargheritaPizza());

            listCount = pizzaorderMana.GetToppingOrderListCount();
            Assert.AreEqual(listCount, 2);
        }

        [TestMethod]
        public void RemovePizzaOrderListTest()
        {
            pizzaorderMana.AddToppingOrderList(new BambinoPizza());
            pizzaorderMana.AddToppingOrderList(new MargheritaPizza());

            var listCount = pizzaorderMana.GetToppingOrderListCount();
            Assert.AreEqual(listCount, 2);

            pizzaorderMana.RemoveToppingOrderList(1);
            listCount = pizzaorderMana.GetToppingOrderListCount();
            Assert.AreEqual(listCount, 1);
        }
    }
}
