using Models.Pizza;
using Models.Topping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Models.Manager
{
    public class PizzaOrderManagement
    {
        private List<IMenuItem> _pizzaOrderList;
        private List<PizzaMenu> _pizzaMenuList;
        private List<ToppingMenu> _toppingMenuList;
        public IReadOnlyCollection<IMenuItem> PizzaOrderList { get { return _pizzaOrderList; } }
        public IReadOnlyCollection<PizzaMenu> PizzaMenuList { get { return _pizzaMenuList; } }
        public IReadOnlyCollection<ToppingMenu> ToppingMenuList { get { return _toppingMenuList; } }

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
        public int GetTotalPrice()
        {
            return _pizzaOrderList.Select(x => ((PizzaMenu)x).GetPizzaTotalPrice()).Sum();
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
            for (int i = 0; i < _pizzaMenuList.Count; i++)
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
            for (int i = 0; i < _toppingMenuList.Count; i++)
            {
                if (name == GetToppingMenu(i).Name)
                {
                    return i;
                }
            }
            return -1;
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
                var Count = pizza.ToppingList.Count + 1;

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
            File.WriteAllText(_pizzaDataFilePath, "");
            for (int i = 0; i < _pizzaOrderList.Count; i++)
            {
                var toppingListCount = ((PizzaMenu)GetPizzaOrder(i)).ToppingList.Count;
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
