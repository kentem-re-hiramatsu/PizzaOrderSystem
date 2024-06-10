using Models;
using Models.Manager;
using Models.Pizza;
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

        private int count = 0;
        public ChangeForm(PizzaOrderManagement pizzaOrderMana, int selectedIndex)
        {
            InitializeComponent();
            _pizzaOrderMana = pizzaOrderMana;
            _selectedIndex = selectedIndex;
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            var previousToppingList = new List<string>();
            var currentToppingList = new List<string>();

            //ピザが変更されているか
            if (MainMenuListView.Items[_pizzaindex].Text == _pizzaOrderMana.GetPizzaOrder(_selectedIndex).Name)
            {
                //変更前のトッピングを取得
                foreach (var topping in ((PizzaMenu)_pizzaOrderMana.GetPizzaOrder(_selectedIndex)).ToppingList)
                {
                    previousToppingList.Add(topping.Name);
                }

                //現在のトッピングを取得
                for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
                {
                    if (ToppingListView.Items[i].Checked)
                    {
                        currentToppingList.Add(_pizzaOrderMana.GetToppingMenu(i).Name);
                    }
                }

                //外されたトッピングを検索
                var removedTopping = previousToppingList.Where(name => !currentToppingList.Contains(name)).ToList();

                //外されたトッピングを削除
                foreach (var topping in removedTopping)
                {
                    ((PizzaMenu)_pizzaOrderMana.GetPizzaOrder(_selectedIndex)).Reamove(topping);
                }

                //追加されたトッピングを検索
                var addedTopping = currentToppingList.Where(name => !previousToppingList.Contains(name)).ToList();

                //追加されたトッピングを追加
                foreach (string add in addedTopping)
                {
                    var topping = _pizzaOrderMana.GetToppingMenu(_pizzaOrderMana.GetToppingMenuIndex(add));
                    ((PizzaMenu)_pizzaOrderMana.GetPizzaOrder(_selectedIndex)).SetTopping(topping);
                }
            }
            else
            {
                var pizzaOrderMana = new PizzaOrderManagement();
                //GetPizzaMenuから選択しているピザのインスタンスを取得
                var pizzaInstance = pizzaOrderMana.GetPizzaMenu(_pizzaindex);

                //全トッピング分繰り返す
                for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
                {
                    //トッピング選択とTagがFalse(Defaultトッピングじゃないとき)にピザの中にトッピングを追加する
                    if (ToppingListView.Items[i].Checked && (bool)ToppingListView.Items[i].Tag)
                    {
                        pizzaInstance.SetTopping(_pizzaOrderMana.GetToppingMenu(i));
                    }
                }
                _pizzaOrderMana.ChangePizza(_selectedIndex, pizzaInstance);
            }
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
            for (int i = 0; i < _pizzaOrderMana.PizzaMenuList.Count; i++)
            {
                MainMenuListView.Items.Add(new ListViewItem(new string[] { _pizzaOrderMana.GetPizzaMenu(i).Name, _pizzaOrderMana.GetPizzaMenu(i).Price.ToString() }));
            }
            for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
            {
                ToppingListView.Items.Add(new ListViewItem(new string[] { _pizzaOrderMana.GetToppingMenu(i).Name, _pizzaOrderMana.GetToppingMenu(i).Price.ToString() }));
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
            for (int i = 0; i < _pizzaOrderMana.PizzaMenuList.Count; i++)
            {
                MainMenuListView.Items[i].Checked = _pizzaOrderMana.GetPizzaOrder(_selectedIndex).Name == _pizzaOrderMana.GetPizzaMenu(i).Name;
                MainMenuListView.Items[i].Tag = _pizzaOrderMana.GetPizzaOrder(_selectedIndex).Name == _pizzaOrderMana.GetPizzaMenu(i).Name;
            }
            for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
            {
                for (int j = 0; j < ((PizzaMenu)_pizzaOrderMana.GetPizzaOrder(_selectedIndex)).ToppingList.Count; j++)
                {
                    if (((PizzaMenu)_pizzaOrderMana.GetPizzaOrder(_selectedIndex)).GetTopping(j).Name == _pizzaOrderMana.GetToppingMenu(i).Name)
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
            if (count == 0)
            {
                count++;
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
            else
            {
                count = 0;
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