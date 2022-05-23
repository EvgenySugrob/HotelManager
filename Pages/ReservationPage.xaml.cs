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
    /// Логика взаимодействия для ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : Page
    {
        public ReservationPage()
        {
            InitializeComponent();
            var currentReservation = HotelManagerEntities.GetContext().Reservation.ToList();
            LViewReservation.ItemsSource = currentReservation;
        }

        private void RegistrBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new EditReservationInRegistration((sender as Button).DataContext as Reservation));
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var reservationForRemoving = LViewReservation.SelectedItems.Cast<Reservation>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {reservationForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    HotelManagerEntities.GetContext().Reservation.RemoveRange(reservationForRemoving);
                    HotelManagerEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены","Сообщение",MessageBoxButton.OK,MessageBoxImage.Information);

                    LViewReservation.ItemsSource = HotelManagerEntities.GetContext().Reservation.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HotelManagerEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewReservation.ItemsSource = HotelManagerEntities.GetContext().Reservation.ToList();
            }
        }
    }
}
