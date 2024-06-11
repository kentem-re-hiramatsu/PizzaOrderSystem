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

        [TestMethod]
        public void AddPizzaOrderListTest()
        {
            var listCount = pizzaOrderMana.PizzaOrderList.Count;
            Assert.AreEqual(listCount, 0);

            pizzaOrderMana.AddPizzaOrderList(new PlainPizza());
            pizzaOrderMana.AddPizzaOrderList(new SeafoodMix());

            listCount = pizzaOrderMana.PizzaOrderList.Count;

            Assert.AreEqual(listCount, 2);
            Assert.AreEqual(pizzaOrderMana.GetPizzaOrder(0).Name, new PlainPizza().Name);
            Assert.AreEqual(pizzaOrderMana.GetPizzaOrder(1).Name, new SeafoodMix().Name);
        }

        [TestMethod]
        public void RemovePizzaOrderListTest()
        {
            pizzaOrderMana.AddPizzaOrderList(new PlainPizza());
            pizzaOrderMana.AddPizzaOrderList(new SeafoodMix());

            var listCount = pizzaOrderMana.PizzaOrderList.Count;
            Assert.AreEqual(listCount, 2);

            pizzaOrderMana.RemovePizzaOrderList(1);
            listCount = pizzaOrderMana.PizzaOrderList.Count;

            Assert.AreEqual(listCount, 1);
            Assert.AreEqual(pizzaOrderMana.GetPizzaOrder(0).Name, new PlainPizza().Name);
        }

        [TestMethod]
        public void PizzaTotalPricetTest()
        {
            var plainPizza = new PlainPizza();
            plainPizza.SetTopping(new Tuna());
            plainPizza.SetTopping(new Basil());
            pizzaOrderMana.AddPizzaOrderList(plainPizza);

            var PizzaMenuTotalPrice = pizzaOrderMana.GetTotalPrice();

            var pizzaPrice = new PlainPizza().Price;
            var tunaPrice = new Tuna().Price;
            var basilPrice = new Basil().Price;

            var TotalPrice = pizzaPrice + tunaPrice + basilPrice;

            Assert.AreEqual(PizzaMenuTotalPrice, TotalPrice);
        }

        [TestMethod]
        public void PizzaMenuListTest()
        {
            var count = pizzaOrderMana.PizzaMenuList.Count;

            Assert.AreEqual(count, 5);

            Assert.AreEqual(pizzaOrderMana.GetPizzaMenu(0).Name, new PlainPizza().Name);
            Assert.AreEqual(pizzaOrderMana.GetPizzaMenu(1).Name, new MargheritaPizza().Name);
            Assert.AreEqual(pizzaOrderMana.GetPizzaMenu(2).Name, new SeafoodPizza().Name);
            Assert.AreEqual(pizzaOrderMana.GetPizzaMenu(3).Name, new PescaTorePizza().Name);
            Assert.AreEqual(pizzaOrderMana.GetPizzaMenu(4).Name, new BambinoPizza().Name);
        }

        [TestMethod]
        public void ToppingMenuListTest()
        {
            var count = pizzaOrderMana.ToppingMenuList.Count;

            Assert.AreEqual(count, 10);

            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(0).Name, new Cheese().Name);
            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(1).Name, new FriedGarlic().Name);
            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(2).Name, new MozzarellaCheese().Name);
            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(3).Name, new SeafoodMix().Name);
            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(4).Name, new Scallops().Name);
            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(5).Name, new Basil().Name);
            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(6).Name, new Tomato().Name);
            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(7).Name, new Tuna().Name);
            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(8).Name, new Corn().Name);
            Assert.AreEqual(pizzaOrderMana.GetToppingMenu(9).Name, new Bacon().Name);
        }

        [TestMethod]
        public void GetPizzaMenuIndexTest()
        {
            int pizzaIndex = pizzaOrderMana.GetPizzaMenuIndex("プレーンピザ");
            Assert.AreEqual(0, pizzaIndex);

            pizzaIndex = pizzaOrderMana.GetPizzaMenuIndex("バンビーノピザ");
            Assert.AreEqual(4, pizzaIndex);
        }

        [TestMethod]
        public void GetToppingMenuIndexTest()
        {
            int topping = pizzaOrderMana.GetToppingMenuIndex("チーズ");
            Assert.AreEqual(0, topping);

            topping = pizzaOrderMana.GetToppingMenuIndex("ベーコン");
            Assert.AreEqual(9, topping);
        }

        [TestMethod]
        public void PizzaChangedTest()
        {
            var beforePlainPizza = new PlainPizza();
            beforePlainPizza.SetTopping(new Bacon());
            beforePlainPizza.SetTopping(new Corn());

            pizzaOrderMana.AddPizzaOrderList(beforePlainPizza);
            Assert.AreEqual(((PizzaMenu)pizzaOrderMana.GetPizzaOrder(0)).GetTopping(2).Name, new Bacon().Name);
            Assert.AreEqual(((PizzaMenu)pizzaOrderMana.GetPizzaOrder(0)).GetTopping(3).Name, new Corn().Name);

            var aftrerPlainPizza = new PlainPizza();
            aftrerPlainPizza.SetTopping(new Bacon());
            aftrerPlainPizza.SetTopping(new SeafoodMix());
            pizzaOrderMana.ChangePizza(0, aftrerPlainPizza);

            Assert.AreEqual(((PizzaMenu)pizzaOrderMana.GetPizzaOrder(0)).GetTopping(2).Name, new Bacon().Name);
            Assert.AreEqual(((PizzaMenu)pizzaOrderMana.GetPizzaOrder(0)).GetTopping(3).Name, new SeafoodMix().Name);
        }

    }
}
