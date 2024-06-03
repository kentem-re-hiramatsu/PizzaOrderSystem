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
            var name = cheese.GetName();
            var price = cheese.GetPrice();

            Assert.AreEqual(name, "チーズ");
            Assert.AreEqual(price, 100);
        }

        [TestMethod]
        public void CheeseDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new Cheese(1));
            Assert.ThrowsException<Exception>(() => new Cheese(-1));
        }


        [TestMethod]
        public void FriedGarlicTest()
        {
            var friedGarlic = new FriedGarlic();
            var name = friedGarlic.GetName();
            var price = friedGarlic.GetPrice();

            Assert.AreEqual(name, "フライドガーリック");
            Assert.AreEqual(price, 150);
        }

        [TestMethod]
        public void FriedGarlicDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new FriedGarlic(1));
            Assert.ThrowsException<Exception>(() => new FriedGarlic(-1));
        }

        [TestMethod]
        public void MozzarellaCheeseTest()
        {
            var mozzarellaCheese = new MozzarellaCheese();
            var name = mozzarellaCheese.GetName();
            var price = mozzarellaCheese.GetPrice();

            Assert.AreEqual(name, "モッツァレラチーズ");
            Assert.AreEqual(price, 300);
        }

        [TestMethod]
        public void MozzarellaCheeseDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new MozzarellaCheese(1));
            Assert.ThrowsException<Exception>(() => new MozzarellaCheese(-1));
        }

        [TestMethod]
        public void SeafoodMixTest()
        {
            var seafoodMix = new SeafoodMix();
            var name = seafoodMix.GetName();
            var price = seafoodMix.GetPrice();

            Assert.AreEqual(name, "シーフードミックス");
            Assert.AreEqual(price, 500);
        }

        [TestMethod]
        public void SeafoodMixDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new SeafoodMix(1));
            Assert.ThrowsException<Exception>(() => new SeafoodMix(-1));
        }

        [TestMethod]
        public void ScallopsTest()
        {
            var scallops = new Scallops();
            var name = scallops.GetName();
            var price = scallops.GetPrice();

            Assert.AreEqual(name, "ホタテ");
            Assert.AreEqual(price, 500);
        }

        [TestMethod]
        public void ScallopsDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new Scallops(1));
            Assert.ThrowsException<Exception>(() => new Scallops(-1));
        }

        [TestMethod]
        public void BasilTest()
        {
            var basil = new Basil();
            var name = basil.GetName();
            var price = basil.GetPrice();

            Assert.AreEqual(name, "バジル");
            Assert.AreEqual(price, 100);
        }

        [TestMethod]
        public void BasilDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new Basil(1));
            Assert.ThrowsException<Exception>(() => new Basil(-1));
        }

        [TestMethod]
        public void TomatoTest()
        {
            var tomato = new Tomato();
            var name = tomato.GetName();
            var price = tomato.GetPrice();

            Assert.AreEqual(name, "トマト");
            Assert.AreEqual(price, 250);
        }

        [TestMethod]
        public void TomatoDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new Tomato(1));
            Assert.ThrowsException<Exception>(() => new Tomato(-1));
        }

        [TestMethod]
        public void TunaTest()
        {
            var tuna = new Tuna();
            var name = tuna.GetName();
            var price = tuna.GetPrice();

            Assert.AreEqual(name, "ツナ");
            Assert.AreEqual(price, 250);
        }

        [TestMethod]
        public void TunaDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new Tuna(1));
            Assert.ThrowsException<Exception>(() => new Tuna(-1));
        }

        [TestMethod]
        public void CornTest()
        {
            var corn = new Corn();
            var name = corn.GetName();
            var price = corn.GetPrice();

            Assert.AreEqual(name, "コーン");
            Assert.AreEqual(price, 250);
        }

        [TestMethod]
        public void CornDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new Corn(1));
            Assert.ThrowsException<Exception>(() => new Corn(-1));
        }

        [TestMethod]
        public void BaconTest()
        {
            var bacon = new Bacon();
            var name = bacon.GetName();
            var price = bacon.GetPrice();

            Assert.AreEqual(name, "ベーコン");
            Assert.AreEqual(price, 250);
        }

        [TestMethod]
        public void BaconDefaultTest()
        {
            Assert.ThrowsException<Exception>(() => new Bacon(1));
            Assert.ThrowsException<Exception>(() => new Bacon(-1));
        }
    }
}
