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
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        DateTime nowDateTime = DateTime.Now;
        int checkId;
        public PaymentPage(int idCheck)
        {
            InitializeComponent();

            

            checkId = idCheck;
            
            if (idCheck == 0)
            {
                LViewPaymentClose.ItemsSource = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.Actual == 0).ToList();
                var currentCheckOut = HotelManagerEntities.GetContext().CheckInCheckOut.
                Where(p => p.CheckInDate <= nowDateTime && nowDateTime < p.CheckOutDate && p.Actual == 1).ToList();
                LViewPayment.ItemsSource = currentCheckOut;
                UpdateRooms();
            }
            else if(idCheck !=0)
            {
                var checkGuest = HotelManagerEntities.GetContext().CheckInCheckOut.
                Where(p => p.CheckInDate <= nowDateTime && nowDateTime < p.CheckOutDate && p.Actual == 1).
                Where(p => p.ID == idCheck).ToList();
                LViewPayment.ItemsSource = checkGuest;
                UpdateRooms();
            }
            UpdateRoomsClose();
        }
        private void UpdateRooms()
        {
            var currentRooms = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.CheckInDate <= nowDateTime && nowDateTime <= p.CheckOutDate && p.Actual == 1).ToList();
            
            //Сортировка
            int sortIndex = Convert.ToInt32(ComboSort.SelectedIndex);
            switch (sortIndex)
            {
                case 1:
                    currentRooms = currentRooms.OrderBy(p => p.RoomID).ToList();
                    break;
                case 2:
                    currentRooms = currentRooms.OrderByDescending(p => p.RoomID).ToList();
                    break;
                case 3:
                    currentRooms = currentRooms.OrderBy(p => p.CheckOutDate).ToList();
                    break;
                case 4:
                    currentRooms = currentRooms.OrderByDescending(p => p.CheckOutDate).ToList();
                    break;
            }
            LViewPayment.ItemsSource = currentRooms;
        }
        private void UpdateRoomsClose()
        {
            var currentRoomsClose = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.Actual == 0).ToList();
            int sortIndexClose = Convert.ToInt32(ComboSortClose.SelectedIndex);
            switch (sortIndexClose)
            {
                case 1:
                    currentRoomsClose = currentRoomsClose.OrderBy(p => p.RoomID).ToList();
                    break;
                case 2:
                    currentRoomsClose = currentRoomsClose.OrderByDescending(p => p.RoomID).ToList();
                    break;
                case 3:
                    currentRoomsClose = currentRoomsClose.OrderBy(p => p.CheckOutDate).ToList();
                    break;
                case 4:
                    currentRoomsClose = currentRoomsClose.OrderByDescending(p => p.CheckOutDate).ToList();
                    break;
            }
            LViewPaymentClose.ItemsSource = currentRoomsClose;
        }

        private void PaymentBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.PaymentGuestPage((sender as Button).DataContext as CheckInCheckOut));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                if (checkId <= 0)
                {
                    var currentCheckOut = HotelManagerEntities.GetContext().CheckInCheckOut.
                    Where(p => p.CheckInDate <= nowDateTime && nowDateTime <= p.CheckOutDate && p.Actual == 1).ToList();
                    LViewPayment.ItemsSource = currentCheckOut;
                    UpdateRooms();
                }
                else
                {
                    var checkGuest = HotelManagerEntities.GetContext().CheckInCheckOut.
                    Where(p => p.CheckInDate <= nowDateTime && nowDateTime <= p.CheckOutDate && p.Actual == 1).
                    Where(p => p.ID == checkId).ToList();
                    LViewPayment.ItemsSource = checkGuest;
                    UpdateRooms();
                }
            }
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRooms();
        }

        private void ComboSortClose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRoomsClose();
        }
    }
}
