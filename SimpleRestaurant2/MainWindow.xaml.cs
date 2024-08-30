using SimpleRestaurant2.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleRestaurant2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Server _server = new Server();

        public MainWindow()
        {
            InitializeComponent();

            // set the ComboBox's ItemsSource to the Enum values
            drinksComboBox.ItemsSource = new string[]{ "Tea", "Coca-Cola", "Pepsi", "No drink"};
            drinksComboBox.SelectedValue = "No drink";
        }

        private void checkNumericInput(object sender, KeyEventArgs e)
        {
            // event handler for preventing unwanted input
            if ((e.Key < Key.D0 || e.Key > Key.D9) 
                && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)     // checking if it's not a decimal
                && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void receiveButton_Click(object sender, RoutedEventArgs e)
        {
            int chickenQuantity, eggQuantity;

            if (Int32.TryParse(chickenInput.Text, out chickenQuantity) 
                && Int32.TryParse(eggInput.Text, out eggQuantity))
            {
                try
                {
                    _server.Recieve(chickenQuantity, eggQuantity, drinksComboBox.SelectedValue.ToString());
                    resultsTextBlock.Text += "\nServer received order from customer " + (_server.CustomerCount - 1);
                }
                catch (Exception ex)
                {
                    resultsTextBlock.Text += $"\nError: {ex.Message}";
                }
            }
            else
            {
                resultsTextBlock.Text += "\nWarning: enter an numeric value of quantity";
            }
        }

        private void sendRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _server.SendRequests();
                resultsTextBlock.Text += "\nCook received all the requests";
                Thread.Sleep(2000);
                resultsTextBlock.Text += "\nCook prepared all the food";

            }
            catch (Exception ex)
            {
                resultsTextBlock.Text += $"\nError: {ex.Message}";
            }
        }

        private void serveRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultsTextBlock.Text += _server.ServeRequests();
            }
            catch (Exception ex)
            {
                resultsTextBlock.Text += $"\nError: {ex.Message}";
            }
        }
    }
}