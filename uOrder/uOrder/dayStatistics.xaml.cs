using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace uOrder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public class dayilyStatistic
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public dayilyStatistic(string name, double sales)
        {
            Name = name;
            Amount = sales;
        }
    }
    public sealed partial class dayStatistics : Page
    {
        public dayStatistics()
        {
            this.InitializeComponent();
            List<dayilyStatistic> stats = new List<dayilyStatistic>();
            List<Product> products = new List<Product>();
            List<double> count = new List<double>();
            double total = 0;
            for (int i = 0; i < orderManagement.allOrders.Count; i++)
            {
                Order ord = orderManagement.allOrders[i];
                for (int j = 0; j < ord.products.Count; j++)
                {
                    if (products.Contains(ord.products[j]))
                    {
                        count[products.IndexOf(ord.products[j])] = count[products.IndexOf(ord.products[j])] + ord.products[j].prodPrice;
                    }
                    else
                    {
                        products.Add(ord.products[j]);
                        count.Add(ord.products[j].prodPrice);
                    }
                }
                total += ord.price;

            }
            for (int i = 0; i < products.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(products[i].prodName + ", " + count[i]);
                stats.Add(new dayilyStatistic(products[i].prodName, count[i]));
            }


            totalOrders.Text = orderManagement.allOrders.Count.ToString();
            totalMoney.Text = total.ToString("C");
            (chart.Series[0] as ColumnSeries).ItemsSource = stats;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
