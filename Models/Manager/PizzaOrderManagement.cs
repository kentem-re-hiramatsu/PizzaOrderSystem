using Models.Pizza;
using Models.Topping;
using System;
using System.Collections.Generic;
using System.IO;

namespace Models.Manager
{
    public class PizzaOrderManagement
    {
        private List<IMenuItem> _pizzaOrderList;
        private List<PizzaMenu> _pizzaMenuList;
        private List<ToppingMenu> _toppingMenuList;
        private string _pizzaDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Models/Data/PizzaData.text");

        public PizzaOrderManagement()
        {
            _pizzaOrderList = new List<IMenuItem>();
            _pizzaMenuList = new List<PizzaMenu>();
            _toppingMenuList = new List<ToppingMenu>();

            SetPizzaMenuList();
            SetToppingMenuList();
        }

        public void AddPizzaOrderList(IMenuItem pizzaMenu)
        {
            _pizzaOrderList.Add(pizzaMenu);
        }

        public IMenuItem GetPizzaOrder(int index)
        {
            return _pizzaOrderList[index];
        }
        public IReadOnlyCollection<IMenuItem> GetPizzaOrderList()
        {
            return _pizzaOrderList;
        }

        public int GetPizzaOrderListCount()
        {
            return _pizzaOrderList.Count;
        }

        public void RemovePizzaOrderList(int index)
        {
            _pizzaOrderList.RemoveAt(index);
        }

        public int GetPizzaTotalPrice()
        {
            int totalPrice = 0;

            for (int i = 0; i < GetPizzaOrderListCount(); i++)
            {
                totalPrice += _pizzaOrderList[i].Price + ((PizzaMenu)_pizzaOrderList[i]).GetTotalToppingPrice();
            }

            return totalPrice;
        }

        public PizzaMenu GetPizzaMenu(int index)
        {
            return _pizzaMenuList[index];
        }

        private void SetPizzaMenuList()
        {
            _pizzaMenuList.Add(new PlainPizza());
            _pizzaMenuList.Add(new MargheritaPizza());
            _pizzaMenuList.Add(new SeafoodPizza());
            _pizzaMenuList.Add(new PescaTorePizza());
            _pizzaMenuList.Add(new BambinoPizza());
        }

        public int GetPizzaMenuListCount()
        {
            return _pizzaMenuList.Count;
        }

        public ToppingMenu GetToppingMenu(int index)
        {
            return _toppingMenuList[index];
        }

        public IReadOnlyCollection<ToppingMenu> GetToppingMenuList()
        {
            return _toppingMenuList;
        }

        public int GetToppingMenuListCount()
        {
            return _toppingMenuList.Count;
        }

        private void SetToppingMenuList()
        {
            _toppingMenuList.Add(new Cheese());
            _toppingMenuList.Add(new FriedGarlic());
            _toppingMenuList.Add(new MozzarellaCheese());
            _toppingMenuList.Add(new SeafoodMix());
            _toppingMenuList.Add(new Scallops());
            _toppingMenuList.Add(new Basil());
            _toppingMenuList.Add(new Tomato());
            _toppingMenuList.Add(new Tuna());
            _toppingMenuList.Add(new Corn());
            _toppingMenuList.Add(new Bacon());
        }

        ///ERROR修正未完成
        //public void LoadDataFile()
        //{
        //    var pizzaList = new List<string>();

        //    using (StreamReader streamReader = new StreamReader(_pizzaDataFilePath, Encoding.UTF8))
        //    {
        //        while (streamReader.EndOfStream == false)
        //        {
        //            string line = streamReader.ReadLine();
        //            pizzaList.Add(line);
        //        }
        //    }

        //    var pizzaCount = pizzaList.Count;

        //    for (int i = 0; i < pizzaCount; i++)
        //    {
        //        string[] pizzaData = pizzaList[i].Split(',');

        //        switch (pizzaData[0])
        //        {
        //            case "プレーンピザ":
        //                AddPizzaOrderList(new PlainPizza());
        //                break;

        //            case "マルゲリータピザ":
        //                AddPizzaOrderList(new MargheritaPizza());
        //                break;

        //            case "シーフードピザ":
        //                AddPizzaOrderList(new SeafoodPizza());
        //                break;

        //            case "ペスカトーレピザ":
        //                AddPizzaOrderList(new PescaTorePizza());
        //                break;

        //            case "バンビーノピザ":
        //                AddPizzaOrderList(new BambinoPizza());
        //                break;
        //            default: break;
        //        }
        //        for (int j = 1; j < pizzaData.Length; j++)
        //        {
        //            switch (pizzaData[j])
        //            {
        //                case "チーズ":
        //                    (PizzaMenu)AddPizzaOrderList();
        //                    break;

        //                case "フライドガーリック":
        //                    AddPizzaOrderList(new FriedGarlic());
        //                    break;

        //                case "モッツァレラチーズ":
        //                    AddPizzaOrderList(new MozzarellaCheese());
        //                    break;

        //                case "シーフードミックス":
        //                    AddPizzaOrderList(new SeafoodMix());
        //                    break;

        //                case "ホタテ":
        //                    AddPizzaOrderList(new Scallops());
        //                    break;

        //                case "バジル":
        //                    AddPizzaOrderList(new Basil());
        //                    break;

        //                case "トマト":
        //                    AddPizzaOrderList(new Tomato());
        //                    break;

        //                case "ツナ":
        //                    AddPizzaOrderList(new Tuna());
        //                    break;

        //                case "コーン":
        //                    AddPizzaOrderList(new Corn());
        //                    break;

        //                case "ベーコン":
        //                    AddPizzaOrderList(new Bacon());
        //                    break;
        //                default: break;
        //            }
        //        }
        //        pizzaOrderMana.AddPizzaOrderList(top);
        //    }
        //}
        //public void SavePizzaDataFile()
        //{
        //    var pizzaOrderListCount = pizzaOrderMana.GetPizzaOrderListCount();

        //    File.WriteAllText(_pizzaDataFilePath, "");

        //    for (int i = 0; i < pizzaOrderListCount; i++)
        //    {
        //        var toppingListCount = pizzaOrderMana.GetPizzaOrder(i).GetToppingOrderListCount();

        //        for (int j = 0; j < toppingListCount; j++)
        //        {
        //            if (j == toppingListCount - 1)
        //            {
        //                File.AppendAllText(_pizzaDataFilePath, pizzaOrderMana.GetPizzaOrder(i).GetToppingOrder(j).Name + Environment.NewLine);
        //            }
        //            else
        //            {
        //                File.AppendAllText(_pizzaDataFilePath, $"{pizzaOrderMana.GetPizzaOrder(i).GetToppingOrder(j).Name},");
        //            }
        //        }
        //    }
        //}
    }
}
