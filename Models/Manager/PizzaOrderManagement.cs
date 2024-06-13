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
        private List<PizzaMenu> _pizzaOrderList = new List<PizzaMenu>();
        private List<PizzaMenu> _pizzaMenuList = new List<PizzaMenu>();
        private List<ToppingMenu> _toppingMenuList = new List<ToppingMenu>();

        public IReadOnlyCollection<PizzaMenu> PizzaOrderList { get { return _pizzaOrderList; } }
        public IReadOnlyCollection<PizzaMenu> PizzaMenuList { get { return _pizzaMenuList; } }
        public IReadOnlyCollection<ToppingMenu> ToppingMenuList { get { return _toppingMenuList; } }

        private string _pizzaDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Models/Data/data.csv");

        public PizzaOrderManagement()
        {
            SetPizzaMenuList();
            SetToppingMenuList();
        }

        /// <summary>
        /// 注文リストに注文したピザをリストに追加
        /// </summary>
        public void AddPizzaOrderList(PizzaMenu pizzaMenu) => _pizzaOrderList.Add(pizzaMenu);

        /// <summary>
        /// 選択したピザを返す
        /// </summary>
        public PizzaMenu GetPizzaOrder(int index) => _pizzaOrderList[index];

        /// <summary>
        /// 選択されたピザの削除
        /// </summary>
        public void RemovePizzaOrderList(int index) => _pizzaOrderList.RemoveAt(index);

        /// <summary>
        /// すべてのピザの合計金額を返す
        /// </summary>
        public int GetTotalPrice() => _pizzaOrderList.Sum(x => x.GetPizzaTotalPrice());

        /// <summary>
        /// indexをもとにピザのインスタンスを返す
        /// </summary>
        public PizzaMenu GetPizzaMenu(int index) => _pizzaMenuList[index];

        /// <summary>
        /// ピザの名前からリストのインデックスを返す
        /// </summary>
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
        public ToppingMenu GetToppingMenu(int index) => _toppingMenuList[index];

        /// <summary>
        /// トッピングの名前からリストのインデックスを返す
        /// </summary>
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
        /// ピザ変更
        /// </summary>
        public void ChangePizza(int index, PizzaMenu pizzaMenu) => _pizzaOrderList[index] = pizzaMenu;

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
                var toppingListCount = (GetPizzaOrder(i)).ToppingList.Count;
                var pizzaIndex = GetPizzaMenuIndex(GetPizzaOrder(i).Name);

                File.AppendAllText(_pizzaDataFilePath, $"{pizzaIndex},");

                for (int j = 0; j < toppingListCount; j++)
                {
                    var toppingindex = GetToppingMenuIndex(GetPizzaOrder(i).GetTopping(j).Name);

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

        /// <summary>
        /// ピザ変更
        /// </summary>
        public PizzaMenu ContainsSameTopping(List<int> toppings)
        {
            PizzaMenu pizzaInstance = null;
            int lowPrice = int.MaxValue;
            var pizzaorder = new PizzaOrderManagement();

            for (int i = 0; i < pizzaorder.PizzaMenuList.Count; i++)
            {
                var defaulttoppings = new List<int>();
                int pizzaTotalPrice = pizzaorder.GetPizzaMenu(i).GetPizzaTotalPrice();

                for (int j = 0; j < pizzaorder.GetPizzaMenu(i).ToppingList.Count; j++)
                {
                    defaulttoppings.Add(GetToppingMenuIndex(pizzaorder.GetPizzaMenu(i).GetTopping(j).Name));
                }

                //選択したトッピングとデフォルトトッピングの和集合
                var unionToppings = toppings.Union(defaulttoppings);

                //和集合とデフォルトトッピングの差集合
                var exceptTopping = unionToppings.Except(defaulttoppings);

                //追加トッピングの価格を取得
                foreach (var topping in exceptTopping)
                {
                    pizzaTotalPrice += GetToppingMenu(topping).Price;
                }

                //一番低いピザの価格と今回のピザの価格を比較
                if (lowPrice > pizzaTotalPrice)
                {
                    pizzaInstance = pizzaorder.GetPizzaMenu(i);
                    lowPrice = pizzaTotalPrice;
                }
            }
            return pizzaInstance;
        }
    }
}
