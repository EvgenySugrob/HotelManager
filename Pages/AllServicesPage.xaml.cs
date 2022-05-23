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
    /// Логика взаимодействия для AllServicesPage.xaml
    /// </summary>
    public partial class AllServicesPage : Page
    {
        public AllServicesPage()
        {
            InitializeComponent();
            var currentServices = HotelManagerEntities.GetContext().AdditionalServices.ToList();
            LViewServices.ItemsSource = currentServices;
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.EditServicesPage((sender as Button).DataContext as AdditionalServices));
        }

        private void AddServicesBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.EditServicesPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HotelManagerEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewServices.ItemsSource = HotelManagerEntities.GetContext().AdditionalServices.ToList();
            }
        }
    }
}
