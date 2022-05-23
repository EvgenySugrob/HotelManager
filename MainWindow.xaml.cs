using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Linq;

namespace HotelManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationFrame.Navigate(new Pages.MainFrame());
            ManagerNavigation.MainFrame = NavigationFrame;
        }

        private void MainBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.MainFrame());
        }

        private void RegistrationBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.RegistrationFrame());
        }

        private void RoomsBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.RoomsPage());
        }

        private void GuestBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.GuestPage());
        }

        private void AdditionServiceBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.AdditionServicePage());
        }

        private void BackBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.GoBack();
        }
        private void NavigationFrame_ContentRendered(object sender, EventArgs e)
        {
            //if (NavigationFrame.CanGoBack)
            //{
            //    BackBt.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    BackBt.Visibility = Visibility.Hidden;
            //}
        }
    }
}
