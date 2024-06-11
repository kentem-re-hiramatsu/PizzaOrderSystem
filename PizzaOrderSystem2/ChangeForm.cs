using Models;
using Models.Manager;
using Models.Pizza;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ChangeForm : Form
    {
        private PizzaOrderManagement _pizzaOrderMana;
        private int _selectedIndex;

        private int _pizzaindex;

        public ChangeForm(PizzaOrderManagement pizzaOrderMana, int selectedIndex)
        {
            InitializeComponent();
            _pizzaOrderMana = pizzaOrderMana;
            _selectedIndex = selectedIndex;
        }

        /// <summary>
        /// 同じトッピングが含まれているか
        /// </summary>
        /// <returns></returns>
        public PizzaMenu ContainsSameTopping()
        {
            var pizzaOrderMana = new PizzaOrderManagement();
            var toppings = new List<string>();
            PizzaMenu pizzaInstance = null;

            //チェックされているトッピングを取得
            for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
            {
                if (ToppingListView.Items[i].Checked)
                {
                    toppings.Add(ToppingListView.Items[i].Text);
                }
            }

            for (int i = pizzaOrderMana.PizzaMenuList.Count - 1; 0 <= i; i--)
            {
                var count = pizzaOrderMana.GetPizzaMenu(i).ToppingList.Count;
                var defaulttoppings = new List<string>();

                for (int j = 0; j < count; j++)
                {
                    defaulttoppings.Add(pizzaOrderMana.GetPizzaMenu(i).GetTopping(j).Name);
                }

                //任意のピザのデフォルトトッピングが選択されているトッピングすべて含まれているか
                if (defaulttoppings.All(topping => toppings.Contains(topping)))
                {
                    if ((pizzaOrderMana.GetPizzaMenu(_pizzaindex).Name == pizzaOrderMana.GetPizzaMenu(i).Name))
                        break;

                    pizzaInstance = pizzaOrderMana.GetPizzaMenu(i);
                    break;
                }
            }

            //新しいピザをのデフォルトトッピングのタグを変更
            if (pizzaInstance != null)
            {
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

            return pizzaInstance;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var pizzaOrderMana = new PizzaOrderManagement();

            //GetPizzaMenuから選択しているピザのインスタンスを取得
            var pizzaInstance = pizzaOrderMana.GetPizzaMenu(_pizzaindex);
            bool isPizzaChanged = false;

            if (ContainsSameTopping() != null)
            {
                pizzaInstance = ContainsSameTopping();
                isPizzaChanged = true;
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
            _pizzaOrderMana.ChangePizza(_selectedIndex, pizzaInstance);

            if (isPizzaChanged)
                MessageBox.Show($"{pizzaInstance.Name}に変更されました。");

            Close();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ToppingListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void MainMenuListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void RefreshScreen()
        {
            foreach (var pizza in _pizzaOrderMana.PizzaMenuList)
            {
                MainMenuListView.Items.Add(new ListViewItem(new string[] { pizza.Name, pizza.Price.ToString() }));
            }
            foreach (var topping in _pizzaOrderMana.ToppingMenuList)
            {
                ToppingListView.Items.Add(new ListViewItem(new string[] { topping.Name, topping.Price.ToString() }));
            }
        }

        private void ChangeForm_Load(object sender, System.EventArgs e)
        {
            RefreshScreen();
            SetSelectedPizzaDetails();
        }

        /// <summary>
        ///選択したピザの詳細をセットする
        /// </summary>
        public void SetSelectedPizzaDetails()
        {
            foreach (ListViewItem pizza in MainMenuListView.Items)
            {
                pizza.Checked = _pizzaOrderMana.GetPizzaOrder(_selectedIndex).Name == pizza.Text;
                pizza.Tag = _pizzaOrderMana.GetPizzaOrder(_selectedIndex).Name == pizza.Text;
            }

            for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
            {
                for (int j = 0; j < _pizzaOrderMana.GetPizzaOrder(_selectedIndex).ToppingList.Count; j++)
                {
                    if (_pizzaOrderMana.GetPizzaOrder(_selectedIndex).GetTopping(j).Name == _pizzaOrderMana.GetToppingMenu(i).Name)
                    {
                        ToppingListView.Items[i].Checked = true;
                        break;
                    }
                }
            }
        }

        private void MainMenuListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;

            //ピザ単一選択
            foreach (ListViewItem item in MainMenuListView.Items)
            {
                if (!MainMenuListView.Items[index].Checked)
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
            if (e.CurrentValue == 0)
            {
                _pizzaindex = e.Index;
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
        }

        private void ToppingListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ///Defaultトッピングを選択を固定する処理
            if (!(bool)ToppingListView.Items[e.Index].Tag)
            {
                e.NewValue = CheckState.Checked;
            }
        }
    }
}