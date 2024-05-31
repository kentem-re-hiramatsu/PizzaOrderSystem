using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderSystem.Model.Pizza;
namespace ModelTest
{
    [TestClass]
    public class PizzaMenuTest
    {
        [TestMethod]
        public void PlainPizzaTest()
        {
            var plainPizza = new PlainPizza();

            Assert.AreEqual(plainPizza.GetName(), "プレーンピザ");
            Assert.AreEqual(plainPizza.GetPrice(), 1200);
            Assert.AreEqual(plainPizza.GetCountDefaultToppingList(), 2);
        }

        [TestMethod]
        public void MargheritaPizzaTest()
        {
            var margheritaPizza = new MargheritaPizza();

            Assert.AreEqual(margheritaPizza.GetName(), "マルゲリータピザ");
            Assert.AreEqual(margheritaPizza.GetPrice(), 1500);
            Assert.AreEqual(margheritaPizza.GetCountDefaultToppingList(), 4);
        }

        [TestMethod]
        public void SeafoodPizzaTest()
        {
            var seafoodPizza = new SeafoodPizza();

            Assert.AreEqual(seafoodPizza.GetName(), "シーフードピザ");
            Assert.AreEqual(seafoodPizza.GetPrice(), 1400);
            Assert.AreEqual(seafoodPizza.GetCountDefaultToppingList(), 2);
        }

        [TestMethod]
        public void PescaTorePizzaTest()
        {
            var pescaTorePizza = new PescaTorePizza();

            Assert.AreEqual(pescaTorePizza.GetName(), "ペスカトーレピザ");
            Assert.AreEqual(pescaTorePizza.GetPrice(), 1800);
            Assert.AreEqual(pescaTorePizza.GetCountDefaultToppingList(), 3);
        }

        [TestMethod]
        public void BambinoPizzaTest()
        {
            var bambinoPizza = new BambinoPizza();

            Assert.AreEqual(bambinoPizza.GetName(), "バンビーノピザ");
            Assert.AreEqual(bambinoPizza.GetPrice(), 1600);
            Assert.AreEqual(bambinoPizza.GetCountDefaultToppingList(), 5);
        }

    }
}
