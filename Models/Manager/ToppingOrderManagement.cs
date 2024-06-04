using Models.Pizza;
using Models.Topping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models.Manager
{
    public class ToppingOrderManagement
    {
        private List<IMenuItem> _toppingOrderList;
        private string _pizzaDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Models/Data/PizzaData.text");
        public ToppingOrderManagement()
        {
            _toppingOrderList = new List<IMenuItem>();
        }

        public void AddToppingOrderList(IMenuItem pizzaMenu)
        {
            _toppingOrderList.Add(pizzaMenu);
        }

        public IMenuItem GetToppingOrder(int index)
        {
            return _toppingOrderList[index];
        }

        public int GetToppingOrderListCount()
        {
            return _toppingOrderList.Count;
        }

        public void RemoveToppingOrderList(int index)
        {
            _toppingOrderList.RemoveAt(index);
        }

        public int GetTotalToppingPrice()
        {
            int total = 0;

            for (int i = 0; i < GetToppingOrderListCount(); i++)
            {
                total += _toppingOrderList[i].Price;
            }
            return total;
        }

        public void LoadDataFile(PizzaOrderManagement pizzaOrderMana)
        {
            var pizzaList = new List<string>();

            using (StreamReader streamReader = new StreamReader(_pizzaDataFilePath, Encoding.UTF8))
            {
                while (streamReader.EndOfStream == false)
                {
                    string line = streamReader.ReadLine();
                    pizzaList.Add(line);
                }
            }

            var pizzaCount = pizzaList.Count;

            for (int i = 0; i < pizzaCount; i++)
            {
                string[] pizzaData = pizzaList[i].Split(',');
                var top = new ToppingOrderManagement();

                switch (pizzaData[0])
                {
                    case "プレーンピザ":
                        top.AddToppingOrderList(new PlainPizza());
                        break;

                    case "マルゲリータピザ":
                        top.AddToppingOrderList(new MargheritaPizza());
                        break;

                    case "シーフードピザ":
                        top.AddToppingOrderList(new SeafoodPizza());
                        break;

                    case "ペスカトーレピザ":
                        top.AddToppingOrderList(new PescaTorePizza());
                        break;

                    case "バンビーノピザ":
                        top.AddToppingOrderList(new BambinoPizza());
                        break;
                }
                for (int j = 1; j < pizzaData.Length; j++)
                {
                    switch (pizzaData[j])
                    {
                        case "チーズ":
                            top.AddToppingOrderList(new Cheese());
                            break;

                        case "フライドガーリック":
                            top.AddToppingOrderList(new FriedGarlic());
                            break;

                        case "モッツァレラチーズ":
                            top.AddToppingOrderList(new MozzarellaCheese());
                            break;

                        case "シーフードミックス":
                            top.AddToppingOrderList(new SeafoodMix());
                            break;

                        case "ホタテ":
                            top.AddToppingOrderList(new Scallops());
                            break;

                        case "バジル":
                            top.AddToppingOrderList(new Basil());
                            break;

                        case "トマト":
                            top.AddToppingOrderList(new Tomato());
                            break;

                        case "ツナ":
                            top.AddToppingOrderList(new Tuna());
                            break;

                        case "コーン":
                            top.AddToppingOrderList(new Corn());
                            break;

                        case "ベーコン":
                            top.AddToppingOrderList(new Bacon());
                            break;
                    }
                }
                pizzaOrderMana.AddPizzaOrderList(top);
            }
        }
    }
}
