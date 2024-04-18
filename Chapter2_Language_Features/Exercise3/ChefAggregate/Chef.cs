using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using Exercise3.FrontDeskAggregate;
using Exercise3.OrderAggregate;

namespace Exercise3.ChefAggregate
{
    public class Chef
    {
        private readonly FrontDesk _frontdesk;
        private IChefActions _chefActions;
        private Queue<IOrder> _orders = new Queue<IOrder>();
        public Chef(FrontDesk frontDesk, IChefActions chefActions)
        { 
            this._frontdesk = frontDesk;
            this._chefActions = chefActions;
            this._frontdesk.OrderCreated += (Object sender, OrderEventArgs x) => { _orders.Enqueue(x.Order); };
        }


        public void StartProcessingOrders(CancellationToken cancellationToken)
        {
            //Task.Factory.StartNew invokes an action in a new thread so that the calculation does not block the UI thread (otherwise the UI would hang)
            Task.Factory.StartNew(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if(_orders.Count > 0)
                    {
                       Order order = (Order) _orders.Dequeue();
                        order.IsStarted = true;
                        for (global::System.Int32 i = 0; i < order.NumberOfBurgers; i++)
                        {
                            _chefActions.CookBurger();
                        }
                        _chefActions.TakeABreather();
                        order.IsCompleted = true;
                    }
                    
                    //TODO: check if the queue contains an order. If so -> process it.
                }
            }, cancellationToken);
        }
    }
}