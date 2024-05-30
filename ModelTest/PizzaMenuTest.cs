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
        }

        [TestMethod]
        public void MargheritaPizzaTest()
        {
            var margheritaPizza = new MargheritaPizza();

        }

        [TestMethod]
        public void SeafoodPizzaTest()
        {
            var seafoodPizza = new SeafoodPizza();
        }

        [TestMethod]
        public void PescaTorePizzaTest()
        {
            var pescaTorePizza = new PescaTorePizza();
        }

        [TestMethod]
        public void BambinoPizzaTest()
        {
            var bambinoPizza = new BambinoPizza();
        }
    }
}
