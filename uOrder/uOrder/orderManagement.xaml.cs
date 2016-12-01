using uOrder.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Split Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234234

namespace uOrder
{
    /// <summary>
    /// A page that displays a group title, a list of items within the group, and details for
    /// the currently selected item.
    /// </summary>
   
    public sealed partial class orderManagement : Page
    {
        public String[] categories = { "Cold Coffees", "Hot Coffees", "Other Beverages", "Food", "Sweets" };
        public String[,] products = { { "Iced Latte", "Frappe" , "Freddo Espresso" ,  "Freddo Cappuccino"  , "Iced Mocca"  },
                                    { "Latte" , "Espresso" , "Cappuccino", "Mocca" ,  "Macchiato" },
                                    {  "Water","Orange Juice","Coca Cola","Fanta","Iced Tea" },
                                    { "Cheese Pie","Tuna Sandwich" ,"Croissant","Ceasar Salad","Club Sandwich" },
                                    { "Chocolate Cake","Apple Tart","Chessecake","Carrot Cake","Muffin" }};
        public double[,] prices = { { 3,3,3.2,2.8, 3.5 },
                                    { 3,1.5,3.5,4, 3.2},
                                    { .5,2.5,1,1, 1.5 },
                                    { 2,4,1.5,4,4.3 },
                                    { 2,2.5,3,2.2,2 }};
        public int orderNo = 0;
        public Order currentOrder;
        public List<Product> menuProducts;
        public List<Category> menuCategories;
        public static List<Order> allOrders;

        public void initializeLists()
        {
            currentOrder = new Order();
            menuCategories = new List<Category>();
            menuProducts = new List<Product>();
            allOrders = new List<Order>();
            for (int i = 0; i < categories.Length; i++)
            {
                menuCategories.Add(new Category(categories[i]));
                for (int j = 0; j < 5; j++)
                {
                    menuProducts.Add(new Product(products[i, j], prices[i, j], menuCategories[i]));
                }
            }
        }
        public orderManagement()
        {
            this.InitializeComponent();

            initializeLists();
        }

