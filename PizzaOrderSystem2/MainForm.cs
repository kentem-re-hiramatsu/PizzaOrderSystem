using Models.Manager;
using Models.Pizza;
using sub;
using System.Windows.Forms;

namespace PizzaOrderSystem2
{
    public partial class MainForm : Form
    {
        private PizzaOrderManagement _pizzaOrderMana = new PizzaOrderManagement();
        public MainForm()
        {
            InitializeComponent();
        }

        private void OrderButton_Click(object sender, System.EventArgs e)
        {
            var subForm = new SubForm(_pizzaOrderMana, GetSelectedIndex(), true);
            if (DialogResult.OK == subForm.ShowDialog())
            {
                MainFormRefreshScreen();
            }

            //選択を外す
            if (GetSelectedIndex() >= 0)
            {
                OrderListView.SelectedIndices.Clear();
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

            OrderListView.SelectedItems.Clear();

            //注文リストViewにピザ追加
            foreach (var pizza in _pizzaOrderMana.PizzaOrderList)
            {
                OrderListView.Items.Add(new ListViewItem(new string[] { pizza.Name, pizza.GetPizzaTotalPrice().ToString() }));
            }

            //注文合計更新
            TotalAmountLabel.Text = $"合計： ￥{_pizzaOrderMana.GetTotalPrice()}";
        }

        /// <summary>
        /// ピザを選択した時に詳細を出力する処理
        /// </summary>
        private void OrderListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChangeButtonState();

            DetailsListView.Items.Clear();

            //選択したピザを取得
            PizzaMenu pizzaOrder = _pizzaOrderMana.GetPizzaOrder(GetSelectedIndex());

            DetailsListView.Items.Add(new ListViewItem(new string[] { pizzaOrder.Name, pizzaOrder.Price.ToString() }));

            foreach (var topping in pizzaOrder.ToppingList)
            {
                DetailsListView.Items.Add(new ListViewItem(new string[] { topping.Name, topping.Price.ToString() }));
            }
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            int index = GetSelectedIndex();

            _pizzaOrderMana.RemovePizzaOrderList(index);
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
            _pizzaOrderMana.LoadDataFile();
            MainFormRefreshScreen();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pizzaOrderMana.SavePizzaDataFile();
        }

        /// <summary>
        /// 選択されたリストビューのindexを返す
        /// </summary>
        public int GetSelectedIndex()
        {
            int index = 0;

            if (OrderListView.SelectedItems.Count > 0)
            {
                index = OrderListView.SelectedItems[0].Index;
            }
            return index;
        }

        private void Changebutton_Click(object sender, System.EventArgs e)
        {
            var changeForm = new SubForm(_pizzaOrderMana, GetSelectedIndex(), false);

            if (DialogResult.OK == changeForm.ShowDialog())
            {
                MainFormRefreshScreen();
            }

            //選択を外す
            if (GetSelectedIndex() >= 0)
            {
                OrderListView.SelectedIndices.Clear();
            }
            MainFormRefreshScreen();
        }
    }
}
