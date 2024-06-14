using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Topping;
using System;

namespace PizzaOrderSystemTest
{
    [TestClass]
    public class ToppingMenuTest
    {
        [TestMethod]
        public void CheeseTest()
        {
            var cheese = new Cheese();
            var name = cheese.Name;
            var price = cheese.Price;

            Assert.AreEqual("チーズ", name);
            Assert.AreEqual(100, price);
        }

        [TestMethod]
        public void CheeseDefaultTest()
        {
            Assert.AreEqual(0, new Cheese(0).Price);
            Assert.ThrowsException<Exception>(() => new Cheese(-1));
        }

        [TestMethod]
        public void FriedGarlicTest()
        {
            var friedGarlic = new FriedGarlic();
            var name = friedGarlic.Name;
            var price = friedGarlic.Price;

            Assert.AreEqual("フライドガーリック", name);
            Assert.AreEqual(150, price);
        }

        [TestMethod]
        public void FriedGarlicDefaultTest()
        {
            Assert.AreEqual(0, new FriedGarlic(0).Price);
            Assert.ThrowsException<Exception>(() => new FriedGarlic(-1));
        }

        [TestMethod]
        public void MozzarellaCheeseTest()
        {
            var mozzarellaCheese = new MozzarellaCheese();
            var name = mozzarellaCheese.Name;
            var price = mozzarellaCheese.Price;

            Assert.AreEqual("モッツァレラチーズ", name);
            Assert.AreEqual(300, price);
        }

        [TestMethod]
        public void MozzarellaCheeseDefaultTest()
        {
            Assert.AreEqual(0, new MozzarellaCheese(0).Price);
            Assert.ThrowsException<Exception>(() => new MozzarellaCheese(-1));
        }

        [TestMethod]
        public void SeafoodMixTest()
        {
            var seafoodMix = new SeafoodMix();
            var name = seafoodMix.Name;
            var price = seafoodMix.Price;

            Assert.AreEqual("シーフードミックス", name);
            Assert.AreEqual(500, price);
        }

        [TestMethod]
        public void SeafoodMixDefaultTest()
        {
            Assert.AreEqual(0, new SeafoodMix(0).Price);
            Assert.ThrowsException<Exception>(() => new SeafoodMix(-1));
        }

        [TestMethod]
        public void ScallopsTest()
        {
            var scallops = new Scallops();
            var name = scallops.Name;
            var price = scallops.Price;

            Assert.AreEqual("ホタテ", name);
            Assert.AreEqual(500, price);
        }

        [TestMethod]
        public void ScallopsDefaultTest()
        {
            Assert.AreEqual(0, new Scallops(0).Price);
            Assert.ThrowsException<Exception>(() => new Scallops(-1));
        }

        [TestMethod]
        public void BasilTest()
        {
            var basil = new Basil();
            var name = basil.Name;
            var price = basil.Price;

            Assert.AreEqual("バジル", name);
            Assert.AreEqual(100, price);
        }

        [TestMethod]
        public void BasilDefaultTest()
        {
            Assert.AreEqual(0, new Basil(0).Price);
            Assert.ThrowsException<Exception>(() => new Basil(-1));
        }

        [TestMethod]
        public void TomatoTest()
        {
            var tomato = new Tomato();
            var name = tomato.Name;
            var price = tomato.Price;

            Assert.AreEqual("トマト", name);
            Assert.AreEqual(250, price);
        }

        [TestMethod]
        public void TomatoDefaultTest()
        {
            Assert.AreEqual(0, new Tomato(0).Price);
            Assert.ThrowsException<Exception>(() => new Tomato(-1));
        }

        [TestMethod]
        public void TunaTest()
        {
            var tuna = new Tuna();
            var name = tuna.Name;
            var price = tuna.Price;

            Assert.AreEqual("ツナ", name);
            Assert.AreEqual(250, price);
        }

        [TestMethod]
        public void TunaDefaultTest()
        {
            Assert.AreEqual(0, new Tuna(0).Price);
            Assert.ThrowsException<Exception>(() => new Tuna(-1));
        }

        [TestMethod]
        public void CornTest()
        {
            var corn = new Corn();
            var name = corn.Name;
            var price = corn.Price;

            Assert.AreEqual("コーン", name);
            Assert.AreEqual(250, price);
        }

        [TestMethod]
        public void CornDefaultTest()
        {
            Assert.AreEqual(0, new Corn(0).Price);
            Assert.ThrowsException<Exception>(() => new Corn(-1));
        }

        [TestMethod]
        public void BaconTest()
        {
            var bacon = new Bacon();
            var name = bacon.Name;
            var price = bacon.Price;

            Assert.AreEqual("ベーコン", name);
            Assert.AreEqual(250, price);
        }

        [TestMethod]
        public void BaconDefaultTest()
        {
            Assert.AreEqual(0, new Bacon(0).Price);
            Assert.ThrowsException<Exception>(() => new Bacon(-1));
        }
    }
}
