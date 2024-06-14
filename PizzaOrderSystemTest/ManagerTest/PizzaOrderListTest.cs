using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Models.Manager;
using Models.Pizza;
using Models.Topping;
using System.Collections.Generic;

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
            Assert.AreEqual(0, listCount);

            pizzaOrderMana.AddPizzaOrderList(new PlainPizza());
            pizzaOrderMana.AddPizzaOrderList(new SeafoodPizza());

            listCount = pizzaOrderMana.PizzaOrderList.Count;

            Assert.AreEqual(2, listCount);
            Assert.AreEqual(new PlainPizza().Name, pizzaOrderMana.GetPizzaOrder(0).Name);
            Assert.AreEqual(new SeafoodPizza().Name, pizzaOrderMana.GetPizzaOrder(1).Name);
        }

        [TestMethod]
        public void RemovePizzaOrderListTest()
        {
            pizzaOrderMana.AddPizzaOrderList(new PlainPizza());
            pizzaOrderMana.AddPizzaOrderList(new SeafoodPizza());

            var listCount = pizzaOrderMana.PizzaOrderList.Count;
            Assert.AreEqual(2, listCount);

            pizzaOrderMana.RemovePizzaOrderList(1);
            listCount = pizzaOrderMana.PizzaOrderList.Count;

            Assert.AreEqual(1, listCount:
                );
            Assert.AreEqual(new PlainPizza().Name, pizzaOrderMana.GetPizzaOrder(0).Name);
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

            Assert.AreEqual(TotalPrice, PizzaMenuTotalPrice);
        }

        [TestMethod]
        public void PizzaMenuListTest()
        {
            var count = pizzaOrderMana.PizzaMenuList.Count;

            Assert.AreEqual(5, count);

            Assert.AreEqual(new PlainPizza().Name, pizzaOrderMana.GetPizzaMenu(0).Name);
            Assert.AreEqual(new MargheritaPizza().Name, pizzaOrderMana.GetPizzaMenu(1).Name);
            Assert.AreEqual(new SeafoodPizza().Name, pizzaOrderMana.GetPizzaMenu(2).Name);
            Assert.AreEqual(new PescatorePizza().Name, pizzaOrderMana.GetPizzaMenu(3).Name);
            Assert.AreEqual(new BambinoPizza().Name, pizzaOrderMana.GetPizzaMenu(4).Name);
        }

        [TestMethod]
        public void ToppingMenuListTest()
        {
            var count = pizzaOrderMana.ToppingMenuList.Count;

            Assert.AreEqual(10, count);

            Assert.AreEqual(new Cheese().Name, pizzaOrderMana.GetToppingMenu(0).Name);
            Assert.AreEqual(new FriedGarlic().Name, pizzaOrderMana.GetToppingMenu(1).Name);
            Assert.AreEqual(new MozzarellaCheese().Name, pizzaOrderMana.GetToppingMenu(2).Name);
            Assert.AreEqual(new SeafoodMix().Name, pizzaOrderMana.GetToppingMenu(3).Name);
            Assert.AreEqual(new Scallops().Name, pizzaOrderMana.GetToppingMenu(4).Name);
            Assert.AreEqual(new Basil().Name, pizzaOrderMana.GetToppingMenu(5).Name);
            Assert.AreEqual(new Tomato().Name, pizzaOrderMana.GetToppingMenu(6).Name);
            Assert.AreEqual(new Tuna().Name, pizzaOrderMana.GetToppingMenu(7).Name);
            Assert.AreEqual(new Corn().Name, pizzaOrderMana.GetToppingMenu(8).Name);
            Assert.AreEqual(new Bacon().Name, pizzaOrderMana.GetToppingMenu(9).Name);
        }

        [TestMethod]
        public void GetPizzaMenuIndexTest()
        {
            int pizzaIndex = pizzaOrderMana.GetPizzaMenuIndex("プレーンピザ");
            Assert.AreEqual(0, pizzaIndex);

            pizzaIndex = pizzaOrderMana.GetPizzaMenuIndex("バンビーノピザ");
            Assert.AreEqual(4, pizzaIndex);

            pizzaIndex = pizzaOrderMana.GetPizzaMenuIndex("ピザハット");
            Assert.AreEqual(-1, pizzaIndex);
        }

        [TestMethod]
        public void GetToppingMenuIndexTest()
        {
            int topping = pizzaOrderMana.GetToppingMenuIndex("チーズ");
            Assert.AreEqual(0, topping);

            topping = pizzaOrderMana.GetToppingMenuIndex("ベーコン");
            Assert.AreEqual(9, topping);

            topping = pizzaOrderMana.GetToppingMenuIndex("バナナ");
            Assert.AreEqual(-1, topping);
        }

        [TestMethod]
        public void PizzaChangedTest()
        {
            var beforePlainPizza = new PlainPizza();
            beforePlainPizza.SetTopping(new Bacon());
            beforePlainPizza.SetTopping(new Corn());

            pizzaOrderMana.AddPizzaOrderList(beforePlainPizza);
            Assert.AreEqual(new Bacon().Name, pizzaOrderMana.GetPizzaOrder(0).GetTopping(2).Name);
            Assert.AreEqual(new Corn().Name, pizzaOrderMana.GetPizzaOrder(0).GetTopping(3).Name);

            var aftrerPlainPizza = new PlainPizza();
            aftrerPlainPizza.SetTopping(new Bacon());
            aftrerPlainPizza.SetTopping(new SeafoodMix());
            pizzaOrderMana.ChangePizza(0, aftrerPlainPizza);

            Assert.AreEqual(new Bacon().Name, pizzaOrderMana.GetPizzaOrder(0).GetTopping(2).Name);
            Assert.AreEqual(new SeafoodMix().Name, pizzaOrderMana.GetPizzaOrder(0).GetTopping(3).Name);
        }

        [TestMethod]
        public void PlainPizzaChangedTest()
        {
            var toppings = new List<int>
            {
                (int)ToppingEnum.チーズ,
                (int)ToppingEnum.トマト,
                (int)ToppingEnum.バジル,
                (int)ToppingEnum.モッツァレラチーズ,
            };

            var pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new MargheritaPizza().Name, pizzaInstance.Name);

            toppings.RemoveRange(2, 2);
            toppings.Add((int)ToppingEnum.シーフードミックス);

            pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new SeafoodPizza().Name, pizzaInstance.Name);

            toppings.Add((int)ToppingEnum.ホタテ);

            pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new PescatorePizza().Name, pizzaInstance.Name);

            toppings.RemoveRange(2, 2);
            toppings.Add((int)ToppingEnum.ツナ);
            toppings.Add((int)ToppingEnum.コーン);
            toppings.Add((int)ToppingEnum.ベーコン);

            pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new BambinoPizza().Name, pizzaInstance.Name);
        }

        [TestMethod]
        public void MargheritaPizzaChangedTest()
        {
            var toppings = new List<int>
            {
                (int)ToppingEnum.チーズ,
                (int)ToppingEnum.トマト,
                (int)ToppingEnum.バジル,
                (int)ToppingEnum.モッツァレラチーズ,
                (int)ToppingEnum.シーフードミックス,
            };

            var pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new MargheritaPizza().Name, pizzaInstance.Name);

            toppings.Add((int)ToppingEnum.ホタテ);

            pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new PescatorePizza().Name, pizzaInstance.Name);

            toppings.RemoveRange(4, 1);
            toppings.Add((int)ToppingEnum.ツナ);
            toppings.Add((int)ToppingEnum.コーン);
            toppings.Add((int)ToppingEnum.ベーコン);

            pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new BambinoPizza().Name, pizzaInstance.Name);
        }

        [TestMethod]
        public void SeafoodPizzaChangedTest()
        {
            var toppings = new List<int>
            {
                (int)ToppingEnum.チーズ,
                (int)ToppingEnum.シーフードミックス,
                (int)ToppingEnum.トマト,
                (int)ToppingEnum.モッツァレラチーズ,
                (int)ToppingEnum.バジル,
            };

            var pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new MargheritaPizza().Name, pizzaInstance.Name);

            toppings.RemoveRange(2, 3);
            toppings.Add((int)ToppingEnum.ホタテ);

            pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new PescatorePizza().Name, pizzaInstance.Name);

            toppings.RemoveRange(2, 1);
            toppings.Add((int)ToppingEnum.トマト);
            toppings.Add((int)ToppingEnum.ツナ);
            toppings.Add((int)ToppingEnum.コーン);
            toppings.Add((int)ToppingEnum.ベーコン);

            pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new BambinoPizza().Name, pizzaInstance.Name);
        }


        [TestMethod]
        public void PescaTorePizzaChangedTest()
        {
            var toppings = new List<int>
            {
                (int)ToppingEnum.チーズ,
                (int)ToppingEnum.シーフードミックス,
                (int)ToppingEnum.ホタテ,
                (int)ToppingEnum.トマト,
                (int)ToppingEnum.ツナ,
                (int)ToppingEnum.コーン,
                (int)ToppingEnum.ベーコン,
            };

            var pizzaInstance = pizzaOrderMana.ContainsSameTopping(toppings);
            Assert.AreEqual(new BambinoPizza().Name, pizzaInstance.Name);
        }
    }
}
