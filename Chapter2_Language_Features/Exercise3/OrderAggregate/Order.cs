using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Exercise3.OrderAggregate
{
    public class Order : IOrder, INotifyPropertyChanged
    {
        public OrderNumber Number { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public int NumberOfBurgers { get; set; }

        private bool started;
        private bool completed;


        public bool IsStarted { 
            get { return started; } 
            set { started = value; PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsStarted")); } }

        public bool IsCompleted {
            get { return completed; }
            set { completed = value; PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsCompleted")); } }

        public Order(int numberOfBurgers) 
        {
            NumberOfBurgers = numberOfBurgers;
            
            Number = OrderNumber.CreateNext();
            
        }

    }
}
