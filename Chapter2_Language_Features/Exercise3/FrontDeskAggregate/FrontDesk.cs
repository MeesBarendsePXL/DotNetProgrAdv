using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Exercise3.OrderAggregate;

namespace Exercise3.FrontDeskAggregate
{
    public class FrontDesk
    {
        public event OrderCreatedHandler OrderCreated;
        private readonly ObservableCollection<IOrder> _ordersBackingField = new ObservableCollection<IOrder>();
        public ObservableCollection<IOrder> _ordersProperty { get { return _ordersBackingField; } }


        public void AddOrder(int numberOfBurgers)
        {
        }

        public void RemoveCompletedOrders()
        {
        }
    }
}