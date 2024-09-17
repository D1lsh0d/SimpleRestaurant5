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
        private Cook _cook = new Cook();
        public MainWindow()
        {
            InitializeComponent();

            // subscribing Process method to ServerRecoerdedOrders event
            _server.Subscribe(_cook.Process);
            // subscribing ServeRequests method to CookPreparedFood event
            _cook.Subscribe(_server.ServeRequests);
            // subscribing OnFoodPrepared with a TextBlock argument usinf lambda expression
            _cook.Subscribe(() => OnFoodPrepared(resultsTextBlock));

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
                    _server.Recieve(chickenQuantity, eggQuantity, drinksComboBox.SelectedValue.ToString(), nameInput.Text);
                    resultsTextBlock.Text += "\nServer received order from customer " + (nameInput.Text);
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
                resultsTextBlock.Text += "\nCook received all the requests";
                _server.OnServerFinishedRecording();
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
                _server.ServeRequests();
                resultsTextBlock.Text += _server.Results;
            }
            catch (Exception ex)
            {
                resultsTextBlock.Text += $"\nError: {ex.Message}";
            }
        }

        private void OnFoodPrepared(TextBlock textBlock)
        {
            textBlock.Text += "\nCook prepared all the food";
            textBlock.Text += _server.Results;
        }
    }
}