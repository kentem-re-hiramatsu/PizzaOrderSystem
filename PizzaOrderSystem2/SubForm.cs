using Models;
using Models.Manager;
using Models.Pizza;
using Models.Topping;
using System;
using System.Windows.Forms;

namespace sub
{
    public partial class SubForm : Form
    {
        private string _pizzaName;
        private PizzaOrderManagement _pizzaOrderMana;
        //ToppingOrderManagement _toppingOrderMana = new ToppingOrderManagement();
        public SubForm(PizzaOrderManagement pizzaOrderMana)
        {
            InitializeComponent();
            _pizzaOrderMana = pizzaOrderMana;
            //_toppingOrderMana = toppingOrderMana;
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            RefreshScreen();
        }

        private void RefreshScreen()
        {
            //あとでリファクタリング！！
            //Managerにいれる　SubItemsは使わない
            MainMenuListView.Items.Add(new PlainPizza().GetName().ToString()).SubItems.Add($"￥{new PlainPizza().GetPrice()}");
            MainMenuListView.Items.Add(new MargheritaPizza().GetName().ToString()).SubItems.Add($"￥{new MargheritaPizza().GetPrice()}");
            MainMenuListView.Items.Add(new SeafoodPizza().GetName().ToString()).SubItems.Add($"￥{new SeafoodPizza().GetPrice()}");
            MainMenuListView.Items.Add(new PescaTorePizza().GetName().ToString()).SubItems.Add($"￥{new PescaTorePizza().GetPrice()}");
            MainMenuListView.Items.Add(new BambinoPizza().GetName().ToString()).SubItems.Add($"￥{new BambinoPizza().GetPrice()}");

            ToppingListView.Items.Add(new Cheese().GetName().ToString()).SubItems.Add($"￥{new Cheese().GetPrice()}");
            ToppingListView.Items.Add(new FriedGarlic().GetName().ToString()).SubItems.Add($"￥{new FriedGarlic().GetPrice()}");
            ToppingListView.Items.Add(new MozzarellaCheese().GetName().ToString()).SubItems.Add($"￥{new MozzarellaCheese().GetPrice()}");
            ToppingListView.Items.Add(new SeafoodMix().GetName().ToString()).SubItems.Add($"￥{new SeafoodMix().GetPrice()}");
            ToppingListView.Items.Add(new Scallops().GetName().ToString()).SubItems.Add($"￥{new Scallops().GetPrice()}");
            ToppingListView.Items.Add(new Basil().GetName().ToString()).SubItems.Add($"￥{new Basil().GetPrice()}");
            ToppingListView.Items.Add(new Tomato().GetName().ToString()).SubItems.Add($"￥{new Tomato().GetPrice()}");
            ToppingListView.Items.Add(new Tuna().GetName().ToString()).SubItems.Add($"￥{new Tuna().GetPrice()}");
            ToppingListView.Items.Add(new Corn().GetName().ToString()).SubItems.Add($"￥{new Corn().GetPrice()}");
            ToppingListView.Items.Add(new Bacon().GetName().ToString()).SubItems.Add($"￥{new Bacon().GetPrice()}");

            MainMenuListView.Items[0].Checked = true;
        }

        private void MainMenuListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int changedItemIndex = e.Index;

            foreach (ListViewItem item in MainMenuListView.Items)
            {
                if (!MainMenuListView.Items[changedItemIndex].Checked)
                {
                    item.Checked = false;
                }
            }


            OkButton.Enabled = e.CurrentValue == 0;

            //あとでリファクタリング！！
            switch (e.Index)
            {
                //プレーンピザ
                case 0:
                    _pizzaName = "プレーンピザ";

                    ToppingListView.Items[0].Checked = true;
                    ToppingListView.Items[6].Checked = true;

                    ToppingListView.Items[1].Checked = false;
                    ToppingListView.Items[2].Checked = false;
                    ToppingListView.Items[3].Checked = false;
                    ToppingListView.Items[4].Checked = false;
                    ToppingListView.Items[5].Checked = false;
                    ToppingListView.Items[7].Checked = false;
                    ToppingListView.Items[8].Checked = false;
                    ToppingListView.Items[9].Checked = false;

                    break;

                //マルゲリータピザ
                case 1:
                    _pizzaName = "マルゲリータピザ";

                    ToppingListView.Items[0].Checked = true;
                    ToppingListView.Items[2].Checked = true;
                    ToppingListView.Items[5].Checked = true;
                    ToppingListView.Items[6].Checked = true;

                    ToppingListView.Items[1].Checked = false;
                    ToppingListView.Items[3].Checked = false;
                    ToppingListView.Items[4].Checked = false;
                    ToppingListView.Items[7].Checked = false;
                    ToppingListView.Items[8].Checked = false;
                    ToppingListView.Items[9].Checked = false;
                    break;

                //シーフードピザ
                case 2:
                    _pizzaName = "シーフードピザ";

                    ToppingListView.Items[0].Checked = true;
                    ToppingListView.Items[3].Checked = true;

                    ToppingListView.Items[1].Checked = false;
                    ToppingListView.Items[2].Checked = false;
                    ToppingListView.Items[4].Checked = false;
                    ToppingListView.Items[5].Checked = false;
                    ToppingListView.Items[6].Checked = false;
                    ToppingListView.Items[7].Checked = false;
                    ToppingListView.Items[8].Checked = false;
                    ToppingListView.Items[9].Checked = false;
                    break;

                //ペスカトーレピザ
                case 3:
                    _pizzaName = "ペスカトーレピザ";

                    ToppingListView.Items[0].Checked = true;
                    ToppingListView.Items[3].Checked = true;
                    ToppingListView.Items[4].Checked = true;

                    ToppingListView.Items[1].Checked = false;
                    ToppingListView.Items[2].Checked = false;
                    ToppingListView.Items[5].Checked = false;
                    ToppingListView.Items[6].Checked = false;
                    ToppingListView.Items[7].Checked = false;
                    ToppingListView.Items[8].Checked = false;
                    ToppingListView.Items[9].Checked = false;
                    break;

                //バンビーノピザ
                case 4:
                    _pizzaName = "バンビーノピザ";

                    ToppingListView.Items[0].Checked = true;
                    ToppingListView.Items[6].Checked = true;
                    ToppingListView.Items[7].Checked = true;
                    ToppingListView.Items[8].Checked = true;
                    ToppingListView.Items[9].Checked = true;

                    ToppingListView.Items[1].Checked = false;
                    ToppingListView.Items[2].Checked = false;
                    ToppingListView.Items[3].Checked = false;
                    ToppingListView.Items[4].Checked = false;
                    ToppingListView.Items[5].Checked = false;
                    break;
            }
        }

        private void ToppingListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            IMenuItem pizza = null;
            var toppingOrderMana = new ToppingOrderManagement();

            switch (_pizzaName)
            {
                case "プレーンピザ":
                    pizza = new PlainPizza();
                    break;

                case "マルゲリータピザ":
                    pizza = new MargheritaPizza();
                    break;

                case "シーフードピザ":
                    pizza = new SeafoodPizza();
                    break;

                case "ペスカトーレピザ":
                    pizza = new PescaTorePizza();
                    break;

                case "バンビーノピザ":
                    pizza = new BambinoPizza();
                    break;
            }
            toppingOrderMana.AddToppingOrderList(pizza);
            _pizzaOrderMana.AddPizzaOrderList(toppingOrderMana);
            Close();
        }
    }
}
