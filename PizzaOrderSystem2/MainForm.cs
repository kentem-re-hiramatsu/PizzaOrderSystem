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
            for (int i = 0; i < pizzaOrderMana.GetPizzaOrderListCount(); i++)
            {
                OrderListView.Items.Add(pizzaOrderMana.GetPizzaOrder(i).GetToppingOrder(0).GetName().ToString());
            }
        }

        private void OrderListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var index = 0;
            if (OrderListView.SelectedItems.Count > 0)
            {
                index = OrderListView.SelectedItems[0].Index;
            }
            DetailsListView.Items.Clear();
            DetailsListView.Items.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0).GetName().ToString()).SubItems.Add(pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0).GetPrice().ToString());

            IMenuItem tmp = pizzaOrderMana.GetPizzaOrder(index).GetToppingOrder(0);
            switch (tmp.GetName())
            {
                case "プレーンピザ":
                    PlainPizza plainPizza = (PlainPizza)tmp;
                    var count = plainPizza.GetCountDefaultToppingList();
                    for (int i = 0; i < count; i++)
                    {
                        DetailsListView.Items.Add(plainPizza.GetDefaultTopping(i).GetName()).SubItems.Add(plainPizza.GetDefaultTopping(i).GetPrice().ToString());
                    }
                    break;

                case "マルゲリータピザ":
                    MargheritaPizza margheritaPizza = (MargheritaPizza)tmp;
                    break;

                case "シーフードピザ":
                    SeafoodPizza seafoodPizza = (SeafoodPizza)tmp;
                    break;

                case "ペスカトーレピザ":
                    PescaTorePizza pescaTorePizza = (PescaTorePizza)tmp;
                    break;

                case "バンビーノピザ":
                    BambinoPizza bambinoPizza = (BambinoPizza)tmp;
                    break;
            }
        }
    }
}
