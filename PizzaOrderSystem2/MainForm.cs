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
                OrderListView.Items.Add(pizzaOrderMana.GetPizzaOrder(i).GetToppingOrder(0).Name.ToString()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(i).GetTotalToppingPrice().ToString());
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

            //選択したら詳細にピザがAddされている状態→追加処理のときにピザとトッピング両方を追加
            DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0).Name.ToString()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0).Price.ToString());

            IMenuItem toppingOrder = pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0);

            //リファクタリング??
            switch (toppingOrder.Name)
            {
                case "プレーンピザ":
                    PlainPizza plainPizza = (PlainPizza)toppingOrder;
                    var count = plainPizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(plainPizza.GetDefaultTopping(i).Name).SubItems.Add(plainPizza.GetDefaultTopping(i).Price.ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Name).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Price.ToString());
                    }
                    break;

                case "マルゲリータピザ":
                    MargheritaPizza margheritaPizza = (MargheritaPizza)toppingOrder;
                    count = margheritaPizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(margheritaPizza.GetDefaultTopping(i).Name).SubItems.Add(margheritaPizza.GetDefaultTopping(i).Price.ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Name).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Price.ToString());
                    }
                    break;

                case "シーフードピザ":
                    SeafoodPizza seafoodPizza = (SeafoodPizza)toppingOrder;
                    count = seafoodPizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(seafoodPizza.GetDefaultTopping(i).Name).SubItems.Add(seafoodPizza.GetDefaultTopping(i).Price.ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Name).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Price.ToString());
                    }
                    break;

                case "ペスカトーレピザ":
                    PescaTorePizza pescaTorePizza = (PescaTorePizza)toppingOrder;
                    count = pescaTorePizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(pescaTorePizza.GetDefaultTopping(i).Name).SubItems.Add(pescaTorePizza.GetDefaultTopping(i).Price.ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Name).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Price.ToString());
                    }
                    break;

                case "バンビーノピザ":
                    BambinoPizza bambinoPizza = (BambinoPizza)toppingOrder;
                    count = bambinoPizza.GetCountDefaultToppingList();

                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(bambinoPizza.GetDefaultTopping(i).Name).SubItems.Add(bambinoPizza.GetDefaultTopping(i).Price.ToString());
                    }

                    for (int i = 1; i < pizzaOrderMana.GetPizzaOrder(index).GetToppingOrderListCount(); i++)
                    {
                        DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Name).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(i).Price.ToString());
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
