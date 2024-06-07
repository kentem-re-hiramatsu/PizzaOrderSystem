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

        /// <summary>
        /// 注文リストビューと詳細リストビューを更新
        /// </summary>
        private void MainFormRefreshScreen()
        {
            //注文リストと詳細をクリア
            OrderListView.Items.Clear();
            DetailsListView.Items.Clear();

            //注文リストViewにピザ追加
            foreach (IMenuItem pizza in pizzaOrderMana.GetPizzaOrderList())
            {
                OrderListView.Items.Add(new ListViewItem(new string[] { pizza.Name, (pizza.Price + ((PizzaMenu)pizza).GetTotalToppingPrice()).ToString() }));
            }

            //注文合計更新
            TotalAmountLabel.Text = $"合計： ￥{pizzaOrderMana.GetPizzaTotalPrice()}";
        }

        /// <summary>
        /// ピザを選択した時に詳細を出力する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChangeButtonState();

            var index = 0;

            //ピザを選択しているか判断
            if (OrderListView.SelectedItems.Count > 0)
            {
                index = OrderListView.SelectedItems[0].Index;
            }
            DetailsListView.Items.Clear();

            //選択したピザを取得
            IMenuItem pizzaOrder = pizzaOrderMana.GetPizzaOrder(index);

            PizzaMenu pizza = (PizzaMenu)pizzaOrder;

            int count = pizza.GetCountToppingList();

            //ピザ選択時詳細リストビューに追加する処理
            for (int i = 0; i < count; i++)
            {
                DetailsListView.Items.Add(new ListViewItem(new string[] { pizza.GetTopping(i).Name, pizza.GetTopping(i).Price.ToString() }));
            }
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            int index = 0;

            //選択されたか
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
            //ピザが選択されたら削除・変更ボタンを活性化
            DeleteButton.Enabled = OrderListView.SelectedItems.Count > 0;
            Changebutton.Enabled = OrderListView.SelectedItems.Count > 0;
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            //toppingOrderMana.LoadDataFile(pizzaOrderMana);
            //MainFormRefreshScreen();
        }

        //ERROR修正未完
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //toppingOrderMana.SavePizzaDataFile(pizzaOrderMana);
        }

        private void Changebutton_Click(object sender, System.EventArgs e)
        {
            //int index;
            //index = OrderListView.SelectedItems[0].Index;

            //var changeForm = new ChangeForm(pizzaOrderMana, index);

            //if (DialogResult.OK == changeForm.ShowDialog())
            //{
            //    MainFormRefreshScreen();
            //}
            //MainFormRefreshScreen();
        }
    }
}
