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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
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
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void hot_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(hotCoffees));
        }

        private void cold_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(coldCoffees));
        }

        private void sweets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(hotDrinks));
        }

        private void other_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(coldDrinks));
        }

        private void food_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(food));
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(sendFeedback));
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(viewOrder));
        }
    }
}
