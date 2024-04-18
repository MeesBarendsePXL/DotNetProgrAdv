using System.Runtime.CompilerServices;

namespace Exercise3.OrderAggregate
{
    public struct OrderNumber
    {
        public String id {  get; set; }
        public static int Number { get; set; }
        public static int Sequence { get { if (Number < 1) { return 1; } return Number; } }

        public OrderNumber(int number =2)
        {
            Number = number;
        }

        public static OrderNumber CreateNext()
        {
             

            return new OrderNumber(IntegerExtensions.CircularIncrement(Sequence, 1, 99));
        }
        public override String ToString()
        {
            return "#" + Number.ToString();
        }
    }
}