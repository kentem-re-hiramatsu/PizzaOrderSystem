using Models;
using Models.Manager;
using Models.Pizza;
using Models.Topping;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace sub
{
    public partial class SubForm : Form
    {
        private PizzaEnum _pizzaName;
        private PizzaOrderManagement _pizzaOrderMana;
        private List<IMenuItem> _defotopping = new List<IMenuItem>();

        private List<PizzaMenu> _pizzaMenuList = new List<PizzaMenu>();
        private List<ToppingMenu> _toppingMenuList = new List<ToppingMenu>();

        int count = 0;
        //ピザを選択したときのインデックス
        int slectedIndex = 0;


        public SubForm()
        {
        }
        public SubForm(PizzaOrderManagement pizzaOrderMana)
        {
            InitializeComponent();
            _pizzaOrderMana = pizzaOrderMana;
            GetPizzaMenuList();
            GetToppingMenuList();
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
            for (int i = 0; i < _pizzaMenuList.Count; i++)
            {
                MainMenuListView.Items.Add(new ListViewItem(new string[] { _pizzaMenuList[i].Name, _pizzaMenuList[i].Price.ToString() }));
            }
            ///トッピングメニューのリストビューを更新
            for (int i = 0; i < _toppingMenuList.Count; i++)
            {
                ToppingListView.Items.Add(new ListViewItem(new string[] { _toppingMenuList[i].Name, _toppingMenuList[i].Price.ToString() }));
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
            //GetPizzaMenuから選択しているピザのインスタンスを取得
            var pizzaInstance = _pizzaOrderMana.GetPizzaMenu(slectedIndex);

            //全トッピング分繰り返す
            for (int i = 0; i < _toppingMenuList.Count; i++)
            {
                //トッピング選択とTagがFalse(Defaultトッピングじゃないとき)にピザの中にトッピングを追加する
                if (ToppingListView.Items[i].Checked && (bool)ToppingListView.Items[i].Tag)
                {
                    pizzaInstance.SetTopping(_toppingMenuList[i]);
                }
            }
            _pizzaOrderMana.AddPizzaOrderList(pizzaInstance);

            Close();
        }

        public void GetPizzaMenuList()
        {
            for (int i = 0; i < _pizzaOrderMana.GetPizzaMenuListCount(); i++)
            {
                _pizzaMenuList.Add(_pizzaOrderMana.GetPizzaMenu(i));
            }
        }

        public void GetToppingMenuList()
        {
            for (int i = 0; i < _pizzaOrderMana.GetToppingMenuListCount(); i++)
            {
                _toppingMenuList.Add(_pizzaOrderMana.GetToppingMenu(i));
            }
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
            //チェックをしたときと外したときに処理が走るので一回目だけ処理をさせるようにした
            if (count == 0)
            {
                count++;
                slectedIndex = e.Index;
                OkButton.Enabled = e.CurrentValue == 0;
                _pizzaName = _pizzaOrderMana.GetPizzaEnum(e.Index);

                //すべてのトッピングを初期化
                for (int i = 0; i < _pizzaOrderMana.GetToppingMenuListCount(); i++)
                {
                    ToppingListView.Items[i].Checked = false;
                    ToppingListView.Items[i].BackColor = Color.White;
                    ToppingListView.Items[i].Tag = true;
                }

                var defotopping = new List<IMenuItem>();
                var pizzaInstance = _pizzaOrderMana.GetPizzaMenu(e.Index);

                //任意のDefaultトッピングを追加
                for (int i = 0; i < pizzaInstance.GetCountToppingList(); i++)
                {
                    defotopping.Add(pizzaInstance.GetTopping(i));
                }

                //リファクタリングできる
                //任意のピザのDefaultトッピングと全トッピングを比較する
                for (int i = 0; i < _pizzaOrderMana.GetToppingMenuListCount(); i++)
                {
                    for (int j = 0; j < defotopping.Count; j++)
                    {
                        if (defotopping[j].Name == ToppingListView.Items[i].Text)
                        {
                            _defotopping.Add(defotopping[j]);
                            ToppingListView.Items[i].Checked = true;
                            ToppingListView.Items[i].BackColor = Color.Gray;
                            ToppingListView.Items[i].Tag = false;
                        }
                    }
                }
            }
            else
            {
                count = 0;
                for (int i = 0; i < _pizzaOrderMana.GetToppingMenuListCount(); i++)
                {
                    ToppingListView.Items[i].Checked = false;
                    ToppingListView.Items[i].BackColor = Color.White;
                    ToppingListView.Items[i].Tag = true;
                }
            }
        }
    }
}
