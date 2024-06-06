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
            Assert.AreEqual(2, plainPizza.GetCountToppingList());

            Assert.AreEqual("チーズ", plainPizza.GetTopping(0).Name);
            Assert.AreEqual(0, plainPizza.GetTopping(0).Price);

            Assert.AreEqual("トマト", plainPizza.GetTopping(1).Name);
            Assert.AreEqual(0, plainPizza.GetTopping(1).Price);
        }

        [TestMethod]
        public void MargheritaPizzaTest()
        {
            var margheritaPizza = new MargheritaPizza();

            Assert.AreEqual("マルゲリータピザ", margheritaPizza.Name);
            Assert.AreEqual(1500, margheritaPizza.Price);
            Assert.AreEqual(4, margheritaPizza.GetCountToppingList());

            Assert.AreEqual("チーズ", margheritaPizza.GetTopping(0).Name);
            Assert.AreEqual(0, margheritaPizza.GetTopping(0).Price);

            Assert.AreEqual("トマト", margheritaPizza.GetTopping(1).Name);
            Assert.AreEqual(0, margheritaPizza.GetTopping(1).Price);

            Assert.AreEqual("モッツァレラチーズ", margheritaPizza.GetTopping(2).Name);
            Assert.AreEqual(0, margheritaPizza.GetTopping(2).Price);

            Assert.AreEqual("バジル", margheritaPizza.GetTopping(3).Name);
            Assert.AreEqual(0, margheritaPizza.GetTopping(3).Price);
        }

        [TestMethod]
        public void SeafoodPizzaTest()
        {
            var seafoodPizza = new SeafoodPizza();

            Assert.AreEqual("シーフードピザ", seafoodPizza.Name);
            Assert.AreEqual(1400, seafoodPizza.Price);
            Assert.AreEqual(2, seafoodPizza.GetCountToppingList());

            Assert.AreEqual("チーズ", seafoodPizza.GetTopping(0).Name);
            Assert.AreEqual(0, seafoodPizza.GetTopping(0).Price);

            Assert.AreEqual("シーフードミックス", seafoodPizza.GetTopping(1).Name);
            Assert.AreEqual(0, seafoodPizza.GetTopping(1).Price);
        }

        [TestMethod]
        public void PescaTorePizzaTest()
        {
            var pescaTorePizza = new PescaTorePizza();

            Assert.AreEqual("ペスカトーレピザ", pescaTorePizza.Name);
            Assert.AreEqual(1800, pescaTorePizza.Price);
            Assert.AreEqual(3, pescaTorePizza.GetCountToppingList());

            Assert.AreEqual("チーズ", pescaTorePizza.GetTopping(0).Name);
            Assert.AreEqual(0, pescaTorePizza.GetTopping(0).Price);

            Assert.AreEqual("シーフードミックス", pescaTorePizza.GetTopping(1).Name);
            Assert.AreEqual(0, pescaTorePizza.GetTopping(1).Price);

            Assert.AreEqual("ホタテ", pescaTorePizza.GetTopping(2).Name);
            Assert.AreEqual(0, pescaTorePizza.GetTopping(2).Price);
        }

        [TestMethod]
        public void BambinoPizzaTest()
        {
            var bambinoPizza = new BambinoPizza();

            Assert.AreEqual("バンビーノピザ", bambinoPizza.Name);
            Assert.AreEqual(1600, bambinoPizza.Price);
            Assert.AreEqual(5, bambinoPizza.GetCountToppingList());

            Assert.AreEqual("チーズ", bambinoPizza.GetTopping(0).Name);
            Assert.AreEqual(0, bambinoPizza.GetTopping(0).Price);

            Assert.AreEqual("トマト", bambinoPizza.GetTopping(1).Name);
            Assert.AreEqual(0, bambinoPizza.GetTopping(1).Price);

            Assert.AreEqual("ツナ", bambinoPizza.GetTopping(2).Name);
            Assert.AreEqual(0, bambinoPizza.GetTopping(2).Price);

            Assert.AreEqual("コーン", bambinoPizza.GetTopping(3).Name);
            Assert.AreEqual(0, bambinoPizza.GetTopping(3).Price);

            Assert.AreEqual("ベーコン", bambinoPizza.GetTopping(4).Name);
            Assert.AreEqual(0, bambinoPizza.GetTopping(4).Price);
        }
    }
}
