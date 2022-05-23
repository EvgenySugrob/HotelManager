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
    /// Логика взаимодействия для ProvisionServicesPage.xaml
    /// </summary>
    public partial class ProvisionServicesPage : Page
    {
        
        public ProvisionServicesPage()
        {
            InitializeComponent();
            var currentPrServices = HotelManagerEntities.GetContext().ProvisionOfServices.ToList();
            LViewPrServices.ItemsSource = currentPrServices;
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.EditProvisionServicesPage((sender as Button).DataContext as ProvisionOfServices));
        }

        private void AddProvisionServicesBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.EditProvisionServicesPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HotelManagerEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewPrServices.ItemsSource = HotelManagerEntities.GetContext().ProvisionOfServices.ToList();
            }
        }
    }
}
