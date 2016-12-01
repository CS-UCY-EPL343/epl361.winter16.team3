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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class hotCoffees : Page
    {
        public hotCoffees()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(viewOrder));
        }
        
        private void add1_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Add(product1.Text + "\t\t\t" + price1.Text);
            viewOrder.prices.Add(1.5);
            add1.Content = "ADDED";
            add1.IsEnabled = false;
            wait(add1);
        }

        private void add2_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Add(product2.Text + "\t\t\t" + price2.Text);
            viewOrder.prices.Add(3);
            add2.Content = "ADDED";
            add2.IsEnabled = false;
            wait(add2);
        }

        private void add3_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Add(product3.Text + "\t\t" + price3.Text);
            viewOrder.prices.Add(3.5);
            add3.Content = "ADDED";
            add3.IsEnabled = false;
            wait(add3);
        }

        private void add4_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Add(product4.Text + "\t\t\t" + price4.Text);
            viewOrder.prices.Add(4);
            add4.Content = "ADDED";
            add4.IsEnabled = false;
            wait(add4);
        }

        private void add5_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Add(product5.Text + "\t\t" + price5.Text);
            viewOrder.prices.Add(3.2);
            add5.Content = "ADDED";
            add5.IsEnabled = false;
            wait(add5);
        }

        private async void wait(Button b)
        {
            await System.Threading.Tasks.Task.Delay(500);
            b.Content = "ADD";
            b.IsEnabled = true;
        }

        private void like1_Click(object sender, RoutedEventArgs e)
        {
            rating1.Text = like(rating1.Text, like1);
        }
        private void like2_Click(object sender, RoutedEventArgs e)
        {
            rating2.Text = like(rating2.Text, like2);
        }
        private void like3_Click(object sender, RoutedEventArgs e)
        {
            rating3.Text = like(rating3.Text, like3);
        }
        private void like4_Click(object sender, RoutedEventArgs e)
        {
            rating4.Text = like(rating4.Text, like4);
        }
        private void like5_Click(object sender, RoutedEventArgs e)
        {
            rating5.Text = like(rating5.Text, like5);
        }

        private String like(String rating, Button b)
        {
            int status, likes;
            if (b.Content.Equals("LIKE"))
            {
                status = 1;
                b.Content = "LIKED";
            }
            else {
                status = 2;
                b.Content = "LIKE";
            }

            if (status == 1)
            {
                String[] str = rating.Split(' ');
                likes = Int32.Parse(str[0]);
                likes++;
            }
            else
            {
                String[] str = rating.Split(' ');
                likes = Int32.Parse(str[0]);
                likes--;
            }
            rating = likes + " likes";
            return rating;
        }

      
    }
}
