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

    public class FinancialStuff
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class financialStatistics : Page
    {
        public financialStatistics()
        {
            this.InitializeComponent();
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();
            DateTimeOffset start = dateBegin.Date;
            DateTimeOffset end = dateEnd.Date;
            TimeSpan diff = (end - start);
            if (diff.Days > 500)
            {
                for (int i = 1; i <= Math.Ceiling(diff.Days/365.0); i++)
                {
                    financialStuffList.Add(new FinancialStuff() { Name = "Year " + i, Amount = rand.Next(200000, 1000000) });
                }
            }else if (diff.Days > 45)
            {
                for (int i = 1; i <= Math.Ceiling(diff.Days / 30.0); i++)
                {
                    financialStuffList.Add(new FinancialStuff() { Name = "Month " + i, Amount = rand.Next(20000, 60000) });
                }
            }else
            {
                for (int i = 1; i <= diff.Days+1; i++)
                {
                    financialStuffList.Add(new FinancialStuff() { Name = "Day " + i, Amount = rand.Next(0, 2000) });
                }
            }


            (PieChart.Series[0] as ColumnSeries).ItemsSource = financialStuffList;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(managementPage));
        }
    }
}