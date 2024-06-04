using Models;
using Models.Manager;
using Models.Pizza;
using Models.Topping;
using System;
using System.Collections.Generic;
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

        //ピザ単一選択
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

            //リファクタリングできそう？
            switch (e.Index)
            {
                case 0:
                    _pizzaName = "プレーンピザ";

                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 0 || i == 6)
                        {
                            ToppingListView.Items[i].Checked = true;
                            ToppingListView.Items[i].Tag = false;
                        }
                        else
                        {
                            ToppingListView.Items[i].Checked = false;
                            ToppingListView.Items[i].Tag = true;
                        }

                    }
                    break;

                case 1:
                    _pizzaName = "マルゲリータピザ";

                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 0 || i == 2 || i == 5 || i == 6)
                        {
                            ToppingListView.Items[i].Checked = true;
                            ToppingListView.Items[i].Tag = false;
                        }
                        else
                        {
                            ToppingListView.Items[i].Checked = false;
                            ToppingListView.Items[i].Tag = true;
                        }

                    }
                    break;

                case 2:
                    _pizzaName = "シーフードピザ";

                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 0 || i == 3)
                        {
                            ToppingListView.Items[i].Checked = true;
                            ToppingListView.Items[i].Tag = false;
                        }
                        else
                        {
                            ToppingListView.Items[i].Checked = false;
                            ToppingListView.Items[i].Tag = true;
                        }

                    }
                    break;

                case 3:
                    _pizzaName = "ペスカトーレピザ";

                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 0 || i == 3 || i == 4)
                        {
                            ToppingListView.Items[i].Checked = true;
                            ToppingListView.Items[i].Tag = false;
                        }
                        else
                        {
                            ToppingListView.Items[i].Checked = false;
                            ToppingListView.Items[i].Tag = true;
                        }

                    }
                    break;

                case 4:
                    _pizzaName = "バンビーノピザ";

                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 0 || i == 6 || i == 7 || i == 8 || i == 9)
                        {
                            ToppingListView.Items[i].Checked = true;
                            ToppingListView.Items[i].Tag = false;
                        }
                        else
                        {
                            ToppingListView.Items[i].Checked = false;
                            ToppingListView.Items[i].Tag = true;
                        }
                    }
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
