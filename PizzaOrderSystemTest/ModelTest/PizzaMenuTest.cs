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

            Assert.AreEqual("プレーンピザ", plainPizza.Name);
            Assert.AreEqual(1200, plainPizza.Price);
            Assert.AreEqual(2, plainPizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", plainPizza.GetDefaultTopping(0).Name);
            Assert.AreEqual(0, plainPizza.GetDefaultTopping(0).Price);

            Assert.AreEqual("トマト", plainPizza.GetDefaultTopping(1).Name);
            Assert.AreEqual(0, plainPizza.GetDefaultTopping(1).Price);
        }

        [TestMethod]
        public void MargheritaPizzaTest()
        {
            var margheritaPizza = new MargheritaPizza();

            Assert.AreEqual("マルゲリータピザ", margheritaPizza.Name);
            Assert.AreEqual(1500, margheritaPizza.Price);
            Assert.AreEqual(4, margheritaPizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", margheritaPizza.GetDefaultTopping(0).Name);
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(0).Price);

            Assert.AreEqual("トマト", margheritaPizza.GetDefaultTopping(1).Name);
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(1).Price);

            Assert.AreEqual("モッツァレラチーズ", margheritaPizza.GetDefaultTopping(2).Name);
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(2).Price);

            Assert.AreEqual("バジル", margheritaPizza.GetDefaultTopping(3).Name);
            Assert.AreEqual(0, margheritaPizza.GetDefaultTopping(3).Price);
        }

        [TestMethod]
        public void SeafoodPizzaTest()
        {
            var seafoodPizza = new SeafoodPizza();

            Assert.AreEqual("シーフードピザ", seafoodPizza.Name);
            Assert.AreEqual(1400, seafoodPizza.Price);
            Assert.AreEqual(2, seafoodPizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", seafoodPizza.GetDefaultTopping(0).Name);
            Assert.AreEqual(0, seafoodPizza.GetDefaultTopping(0).Price);

            Assert.AreEqual("シーフードミックス", seafoodPizza.GetDefaultTopping(1).Name);
            Assert.AreEqual(0, seafoodPizza.GetDefaultTopping(1).Price);
        }

        [TestMethod]
        public void PescaTorePizzaTest()
        {
            var pescaTorePizza = new PescaTorePizza();

            Assert.AreEqual("ペスカトーレピザ", pescaTorePizza.Name);
            Assert.AreEqual(1800, pescaTorePizza.Price);
            Assert.AreEqual(3, pescaTorePizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", pescaTorePizza.GetDefaultTopping(0).Name);
            Assert.AreEqual(0, pescaTorePizza.GetDefaultTopping(0).Price);

            Assert.AreEqual("シーフードミックス", pescaTorePizza.GetDefaultTopping(1).Name);
            Assert.AreEqual(0, pescaTorePizza.GetDefaultTopping(1).Price);

            Assert.AreEqual("ホタテ", pescaTorePizza.GetDefaultTopping(2).Name);
            Assert.AreEqual(0, pescaTorePizza.GetDefaultTopping(2).Price);
        }

        [TestMethod]
        public void BambinoPizzaTest()
        {
            var bambinoPizza = new BambinoPizza();

            Assert.AreEqual("バンビーノピザ", bambinoPizza.Name);
            Assert.AreEqual(1600, bambinoPizza.Price);
            Assert.AreEqual(5, bambinoPizza.GetCountDefaultToppingList());

            Assert.AreEqual("チーズ", bambinoPizza.GetDefaultTopping(0).Name);
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(0).Price);

            Assert.AreEqual("トマト", bambinoPizza.GetDefaultTopping(1).Name);
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(1).Price);

            Assert.AreEqual("ツナ", bambinoPizza.GetDefaultTopping(2).Name);
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(2).Price);

            Assert.AreEqual("コーン", bambinoPizza.GetDefaultTopping(3).Name);
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(3).Price);

            Assert.AreEqual("ベーコン", bambinoPizza.GetDefaultTopping(4).Name);
            Assert.AreEqual(0, bambinoPizza.GetDefaultTopping(4).Price);
        }
    }
}