        private void back_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));

        }

        /// <summary>
        /// On product click add the product on the current order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_click(object sender, RoutedEventArgs e)
        {
            
            CheckBox c = new CheckBox();
            if (currOrderStack.Children.Count == 0)
            {
                currOrder.Visibility = Visibility.Visible;
                currentOrder = new Order();
            }
            int t = Convert.ToInt16((sender as Button).Tag);
            c.Content = menuProducts[t].prodName + " (" + menuProducts[t].prodPrice.ToString("C") + ")";
            currentOrder.addProduct(menuProducts[t]);
            price.Text = currentOrder.price.ToString("C"); // currency
            c.Visibility = Visibility.Visible;

            currOrderStack.Children.Add(c);
            
            
        }
        private void backToMenu_click(object sender, RoutedEventArgs e)
        {
            categoryGrid.Visibility = Visibility.Collapsed;
            showCategories();
        }
        /// <summary>
        /// On Category click show all products of the category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_click(object sender, RoutedEventArgs e)
        {
            var tag = (sender as Button).Tag;
            int t = Convert.ToInt16(tag);
            Button[] b = new Button[products.GetLength(1)+1];
            
            categoryGrid.Children.Clear();
            menuGrid.Visibility = Visibility.Collapsed;
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = new Button();
                b[i].Visibility = Visibility.Visible;
                
                b[i].Width = 250;
                b[i].Height = 75;
                b[i].Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10);
                b[i].HorizontalAlignment = HorizontalAlignment.Center;
                b[i].Tag = i + t*categories.Length;
                if (i < b.Length - 1)
                {
                    b[i].Content = menuProducts[t * categories.Length + i].prodName;
                    //b[i].Content = products[t, i];
                    b[i].Click += new RoutedEventHandler(p_click);
                }
                else
                {
                    b[i].Content = "BACK";
                    b[i].Click += new RoutedEventHandler(backToMenu_click);
                }
                
                categoryGrid.Children.Add(b[i]);
            }
            
            categoryGrid.Visibility = Visibility.Visible;
        }
        
        private void showCategories()
        {
            menuGrid.Visibility = Visibility.Visible;
        }
        private void onLoad(object sender, RoutedEventArgs e)
        {
            Button[] b = new Button[categories.Length];
            for (int i = 0; i < categories.Length; i++)
            {
                b[i] = new Button();
                b[i].Visibility = Visibility.Visible;
                b[i].Content = menuCategories[i].catName;
                b[i].Width = 250;
                b[i].Height = 75;
                b[i].Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10);
                b[i].HorizontalAlignment = HorizontalAlignment.Center;
                b[i].Tag = i;
                b[i].Click += new RoutedEventHandler(b_click);
                menuGrid.Children.Add(b[i]);
            }
            
        }

        private void removeProduct_click(object sender, RoutedEventArgs e)
        {
            int count = currOrderStack.Children.Count;
            int found = 0;
            for (int i = 0; i < count; i++) { 
                CheckBox c = (currOrderStack.Children[i-found] as CheckBox);
                if ((bool)c.IsChecked)
                {
                    currOrderStack.Children.RemoveAt(i - found);
                    currentOrder.removeProduct(i - found);
                    found++;
                }
            }
            price.Text = currentOrder.price.ToString("C"); // currency

        }

        private void placeOrder_Click(object sender, RoutedEventArgs e)
        {
            Border bor = new Border();
            StackPanel sp = new StackPanel();
            StackPanel buttonSP = new StackPanel();
            buttonSP.Orientation = Orientation.Horizontal;
            TextBlock tb = new TextBlock();
            TextBlock[] products = new TextBlock[currOrderStack.Children.Count];
            Button readyButton = new Button();
            Button cancelButton = new Button();
            Button doneButton = new Button();
            Button editButton = new Button();
            Windows.UI.Xaml.Documents.Run r = new Windows.UI.Xaml.Documents.Run();
            Windows.UI.Xaml.Documents.Underline ul = new Windows.UI.Xaml.Documents.Underline();
            r.Text = "Order #" + ++orderNo + ": " + currentOrder.price.ToString("C");
            ul.Inlines.Add(r);
            tb.Inlines.Add(ul);
            tb.FontSize += 10;
            sp.Children.Add(tb);
            bor.Width = 500;
            bor.Child = sp;
            Windows.UI.Color c = new Windows.UI.Color();
            c.R = 8;
            c.G = 37;
            c.B = 103;
            c.A = 255;
            sp.Background = new SolidColorBrush(Windows.UI.Colors.Goldenrod );
            for (int i = 0; i < currOrderStack.Children.Count; i++)
            {
                products[i] = new TextBlock();
                products[i].Text = (currOrderStack.Children[i] as CheckBox).Content.ToString();
                products[i].FontSize += 8;
                sp.Children.Add(products[i]);
            }

            readyButton.Content = "Ready";
            readyButton.Click += ReadyButton_Click;
            cancelButton.Content = "Cancel";
            cancelButton.Click += CancelButton_Click;
            editButton.Content = "Edit";
            doneButton.Content = "Done";
            doneButton.IsEnabled = false;
            doneButton.Click += doneButton_click;
            buttonSP.Children.Add(readyButton);
            buttonSP.Children.Add(editButton);
            buttonSP.Children.Add(doneButton);
            buttonSP.Children.Add(cancelButton);
            sp.Children.Add(buttonSP);

            
            allOrdersStack.Children.Add(bor);
            allOrdersStack.Children.Add(new TextBlock());
            currOrderStack.Children.Clear();
            allOrders.Add(currentOrder);
            currOrder.Visibility = Visibility.Collapsed;
        }

        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            (((sender as Button).Parent as StackPanel).Children[1] as Button).IsEnabled = false;
            (((sender as Button).Parent as StackPanel).Children[3] as Button).IsEnabled = false;
            (((sender as Button).Parent as StackPanel).Children[2] as Button).IsEnabled = true;
            allOrders[((sender as Button).Parent as StackPanel).Children.IndexOf(sender as Button)].isReady = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            int pos;
            Border b = ((((sender as Button).Parent as StackPanel).Parent as StackPanel).Parent as Border);
            pos = allOrdersStack.Children.IndexOf(b);
            allOrdersStack.Children.RemoveAt(pos);
            allOrdersStack.Children.RemoveAt(pos);
        }

        private void doneButton_click(object sender, RoutedEventArgs e)
        {
            int pos;
            Border b = ((((sender as Button).Parent as StackPanel).Parent as StackPanel).Parent as Border);
            pos = allOrdersStack.Children.IndexOf(b);
            allOrdersStack.Children.RemoveAt(pos);
            allOrdersStack.Children.RemoveAt(pos);
        }

        private void end_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(dayStatistics));
        }
    }
}
