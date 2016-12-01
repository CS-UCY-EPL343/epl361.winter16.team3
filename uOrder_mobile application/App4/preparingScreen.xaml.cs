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

    public sealed partial class preparingScreen : Page
    {
        public preparingScreen()
        {
            this.InitializeComponent();
        }

        private void ready_Click(object sender, RoutedEventArgs e)
        {
            status.Text = "READY!";
            status.FontSize = 35;
        }

        private void total_Loaded(object sender, RoutedEventArgs e)
        {
            total.Text = "€" + viewOrder.getTotalPrice(viewOrder.prices).ToString("N2");
        }

        private void neworder_Click(object sender, RoutedEventArgs e)
        {
            viewOrder.myorder.Clear();
            viewOrder.prices.Clear();
            Frame.Navigate(typeof(MainPage));
        }
    }
}
