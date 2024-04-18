using System;
using System.Windows;

namespace Exercise2
{
    public partial class MainWindow : Window
    {
        private readonly IMathOperationFactory _operationFactory;
        private readonly CalculationWorker _worker;
        private readonly CalculationCompleteHandler _completeHandler = null;

        public MainWindow(IMathOperationFactory operationFactory)
        {
            InitializeComponent();
            _operationFactory = operationFactory;
            _worker = new CalculationWorker();
            
            _worker.calculationCompleteHandler += (Object sender, CalculationEventArgs x) => { updateProgressBar(x); };


        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            outputTextBlock.Text = String.Empty;
            int[] inputs = new int[inputTextBox.Text.TrimEnd().TrimStart().Split(" ").Length];
            if (inputTextBox.Text == "")
            {
                calculationProgressBar.Value = 0;
                outputTextBlock.Text = "";
                return;
            }
            foreach (String item in inputTextBox.Text.TrimEnd().TrimStart().Split(" "))
            {
                inputs.Append(int.Parse(item));
            }
            if (cubicRadioButton.IsChecked == true)
            {
                _worker.DoWork(inputs,_operationFactory.CreateCubicOperation());
            }
            if(nthPrimeRadioButton.IsChecked == true)
            {
                _worker.DoWork(inputs, _operationFactory.CreateNthPrimeOperation());
            }
        }

        private void updateProgressBar(CalculationEventArgs args)
        {
            
            Dispatcher.InvokeAsync(()=> {

                calculationProgressBar.Value = args.ProgressPercentage;
                outputTextBlock.Text += " " + args.Result.ToString();
                outputTextBlock.Text = outputTextBlock.Text.TrimStart();
            });
        }


    }
}
