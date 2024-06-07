using Models;
using Models.Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace sub
{
    public partial class SubForm : Form
    {
        private PizzaOrderManagement _pizzaOrderMana;

        private int count = 0;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            var pizzaOrderMana = new PizzaOrderManagement();
            //GetPizzaMenuから選択しているピザのインスタンスを取得
            var pizzaInstance = pizzaOrderMana.GetPizzaMenu(slectedIndex);

            //全トッピング分繰り返す
            for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
            {
                //トッピング選択とTagがFalse(Defaultトッピングじゃないとき)にピザの中にトッピングを追加する
                if (ToppingListView.Items[i].Checked && (bool)ToppingListView.Items[i].Tag)
                {
                    pizzaInstance.SetTopping(_pizzaOrderMana.GetToppingMenu(i));
                }
            }
            _pizzaOrderMana.AddPizzaOrderList(pizzaInstance);

            Close();
        }

        private void MainMenuListView_ItemCheck_1(object sender, ItemCheckEventArgs e)
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
            for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
            {
                ToppingListView.Items[i].Checked = false;
                ToppingListView.Items[i].BackColor = Color.White;
                ToppingListView.Items[i].Tag = true;
            }

            //チェックをしたときと外したときに処理が走るので一回目だけ処理をさせる
            if (count == 0)
            {
                count++;
                slectedIndex = e.Index;
                OkButton.Enabled = e.CurrentValue == 0;

                var defaultToppings = new List<IMenuItem>();

                //選択したピザのインスタンスをリストから取得
                var pizzaInstance = _pizzaOrderMana.GetPizzaMenu(e.Index);

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
                            ToppingListView.Items[i].Checked = true;
                            ToppingListView.Items[i].BackColor = Color.Gray;
                            ToppingListView.Items[i].Tag = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                count = 0;
            }
        }
    }
}
