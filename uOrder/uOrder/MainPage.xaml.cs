using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace uOrder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        public static string username = "test";
        public static string password = "test";
        public MainPage()
        {
            this.InitializeComponent();
        }     

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (userBox.Text.CompareTo(username)==0  && passwordBox.Password.CompareTo(password)==0)
                Frame.Navigate(typeof(managementPage));
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(orderManagement));
        }
    }
}
