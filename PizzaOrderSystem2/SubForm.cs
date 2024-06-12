using Models;
using Models.Manager;
using Models.Topping;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sub
{
    public partial class SubForm : Form
    {
        private PizzaOrderManagement _pizzaOrderMana;

        //ピザを選択したときのインデックス
        private int slectedIndex = 0;

        public SubForm(PizzaOrderManagement pizzaOrderMana)
        {
            InitializeComponent();
            _pizzaOrderMana = pizzaOrderMana;
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            RefreshScreen();
        }

        /// <summary>
        /// リストビューを更新
        /// </summary>
        private void RefreshScreen()
        {
            ///メインメニューのリストビューを更新
            foreach (var topping in _pizzaOrderMana.PizzaMenuList)
            {
                MainMenuListView.Items.Add(new ListViewItem(new string[] { topping.Name, topping.Price.ToString() }));
            }

            ///トッピングメニューのリストビューを更新
            foreach (var pizza in _pizzaOrderMana.ToppingMenuList)
            {
                ToppingListView.Items.Add(new ListViewItem(new string[] { pizza.Name, pizza.Price.ToString() }));
            }

            MainMenuListView.Items[0].Checked = true;
        }

        private void ToppingListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ///Defaultトッピングを選択を固定する処理
            if (!(bool)ToppingListView.Items[e.Index].Tag)
            {
                e.NewValue = CheckState.Checked;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Okボタンが押されたらピザを注文リストに追加する処理
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            //GetPizzaMenuから選択しているピザのインスタンスを取得
            var pizzaInstance = _pizzaOrderMana.GetPizzaMenu(slectedIndex);
            bool isPizzaChanged = false;
            var toppings = new List<int>();

            //チェックされているトッピングを取得
            foreach (ListViewItem item in ToppingListView.Items)
            {
                if (item.Checked)
                    toppings.Add(item.Index);
            }

            //ピザが変更されているか
            if (_pizzaOrderMana.ContainsSameTopping(toppings).Name != pizzaInstance.Name)
            {
                //すべてのトッピングを初期化
                foreach (ListViewItem topping in ToppingListView.Items)
                {
                    topping.Tag = true;
                }

                pizzaInstance = _pizzaOrderMana.ContainsSameTopping(toppings);
                isPizzaChanged = true;

                var defaultToppings = new List<IMenuItem>();

                //任意のDefaultトッピングを追加
                foreach (var pizza in pizzaInstance.ToppingList)
                {
                    defaultToppings.Add(pizza);
                }

                //任意のピザのDefaultトッピングと全トッピングを比較しDefaultトッピングにチェックする処理
                for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
                {
                    for (int j = 0; j < defaultToppings.Count; j++)
                    {
                        if (defaultToppings[j].Name == ToppingListView.Items[i].Text)
                        {
                            ToppingListView.Items[i].Tag = false;
                            break;
                        }
                    }
                }
            }

            //全トッピング分繰り返す
            foreach (ListViewItem topping in ToppingListView.Items)
            {
                //トッピング選択とTagがFalse(Defaultトッピングじゃないとき)にピザの中にトッピングを追加する
                if (topping.Checked && (bool)topping.Tag)
                {
                    pizzaInstance.SetTopping(_pizzaOrderMana.GetToppingMenu(topping.Index));
                }
            }
            _pizzaOrderMana.AddPizzaOrderList(pizzaInstance);

            if (isPizzaChanged)
                MessageBox.Show($"{pizzaInstance.Name}に変更されました。");

            Close();
        }

        private void MainMenuListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int changedItemIndex = e.Index;

            //ピザ単一選択
            foreach (ListViewItem item in MainMenuListView.Items)
            {
                if (!MainMenuListView.Items[changedItemIndex].Checked)
                {
                    item.Checked = false;
                }
            }

            //すべてのトッピングを初期化
            foreach (ListViewItem topping in ToppingListView.Items)
            {
                topping.Checked = false;
                topping.BackColor = Color.White;
                topping.Tag = true;
            }

            if (e.CurrentValue == 0)
            {
                slectedIndex = e.Index;
                OkButton.Enabled = e.CurrentValue == 0;

                var defaultToppings = new List<ToppingMenu>();

                //選択したピザのインスタンスをリストから取得
                var pizzaInstance = new PizzaOrderManagement().GetPizzaMenu(e.Index);

                //任意のDefaultトッピングを追加
                foreach (var topping in pizzaInstance.ToppingList)
                {
                    defaultToppings.Add(topping);
                }

                //任意のピザのDefaultトッピングと全トッピングを比較しDefaultトッピングにチェックする処理
                foreach (ListViewItem item in ToppingListView.Items)
                {
                    if (defaultToppings.Any(x => x.Name == item.Text))
                    {
                        item.Checked = true;
                        item.Tag = false;
                        item.BackColor = Color.Gray;
                    }
                }
            }
        }
    }
}
