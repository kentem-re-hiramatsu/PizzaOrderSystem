using System.Collections.Generic;

namespace Models.Manager
{
    public class ToppingOrderManagement
    {
        private List<IMenuItem> _toppingOrderList;

        public ToppingOrderManagement()
        {
            _toppingOrderList = new List<IMenuItem>();
        }

        public void AddToppingOrderList(IMenuItem pizzaMenu)
        {
            _toppingOrderList.Add(pizzaMenu);
        }

        public IMenuItem GetToppingOrder(int index)
        {
            return _toppingOrderList[index];
        }

        public int GetToppingOrderListCount()
        {
            return _toppingOrderList.Count;
        }

        public void RemoveToppingOrderList(int index)
        {
            _toppingOrderList.RemoveAt(index);
        }

        public int GetTotalToppingPrice()
        {
            int total = 0;

            for (int i = 0; i < GetToppingOrderListCount(); i++)
            {
                total += _toppingOrderList[i].GetPrice();
            }
            return total;
        }
    }

}
