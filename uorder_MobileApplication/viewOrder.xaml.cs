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
        public static List<String> myorder = new List<String>();
        public static double total = 0;

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

        private void order_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i=0; i<myorder.Count; i++)
            {
                if (i == 0) order.Text = "";
                order.Text = order.Text + myorder[i] + "\n";
            }
        }

        private void removeall_Click(object sender, RoutedEventArgs e)
        {
            order.Text = "No products added yet.";
            viewOrder.myorder.Clear();
            totalprice.Text = "€0.00";
            viewOrder.total = 0;
        }

        private void totalprice_Loaded(object sender, RoutedEventArgs e)
        {
            totalprice.Text = "€" + total.ToString("N2");
        }
    }
}
