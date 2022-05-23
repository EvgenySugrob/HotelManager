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
using Excel = Microsoft.Office.Interop.Excel;

namespace HotelManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Page
    {
        DateTime nowDateTime = DateTime.Now;
        public MainFrame()
        {
            InitializeComponent();


            var currentRooms = HotelManagerEntities.GetContext().RoomFund;
            AllRoomsText.Text = Convert.ToString(currentRooms.Count());

            var currentReservation = HotelManagerEntities.GetContext().Reservation.
                Where(p => p.ReservationDate >= nowDateTime);
            ReservationRoomsText.Text = Convert.ToString(currentReservation.Count());


            var currentCheckOut = HotelManagerEntities.GetContext().CheckInCheckOut.
                Where(p => p.Actual == 1 && p.CheckInDate <= nowDateTime && p.CheckOutDate >= nowDateTime);
            WaitCheckOutText.Text = Convert.ToString(currentCheckOut.Count());
        }

        private void PaymentBt_Click(object sender, RoutedEventArgs e)
        {
            int idCheck = 0;
            ManagerNavigation.MainFrame.Navigate(new PaymentPage(idCheck));
        }

        private void ReservationBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new ReservationPage());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                var currentReservation = HotelManagerEntities.GetContext().Reservation.
                Where(p => p.ReservationDate >= nowDateTime);
                ReservationRoomsText.Text = Convert.ToString(currentReservation.Count());

                var currentCheckOut = HotelManagerEntities.GetContext().CheckInCheckOut.
                    Where(p => p.CheckInDate <= nowDateTime && nowDateTime < p.CheckOutDate && p.Actual == 1);
                WaitCheckOutText.Text = Convert.ToString(currentCheckOut.Count());
            }
        }

        private void exportExcelClick(object sender, RoutedEventArgs e)
        {
            DialogExportWindow dialogExportWindow = new DialogExportWindow();
            if (dialogExportWindow.ShowDialog() == true)
            {
                
            }

        }
    }
}
