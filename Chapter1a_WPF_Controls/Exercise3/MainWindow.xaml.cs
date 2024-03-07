using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RepeatButton_Click_Grow(object sender, RoutedEventArgs e)
        {

            if (canvasTest.Width > testname.Width + 10)
            {
                testname.Height += 10;
                testname.Width += 10;
            }
        
        }

        private void RepeatButton_Click_Shrink(object sender, RoutedEventArgs e)
        {
            if(testname.Width - 10  > 0)
            {
                testname.Height -= 10;
                testname.Width -= 10;
            }

        }
    }

}