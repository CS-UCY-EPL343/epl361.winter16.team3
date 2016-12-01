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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace uOrder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class modifyMenu : Page
    {
        public modifyMenu()
        {
            this.InitializeComponent();
        }

        private void Add_Product_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Product_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Category_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = new ComboBoxItem();
            item.Content = ProductName_Copy.Text;
            CategoryBox.Items.Add(item);
            ProductName_Copy.Text = "";
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Remove_Category_Click(object sender, RoutedEventArgs e)
        {
            CategoryBox.Items.Remove(CategoryBox.SelectedItem);
        }

        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(managementPage));
        }
    }
}