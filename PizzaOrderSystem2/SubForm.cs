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
        private int _pizzaMenuSlectedIndex = 0;
        private int _pizzaOrderSelectionIndex;
        private bool _buttonChecked;

        public SubForm(PizzaOrderManagement pizzaOrderMana, int selectedIndex, bool buttonChecked)
        {
            InitializeComponent();
            _pizzaOrderMana = pizzaOrderMana;
            _pizzaOrderSelectionIndex = selectedIndex;
            _buttonChecked = buttonChecked;
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            RefreshScreen();
            if (!_buttonChecked)
                SetSelectedPizzaDetails();
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

            //初期設定
            MainMenuListView.Items[0].Checked = true;
        }

        private void ToppingListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ///Defaultトッピングを選択を固定する処理
            if (!(bool)ToppingListView.Items[e.Index].Tag)
                e.NewValue = CheckState.Checked;
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
            var pizzaInstance = _pizzaOrderMana.GetPizzaMenu(_pizzaMenuSlectedIndex).DeepCopy();
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

                //任意のピザのDefaultトッピングと全トッピングを比較しDefaultトッピングにチェックする処理
                foreach (ListViewItem item in ToppingListView.Items)
                {
                    if (pizzaInstance.ToppingList.Any(x => x.Name == item.Text))
                        item.Tag = false;
                }
            }

            foreach (ListViewItem topping in ToppingListView.Items)
            {
                //トッピング選択とTagがFalse(Defaultトッピングじゃないとき)にピザの中にトッピングを追加する
                if (topping.Checked && (bool)topping.Tag)
                    pizzaInstance.SetTopping(_pizzaOrderMana.GetToppingMenu(topping.Index));
            }

            if (_buttonChecked)
                _pizzaOrderMana.AddPizzaOrderList(pizzaInstance);
            else
                _pizzaOrderMana.ChangePizza(_pizzaOrderSelectionIndex, pizzaInstance);

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
                    item.Checked = false;
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
                _pizzaMenuSlectedIndex = e.Index;
                OkButton.Enabled = e.CurrentValue == 0;

                var defaultToppings = new List<ToppingMenu>();

                //選択したピザのインスタンスをリストから取得
                var pizzaInstance = _pizzaOrderMana.GetPizzaMenu(e.Index).DeepCopy();

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

        /// <summary>
        ///選択したピザの詳細をセットする
        /// </summary>
        public void SetSelectedPizzaDetails()
        {
            foreach (ListViewItem item in MainMenuListView.Items)
            {
                item.Checked = _pizzaOrderMana.GetPizzaOrder(_pizzaOrderSelectionIndex).Name == item.Text;
                item.Tag = _pizzaOrderMana.GetPizzaOrder(_pizzaOrderSelectionIndex).Name == item.Text;
            }

            foreach (ListViewItem item in ToppingListView.Items)
                item.Checked = _pizzaOrderMana.GetPizzaOrder(_pizzaOrderSelectionIndex).ToppingList.Any(e => e.Name == item.Text);
        }
    }
}
