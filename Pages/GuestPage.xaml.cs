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
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        public GuestPage()
        {
            InitializeComponent();
            var currentGuests = HotelManagerEntities.GetContext().Client.ToList();
            LViewGuests.ItemsSource = currentGuests;
            UpdateGuest();
        }
        private void UpdateGuest()
        {
            var currentGuests = HotelManagerEntities.GetContext().Client.ToList();
            currentGuests = currentGuests.Where(p => p.Surname.ToLower().Contains(TBoxSearch.Text.ToLower())
            ||p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())
            ||p.Patronymic.ToLower().Contains(TBoxSearch.Text.ToLower())
            ||p.PassportDate.ToLower().Contains(TBoxSearch.Text.ToLower())
            ||p.Telephone.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            int sortIndex = Convert.ToInt32(ComboSort.SelectedIndex);
            switch (sortIndex)
            {
                case 1:
                    currentGuests = currentGuests.OrderBy(p=>p.Surname).ToList();
                    break;
                case 2:
                    currentGuests = currentGuests.OrderByDescending(p => p.Surname).ToList();
                    break;
                case 3:
                    currentGuests = currentGuests.OrderBy(p => p.Nationality).ToList();
                    break;
            }
            LViewGuests.ItemsSource = currentGuests;

        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateGuest();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGuest();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.EditGuestPage((sender as Button).DataContext as Client));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HotelManagerEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewGuests.ItemsSource = HotelManagerEntities.GetContext().Client.ToList();
            }
        }
    }
}
