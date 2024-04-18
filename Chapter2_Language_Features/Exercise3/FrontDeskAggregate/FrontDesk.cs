using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Exercise3.OrderAggregate;

namespace Exercise3.FrontDeskAggregate
{
    public class FrontDesk
    {
        private readonly ObservableCollection<IOrder> _ordersBackingField;
        public event OrderCreatedHandler OrderCreated;
        public ObservableCollection<IOrder> _ordersProperty { get { return _ordersBackingField; } }

        public FrontDesk()
        {
            _ordersBackingField = new ObservableCollection<IOrder>();
        }


        public void AddOrder(int numberOfBurgers)
        {
            Order order = new Order(numberOfBurgers);
            _ordersBackingField.Add(order);
            OrderCreated.Invoke(this,new OrderEventArgs(order));
        }

        public void RemoveCompletedOrders()
        {
        }
    }
}