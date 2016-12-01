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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App4
{

    public sealed partial class viewOrder : Page
    {
        public static List<String> myorder = new List<String>();    //List that holds the products of the order. 
        public static List<double> prices = new List<double>();     //List that holds the prices of the order. 

        public viewOrder()
        {
            this.InitializeComponent();
        }


        private void gotomenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage)); 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(preparingScreen));
        }

        private void totalprice_Loaded(object sender, RoutedEventArgs e)
        {
            totalprice.Text = "€" + getTotalPrice(prices).ToString("N2");
        }

        /*
         Function that calculates the total price of the order. 
        */
        public static double getTotalPrice(List<double> prices)
        {
            double total = 0;
            for (int i = 0; i < prices.Count; i++)
            {
                total += prices[i];
            }
            return total;
        }

        /*
            Shows the products of the order on the screen. 
        */
        private void currentorder_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < myorder.Count; i++)
            {
                CheckBox c = new CheckBox();
                c.Content=myorder[i];
                currentorder.Children.Add(c);
            }
        }

        /*
            Removes the selected products from the order. 
        */
        private void remove_Click(object sender, RoutedEventArgs e)
        {
            int count = currentorder.Children.Count;
            int found = 0;
            for (int i = 0; i < count; i++)
            {
                CheckBox c = (currentorder.Children[i - found] as CheckBox);
                if ((bool)c.IsChecked)
                {
                    myorder.RemoveAt(i-found);
                    prices.RemoveAt(i - found);
                    currentorder.Children.RemoveAt(i - found);
                    found++;
                }
            }
            totalprice.Text = "€" + getTotalPrice(prices).ToString("N2");
        }
    }
}
