using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Pizza;

namespace PizzaOrderSystemTest
{
    [TestClass]
    public class PizzaMenuTest
    {
        [TestMethod]
        public void PlainPizzaTest()
        {
            var plainPizza = new PlainPizza();

            Assert.AreEqual("プレーンピザ", plainPizza.GetName());
            Assert.AreEqual(1200, plainPizza.GetPrice());
            Assert.AreEqual(2, plainPizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", plainPizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, plainPizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual("トマト", plainPizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, plainPizza.GetDefaultTopping(1).GetPrice());
        }

        [TestMethod]
        public void MargheritaPizzaTest()
        {
            var margheritaPizza = new MargheritaPizza();

            Assert.AreEqual("マルゲリータピザ", margheritaPizza.GetName());
            Assert.AreEqual(1500, margheritaPizza.GetPrice());
            Assert.AreEqual(4, margheritaPizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", margheritaPizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual("トマト", margheritaPizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(1).GetPrice());

            Assert.AreEqual("モッツァレラチーズ", margheritaPizza.GetDefaultTopping(2).GetName());
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(2).GetPrice());

            Assert.AreEqual("バジル", margheritaPizza.GetDefaultTopping(3).GetName());
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(3).GetPrice());
        }

        [TestMethod]
        public void SeafoodPizzaTest()
        {
            var seafoodPizza = new SeafoodPizza();

            Assert.AreEqual("シーフードピザ", seafoodPizza.GetName());
            Assert.AreEqual(1400, seafoodPizza.GetPrice());
            Assert.AreEqual(2, seafoodPizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", seafoodPizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, seafoodPizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual("シーフードミックス", seafoodPizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, seafoodPizza.GetDefaultTopping(1).GetPrice());
        }

        [TestMethod]
        public void PescaTorePizzaTest()
        {
            var pescaTorePizza = new PescaTorePizza();

            Assert.AreEqual("ペスカトーレピザ", pescaTorePizza.GetName());
            Assert.AreEqual(1800, pescaTorePizza.GetPrice());
            Assert.AreEqual(3, pescaTorePizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", pescaTorePizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, pescaTorePizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual("シーフードミックス", pescaTorePizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, pescaTorePizza.GetDefaultTopping(1).GetPrice());

            Assert.AreEqual("ホタテ", pescaTorePizza.GetDefaultTopping(2).GetName());
            Assert.AreEqual(0, pescaTorePizza.GetDefaultTopping(2).GetPrice());
        }

        [TestMethod]
        public void BambinoPizzaTest()
        {
            var bambinoPizza = new BambinoPizza();

            Assert.AreEqual("バンビーノピザ", bambinoPizza.GetName());
            Assert.AreEqual(1600, bambinoPizza.GetPrice());
            Assert.AreEqual(5, bambinoPizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", bambinoPizza.GetDefaultTopping(0).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(0).GetPrice());

            Assert.AreEqual("トマト", bambinoPizza.GetDefaultTopping(1).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(1).GetPrice());

            Assert.AreEqual("ツナ", bambinoPizza.GetDefaultTopping(2).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(2).GetPrice());

            Assert.AreEqual("コーン", bambinoPizza.GetDefaultTopping(3).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(3).GetPrice());

            Assert.AreEqual("ベーコン", bambinoPizza.GetDefaultTopping(4).GetName());
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(4).GetPrice());
        }
    }
}
