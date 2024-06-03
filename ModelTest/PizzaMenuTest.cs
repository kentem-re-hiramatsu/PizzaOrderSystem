using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderSystem.Enum;
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

            Assert.AreEqual(PizzaEnum.プレーンピザ, plainPizza.GetName());
            Assert.AreEqual(1200, plainPizza.GetPrice());
            Assert.AreEqual(2, plainPizza.GetCountDefaultToppingList());

            Assert.AreEqual(PizzaEnum.チーズ, plainPizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, plainPizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual(PizzaEnum.トマト, plainPizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, plainPizza.GetDefaultTopping(1).GetPrice());
        }

        [TestMethod]
        public void MargheritaPizzaTest()
        {
            var margheritaPizza = new MargheritaPizza();

            Assert.AreEqual(PizzaEnum.マルゲリータピザ, margheritaPizza.GetName());
            Assert.AreEqual(1500, margheritaPizza.GetPrice());
            Assert.AreEqual(4, margheritaPizza.GetCountDefaultToppingList());

            Assert.AreEqual(PizzaEnum.チーズ, margheritaPizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual(PizzaEnum.トマト, margheritaPizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(1).GetPrice());

            Assert.AreEqual(PizzaEnum.モッツァレラチーズ, margheritaPizza.GetDefaultTopping(2).GetName());
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(2).GetPrice());

            Assert.AreEqual(PizzaEnum.バジル, margheritaPizza.GetDefaultTopping(3).GetName());
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(3).GetPrice());
        }

        [TestMethod]
        public void SeafoodPizzaTest()
        {
            var seafoodPizza = new SeafoodPizza();

            Assert.AreEqual(PizzaEnum.シーフードピザ, seafoodPizza.GetName());
            Assert.AreEqual(1400, seafoodPizza.GetPrice());
            Assert.AreEqual(2, seafoodPizza.GetCountDefaultToppingList());

            Assert.AreEqual(PizzaEnum.チーズ, seafoodPizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, seafoodPizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual(PizzaEnum.シーフードミックス, seafoodPizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, seafoodPizza.GetDefaultTopping(1).GetPrice());
        }

        [TestMethod]
        public void PescaTorePizzaTest()
        {
            var pescaTorePizza = new PescaTorePizza();

            Assert.AreEqual(PizzaEnum.ペスカトーレピザ, pescaTorePizza.GetName());
            Assert.AreEqual(1800, pescaTorePizza.GetPrice());
            Assert.AreEqual(3, pescaTorePizza.GetCountDefaultToppingList());

            Assert.AreEqual(PizzaEnum.チーズ, pescaTorePizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, pescaTorePizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual(PizzaEnum.シーフードミックス, pescaTorePizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, pescaTorePizza.GetDefaultTopping(1).GetPrice());

            Assert.AreEqual(PizzaEnum.ホタテ, pescaTorePizza.GetDefaultTopping(2).GetName());
            Assert.AreEqual(0, pescaTorePizza.GetDefaultTopping(2).GetPrice());
        }

        [TestMethod]
        public void BambinoPizzaTest()
        {
            var bambinoPizza = new BambinoPizza();

            Assert.AreEqual(PizzaEnum.バンビーノピザ, bambinoPizza.GetName());
            Assert.AreEqual(1600, bambinoPizza.GetPrice());
            Assert.AreEqual(5, bambinoPizza.GetCountDefaultToppingList());

            Assert.AreEqual(PizzaEnum.チーズ, bambinoPizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual(PizzaEnum.トマト, bambinoPizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(1).GetPrice());

            Assert.AreEqual(PizzaEnum.ツナ, bambinoPizza.GetDefaultTopping(2).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(2).GetPrice());

            Assert.AreEqual(PizzaEnum.コーン, bambinoPizza.GetDefaultTopping(3).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(3).GetPrice());

            Assert.AreEqual(PizzaEnum.ベーコン, bambinoPizza.GetDefaultTopping(4).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(4).GetPrice());
        }
    }
}
