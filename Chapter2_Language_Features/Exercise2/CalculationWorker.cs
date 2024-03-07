using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Exercise2
{
    public class CalculationWorker
    {
        public event CalculationCompleteHandler calculationCompleteHandler;

        public async void DoWork(int[] inputs, Func<int, long> mathOperation)
        {
          
            //Task.Factory.StartNew invokes an action in a new thread so that the calculation does not block the UI thread (otherwise the UI would hang)
            Task.Factory.StartNew(() =>
            {
            CalculationEventArgs test = null;
               
                for(int i = 0; i < inputs.Length; i++)
                {
                    
                    test =  new CalculationEventArgs(mathOperation(inputs.ElementAt(i)), (i + 1.0) / inputs.Length);
                    calculationCompleteHandler.Invoke(this, test);
                }
                //TODO: do the calculations here and notify subscribers about each finished calculation
            });
        }
    }
}
