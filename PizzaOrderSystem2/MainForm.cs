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
                OrderListView.Items.Add(new ListViewItem(new string[] { pizzaOrderMana.GetPizzaOrder(i).GetToppingOrder(0).Name.ToString(), pizzaOrderMana.GetPizzaOrder(i).GetTotalToppingPrice().ToString() }));
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

            IMenuItem toppingOrder = pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0);

            PizzaMenu pizza = null;
            int count;

            switch (toppingOrder.Name)
            {
                case "プレーンピザ":
                    pizza = (PlainPizza)toppingOrder;
                    break;

                case "マルゲリータピザ":
                    pizza = (MargheritaPizza)toppingOrder;
                    break;

                case "シーフードピザ":
                    pizza = (SeafoodPizza)toppingOrder;
                    break;

                case "ペスカトーレピザ":
                    pizza = (PescaTorePizza)toppingOrder;
                    break;

                case "バンビーノピザ":
                    pizza = (BambinoPizza)toppingOrder;
                    break;
                default: break;
            }
            count = pizza.GetCountDefaultToppingList();
            DetailsListView.Items.Add(new ListViewItem(new string[] { pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0).Name.ToString(), pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0).Price.ToString() }));

            for (int i = 0; i < count; i++)
            {
                DetailsListView.Items.Add(new ListViewItem(new string[] { pizza.GetDefaultTopping(i).Name, pizza.GetDefaultTopping(i).Price.ToString() }));
            }

            for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
            {
                DetailsListView.Items.Add(new ListViewItem(new string[] { pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Name, pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Price.ToString() }));
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

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            toppingOrderMana.LoadDataFile(pizzaOrderMana);
            MainFormRefreshScreen();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            toppingOrderMana.SavePizzaDataFile(pizzaOrderMana);
        }
    }
}
