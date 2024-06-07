using Models.Manager;
using Models.Pizza;
using Models.Topping;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ChangeForm : Form
    {
        private PizzaOrderManagement _pizzaOrderMana;
        private int _selectedIndex;
        private List<PizzaMenu> _pizzaMenuList = new List<PizzaMenu>();
        private List<ToppingMenu> _toppingMenuList = new List<ToppingMenu>();

        public ChangeForm(PizzaOrderManagement pizzaOrderMana, int selectedIndex)
        {
            InitializeComponent();
            _pizzaOrderMana = pizzaOrderMana;
            _selectedIndex = selectedIndex;
            GetPizzaMenuList();
            GetToppingMenuList();
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ToppingListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void MainMenuListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
        public void GetPizzaMenuList()
        {
            for (int i = 0; i < _pizzaOrderMana.PizzaMenuList.Count; i++)
            {
                _pizzaMenuList.Add(_pizzaOrderMana.GetPizzaMenu(i));
            }
        }

        public void GetToppingMenuList()
        {
            for (int i = 0; i < _pizzaOrderMana.ToppingMenuList.Count; i++)
            {
                _toppingMenuList.Add(_pizzaOrderMana.GetToppingMenu(i));
            }
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
        }

        private void ChangeForm_Load(object sender, System.EventArgs e)
        {
            RefreshScreen();
        }
        public void DefaultValueSet()
        {
            var pizzaName = _pizzaOrderMana.GetPizzaMenu(_selectedIndex).Name;
            int num = 0;
            switch (pizzaName)
            {
                case "プレーンピザ":
                    num = 0;
                    break;

                case "マルゲリータピザ":
                    num = 1;
                    break;

                case "シーフードピザ":
                    num = 2;
                    break;

                case "ペスカトーレピザ":
                    num = 3;
                    break;

                case "バンビーノピザ":
                    num = 4;
                    break;
                default: break;
            }
            MainMenuListView.Items[num].Checked = true;
        }
    }
}
