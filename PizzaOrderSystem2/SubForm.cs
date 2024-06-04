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
        private string _pizzaName;
        private PizzaOrderManagement _pizzaOrderMana;

        public SubForm(PizzaOrderManagement pizzaOrderMana)
        {
            InitializeComponent();
            _pizzaOrderMana = pizzaOrderMana;
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            RefreshScreen();
        }

        private void RefreshScreen()
        {
            //あとでリファクタリング！！
            //Managerにいれる　SubItemsは使わない
            MainMenuListView.Items.Add(new PlainPizza().Name.ToString()).SubItems.Add($"￥{new PlainPizza().Price}");
            MainMenuListView.Items.Add(new MargheritaPizza().Name.ToString()).SubItems.Add($"￥{new MargheritaPizza().Price}");
            MainMenuListView.Items.Add(new SeafoodPizza().Name.ToString()).SubItems.Add($"￥{new SeafoodPizza().Price}");
            MainMenuListView.Items.Add(new PescaTorePizza().Name.ToString()).SubItems.Add($"￥{new PescaTorePizza().Price}");
            MainMenuListView.Items.Add(new BambinoPizza().Name.ToString()).SubItems.Add($"￥{new BambinoPizza().Price}");

            ToppingListView.Items.Add(new Cheese().Name.ToString()).SubItems.Add($"￥{new Cheese().Price}");
            ToppingListView.Items.Add(new FriedGarlic().Name.ToString()).SubItems.Add($"￥{new FriedGarlic().Price}");
            ToppingListView.Items.Add(new MozzarellaCheese().Name.ToString()).SubItems.Add($"￥{new MozzarellaCheese().Price}");
            ToppingListView.Items.Add(new SeafoodMix().Name.ToString()).SubItems.Add($"￥{new SeafoodMix().Price}");
            ToppingListView.Items.Add(new Scallops().Name.ToString()).SubItems.Add($"￥{new Scallops().Price}");
            ToppingListView.Items.Add(new Basil().Name.ToString()).SubItems.Add($"￥{new Basil().Price}");
            ToppingListView.Items.Add(new Tomato().Name.ToString()).SubItems.Add($"￥{new Tomato().Price}");
            ToppingListView.Items.Add(new Tuna().Name.ToString()).SubItems.Add($"￥{new Tuna().Price}");
            ToppingListView.Items.Add(new Corn().Name.ToString()).SubItems.Add($"￥{new Corn().Price}");
            ToppingListView.Items.Add(new Bacon().Name.ToString()).SubItems.Add($"￥{new Bacon().Price}");

            MainMenuListView.Items[0].Checked = true;
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

            OkButton.Enabled = e.CurrentValue == 0;

            for (int i = 0; i < 10; i++)
            {
                ToppingListView.Items[i].Tag = true;
            }

            var defaultToppingList = new List<int>();

            switch (e.Index)
            {
                case 0:
                    _pizzaName = "プレーンピザ";
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(6);
                    break;

                case 1:
                    _pizzaName = "マルゲリータピザ";
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(2);
                    defaultToppingList.Add(5);
                    defaultToppingList.Add(6);
                    break;

                case 2:
                    _pizzaName = "シーフードピザ";
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(3);
                    break;

                case 3:
                    _pizzaName = "ペスカトーレピザ";
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(3);
                    defaultToppingList.Add(4);
                    break;

                case 4:
                    _pizzaName = "バンビーノピザ";
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(6);
                    defaultToppingList.Add(7);
                    defaultToppingList.Add(8);
                    defaultToppingList.Add(9);
                    break;
            }
            for (int i = 0; i < 10; i++)
            {
                ToppingListView.Items[i].Checked = false;
                ToppingListView.Items[i].BackColor = Color.White;
                ToppingListView.Items[i].Tag = true;
            }
            foreach (int defaultToppin in defaultToppingList)
            {
                ToppingListView.Items[defaultToppin].Checked = true;
                ToppingListView.Items[defaultToppin].BackColor = Color.Gray;
                ToppingListView.Items[defaultToppin].Tag = false;
            }
        }

        private void ToppingListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!(bool)ToppingListView.Items[e.Index].Tag)
            {
                e.NewValue = CheckState.Checked;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            IMenuItem pizza = null;
            var toppingOrderMana = new ToppingOrderManagement();
            var toppings = new List<(int, ToppingMenu toppingMenu)>
            {
                (0,new Cheese()),
                (1,new FriedGarlic()),
                (2,new MozzarellaCheese()),
                (3,new SeafoodMix()),
                (4,new Scallops()),
                (5,new Basil()),
                (6,new Tomato()),
                (7,new Tuna()),
                (8,new Corn()),
                (9,new Bacon()),
            };

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

            foreach (var (index, topping) in toppings)
            {
                if (ToppingListView.Items[index].Checked && (bool)ToppingListView.Items[index].Tag)
                    toppingOrderMana.AddToppingOrderList(topping);
            }
            Close();
        }
    }
}
