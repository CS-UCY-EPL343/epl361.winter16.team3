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
    public sealed partial class coldDrinks : Page
    {
        public coldDrinks()
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
            viewOrder.total = viewOrder.total + 0.5;
            add1.Content = "ADDED";
            add1.IsEnabled = false;
            wait(add1);
        }

        private void add2_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Add(product2.Text + "\t\t" + price2.Text);
            viewOrder.total = viewOrder.total + 2.5;
            add2.Content = "ADDED";
            add2.IsEnabled = false;
            wait(add2);
        }

        private void add3_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Add(product3.Text + "\t\t" + price3.Text);
            viewOrder.total = viewOrder.total + 1;
            add3.Content = "ADDED";
            add3.IsEnabled = false;
            wait(add3);
        }

        private void add4_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Add(product4.Text + "\t\t\t" + price4.Text);
            viewOrder.total = viewOrder.total + 1;
            add4.Content = "ADDED";
            add4.IsEnabled = false;
            wait(add4);
        }

        private void add5_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Add(product5.Text + "\t\t\t" + price5.Text);
            viewOrder.total = viewOrder.total + 1.5;
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
    }
}
