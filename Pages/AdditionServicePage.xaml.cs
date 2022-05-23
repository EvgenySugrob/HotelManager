using System;
using System.Collections.Generic;
using System.Linq;
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

namespace HotelManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdditionServicePage.xaml
    /// </summary>
    public partial class AdditionServicePage : Page
    {
        public AdditionServicePage()
        {
            InitializeComponent();
            ServicesFrame.NavigationService.Navigate(new Pages.AllServicesPage());
        }

        private void AllServicesBt_Click(object sender, RoutedEventArgs e)
        {
            ServicesFrame.NavigationService.Navigate(new Pages.AllServicesPage());
        }

        private void ProvisionServicesBt_Click(object sender, RoutedEventArgs e)
        {
            ServicesFrame.NavigationService.Navigate(new Pages.ProvisionServicesPage());
        }
    }
}
