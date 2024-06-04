using Models;
using Models.Manager;
using Models.Pizza;
using sub;
using System.Windows.Forms;

namespace PizzaOrderSystem2
{
    public partial class MainForm : Form
    {
        PizzaOrderManagement pizzaOrderMana = new PizzaOrderManagement();
        ToppingOrderManagement toppingOrderMana = new ToppingOrderManagement();
        public MainForm()
        {
            InitializeComponent();
        }

        private void OrderButton_Click(object sender, System.EventArgs e)
        {
            var subForm = new SubForm(pizzaOrderMana);
            if (DialogResult.OK == subForm.ShowDialog())
            {
                MainFormRefreshScreen();
            }
            MainFormRefreshScreen();
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void MainFormRefreshScreen()
        {
            OrderListView.Items.Clear();
            DetailsListView.Items.Clear();
            for (int i = 0; i < pizzaOrderMana.GetPizzaOrderListCount(); i++)
            {
                OrderListView.Items.Add(pizzaOrderMana.GetPizzaOrder(i).GetToppingOrder(0).GetName().ToString()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(i).GetTotalToppingPrice().ToString());
            }
            TotalAmountLabel.Text = $"合計： ￥{pizzaOrderMana.GetCalculatePizzaTotalPrice()}";
        }

        private void OrderListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChangeButtonState();
            var index = 0;
            if (OrderListView.SelectedItems.Count > 0)
            {
                index = OrderListView.SelectedItems[0].Index;
            }
            DetailsListView.Items.Clear();

            DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0).GetName().ToString()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0).GetPrice().ToString());

            IMenuItem tmp = pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0);

            //リファクタリング
            switch (tmp.GetName())
            {
                case "プレーンピザ":
                    PlainPizza plainPizza = (PlainPizza)tmp;
                    var count = plainPizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(plainPizza.GetDefaultTopping(i).GetName()).SubItems.Add(plainPizza.GetDefaultTopping(i).GetPrice().ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetName()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetPrice().ToString());
                    }
                    break;

                case "マルゲリータピザ":
                    MargheritaPizza margheritaPizza = (MargheritaPizza)tmp;
                    count = margheritaPizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(margheritaPizza.GetDefaultTopping(i).GetName()).SubItems.Add(margheritaPizza.GetDefaultTopping(i).GetPrice().ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetName()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetPrice().ToString());
                    }
                    break;

                case "シーフードピザ":
                    SeafoodPizza seafoodPizza = (SeafoodPizza)tmp;
                    count = seafoodPizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(seafoodPizza.GetDefaultTopping(i).GetName()).SubItems.Add(seafoodPizza.GetDefaultTopping(i).GetPrice().ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetName()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetPrice().ToString());
                    }
                    break;

                case "ペスカトーレピザ":
                    PescaTorePizza pescaTorePizza = (PescaTorePizza)tmp;
                    count = pescaTorePizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(pescaTorePizza.GetDefaultTopping(i).GetName()).SubItems.Add(pescaTorePizza.GetDefaultTopping(i).GetPrice().ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetName()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetPrice().ToString());
                    }
                    break;

                case "バンビーノピザ":
                    BambinoPizza bambinoPizza = (BambinoPizza)tmp;
                    count = bambinoPizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(bambinoPizza.GetDefaultTopping(i).GetName()).SubItems.Add(bambinoPizza.GetDefaultTopping(i).GetPrice().ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetName()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).GetPrice().ToString());
                    }
                    break;
            }
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            int index = 0;

            if (OrderListView.SelectedItems.Count > 0)
            {
                index = OrderListView.SelectedItems[0].Index;
            }
            pizzaOrderMana.RemovePizzaOrderList(index);
            MainFormRefreshScreen();
            ChangeButtonState();
        }

        public void ChangeButtonState()
        {
            DeleteButton.Enabled = OrderListView.SelectedItems.Count > 0;
            Changebutton.Enabled = OrderListView.SelectedItems.Count > 0;
        }
    }
}
