using Models;
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
            var subForm = new SubForm(_pizzaOrderMana);
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
            foreach (IMenuItem pizza in _pizzaOrderMana.PizzaOrderList)
            {
                OrderListView.Items.Add(new ListViewItem(new string[] { pizza.Name, ((PizzaMenu)pizza).GetPizzaTotalPrice().ToString() }));
            }

            //注文合計更新
            TotalAmountLabel.Text = $"合計： ￥{_pizzaOrderMana.GetTotalPrice()}";
        }

        /// <summary>
        /// ピザを選択した時に詳細を出力する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChangeButtonState();

            DetailsListView.Items.Clear();

            //選択したピザを取得
            IMenuItem pizzaOrder = _pizzaOrderMana.GetPizzaOrder(GetSelectedIndex());

            PizzaMenu pizza = (PizzaMenu)pizzaOrder;

            DetailsListView.Items.Add(new ListViewItem(new string[] { pizzaOrder.Name, pizzaOrder.Price.ToString() }));

            //ピザ選択時詳細リストビューに追加する処理
            for (int i = 0; i < pizza.ToppingList.Count; i++)
            {
                DetailsListView.Items.Add(new ListViewItem(new string[] { pizza.GetTopping(i).Name, pizza.GetTopping(i).Price.ToString() }));
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

        //ERROR修正未完
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pizzaOrderMana.SavePizzaDataFile();
        }

        /// <summary>
        /// 選択されたリストビューのindexを返す
        /// </summary>
        /// <returns></returns>
        public int GetSelectedIndex()
        {
            int index = 0;

            if (OrderListView.SelectedItems.Count > 0)
            {
                index = OrderListView.SelectedItems[0].Index;
            }
            return index;
        }
    }
}
