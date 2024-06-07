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

        /// <summary>
        /// 注文リストに注文したピザをリストに追加
        /// </summary>
        /// <param name="pizzaMenu"></param>
        public void AddPizzaOrderList(IMenuItem pizzaMenu)
        {
            _pizzaOrderList.Add(pizzaMenu);
        }

        /// <summary>
        /// 選択したピザを返す
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IMenuItem GetPizzaOrder(int index)
        {
            return _pizzaOrderList[index];
        }

        /// <summary>
        /// 注文リストを返す
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<IMenuItem> GetPizzaOrderList()
        {
            return _pizzaOrderList;
        }

        /// <summary>
        /// 注文された数を返す
        /// </summary>
        /// <returns></returns>
        public int GetPizzaOrderListCount()
        {
            return _pizzaOrderList.Count;
        }

        /// <summary>
        /// 選択されたピザの削除
        /// </summary>
        /// <param name="index"></param>
        public void RemovePizzaOrderList(int index)
        {
            _pizzaOrderList.RemoveAt(index);
        }

        /// <summary>
        /// すべてのピザの合計金額を返す
        /// </summary>
        /// <returns></returns>
        public int GetPizzaTotalPrice()
        {
            int totalPrice = 0;

            for (int i = 0; i < GetPizzaOrderListCount(); i++)
            {
                totalPrice += _pizzaOrderList[i].Price + ((PizzaMenu)_pizzaOrderList[i]).GetTotalToppingPrice();
            }

            return totalPrice;
        }

        /// <summary>
        /// indexをもとにピザのインスタンスを返す
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PizzaMenu GetPizzaMenu(int index)
        {
            return _pizzaMenuList[index];
        }

        /// <summary>
        /// ピザの名前からリストのインデックスを返す
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetPizzaMenuIndex(string name)
        {
            for (int i = 0; i < GetPizzaMenuListCount(); i++)
            {
                if (name == GetPizzaMenu(i).Name)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// ピザのインスタンスをリストに追加
        /// </summary>
        private void SetPizzaMenuList()
        {
            _pizzaMenuList.Add(new PlainPizza());
            _pizzaMenuList.Add(new MargheritaPizza());
            _pizzaMenuList.Add(new SeafoodPizza());
            _pizzaMenuList.Add(new PescaTorePizza());
            _pizzaMenuList.Add(new BambinoPizza());
        }

        /// <summary>
        /// ピザの種類の数を返す
        /// </summary>
        /// <returns></returns>
        public int GetPizzaMenuListCount()
        {
            return _pizzaMenuList.Count;
        }

        /// <summary>
        /// トッピングのインスタンスを返す
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ToppingMenu GetToppingMenu(int index)
        {
            return _toppingMenuList[index];
        }

        /// <summary>
        /// トッピングの名前からリストのインデックスを返す
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetToppingMenuIndex(string name)
        {
            for (int i = 0; i < GetToppingMenuListCount(); i++)
            {
                if (name == GetToppingMenu(i).Name)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// トッピングリストを返す
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<ToppingMenu> GetToppingMenuList()
        {
            return _toppingMenuList;
        }

        /// <summary>
        /// トッピングの種類の数を返す
        /// </summary>
        /// <returns></returns>
        public int GetToppingMenuListCount()
        {
            return _toppingMenuList.Count;
        }

        /// <summary>
        /// トッピングのインスタンスをリストに追加
        /// </summary>
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

        /// <summary>
        /// ピザデータの読み込み
        /// </summary>
        public void LoadDataFile()
        {
            var pizzaList = new List<string>();

            using (StreamReader streamReader = new StreamReader(_pizzaDataFilePath, System.Text.Encoding.UTF8))
            {
                //一行ずつ読み取りリストに追加処理
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

                var pizzaOrdermana = new PizzaOrderManagement();

                //GetPizzaMenuから任意のピザのインスタンス取得
                var pizza = pizzaOrdermana.GetPizzaMenu(int.Parse(pizzaData[0]));

                //Defaultトッピングの数を取得
                var Count = pizza.GetCountToppingList() + 1;

                ToppingMenu topping = null;

                //Defaultトッピング以外のトッピングを追加処理
                for (int j = Count; j < pizzaData.Length; j++)
                {
                    topping = GetToppingMenu(int.Parse(pizzaData[j]));
                    pizza.SetTopping(topping);
                }
                AddPizzaOrderList(pizza);
            }
        }

        /// <summary>
        /// ピザデータを保存
        /// </summary>
        public void SavePizzaDataFile()
        {
            var pizzaOrderListCount = GetPizzaOrderListCount();

            File.WriteAllText(_pizzaDataFilePath, "");
            for (int i = 0; i < pizzaOrderListCount; i++)
            {
                var toppingListCount = ((PizzaMenu)GetPizzaOrder(i)).GetCountToppingList();
                var pizzaIndex = GetPizzaMenuIndex(((PizzaMenu)GetPizzaOrder(i)).Name);

                File.AppendAllText(_pizzaDataFilePath, $"{pizzaIndex},");

                for (int j = 0; j < toppingListCount; j++)
                {
                    var toppingindex = GetToppingMenuIndex(((PizzaMenu)GetPizzaOrder(i)).GetTopping(j).Name);

                    if (j == toppingListCount - 1)
                    {
                        File.AppendAllText(_pizzaDataFilePath, (toppingindex + Environment.NewLine));
                    }
                    else
                    {
                        File.AppendAllText(_pizzaDataFilePath, $"{toppingindex},");
                    }
                }
            }
        }
    }
}
