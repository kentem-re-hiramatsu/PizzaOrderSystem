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

        private List<PizzaMenu> _pizzaMenuList = new List<PizzaMenu>();
        private List<ToppingMenu> _toppingMenuList = new List<ToppingMenu>();

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

        private void RefreshScreen()
        {
            for (int i = 0; i < _pizzaMenuList.Count; i++)
            {
                MainMenuListView.Items.Add(new ListViewItem(new string[] { _pizzaMenuList[i].Name, _pizzaMenuList[i].Price.ToString() }));
            }
            for (int i = 0; i < _toppingMenuList.Count; i++)
            {
                ToppingListView.Items.Add(new ListViewItem(new string[] { _toppingMenuList[i].Name, _toppingMenuList[i].Price.ToString() }));
            }

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
                    _pizzaName = new PlainPizza().Name;
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(6);
                    break;

                case 1:
                    _pizzaName = new MargheritaPizza().Name;
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(2);
                    defaultToppingList.Add(5);
                    defaultToppingList.Add(6);
                    break;

                case 2:
                    _pizzaName = new SeafoodPizza().Name;
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(3);
                    break;

                case 3:
                    _pizzaName = new PescaTorePizza().Name;
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(3);
                    defaultToppingList.Add(4);
                    break;

                case 4:
                    _pizzaName = new BambinoPizza().Name;
                    defaultToppingList.Add(0);
                    defaultToppingList.Add(6);
                    defaultToppingList.Add(7);
                    defaultToppingList.Add(8);
                    defaultToppingList.Add(9);
                    break;
                default: break;
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
                default: break;
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
    }
}
