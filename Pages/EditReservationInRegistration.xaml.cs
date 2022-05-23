using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditReservationInRegistration.xaml
    /// </summary>
    public partial class EditReservationInRegistration : Page
    {
        DateTime? dateIn, dateOut;
        private CheckInCheckOut _checkInCheckOut = new CheckInCheckOut();
        private Reservation _reservation = new Reservation();
        public EditReservationInRegistration(Reservation selectedReserv)
        {
            InitializeComponent();
            if (selectedReserv != null)
                _reservation = selectedReserv;
            DataContext = _reservation;
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            var numbers = new Regex(@"[0-9]");
            var upperCharRu = new Regex(@"[А-Я]");
            var lowCharRu = new Regex(@"[а-я]");
            var upperChar = new Regex(@"[A-Z]");
            var lowerChar = new Regex(@"[a-z]");
            var symbols = new Regex(@"[!@#$%^&*()_+=\[{\]};~:<>\-]");

            if (upperCharRu.IsMatch(RoomIdText.Text)
                || lowCharRu.IsMatch(RoomIdText.Text)
                || upperChar.IsMatch(RoomIdText.Text)
                || lowerChar.IsMatch(RoomIdText.Text)
                || symbols.IsMatch(RoomIdText.Text)
                || upperCharRu.IsMatch(CountPeopleText.Text)
                || lowCharRu.IsMatch(CountPeopleText.Text)
                || upperChar.IsMatch(CountPeopleText.Text)
                || lowerChar.IsMatch(CountPeopleText.Text)
                || symbols.IsMatch(CountPeopleText.Text))
                errors.AppendLine("В строке Номер не должно быть букв и спец.символов");


            try
            {
                int countDay = Convert.ToInt32(dateOut.Value
                   .Subtract(dateIn.Value).TotalDays);

                _checkInCheckOut.ClientID = _reservation.ClientID;
                _checkInCheckOut.RoomID = _reservation.RoomID;
                int roomID = Convert.ToInt32(RoomIdText.Text);
                var currentRoomId = HotelManagerEntities.GetContext().RoomFund.First(p => p.ID == roomID);
                if (currentRoomId != null)
                {
                    currentRoomId.Status = false;
                    
                }
                _checkInCheckOut.CountOfPeopl = Convert.ToInt32(CountPeopleText.Text);
                _checkInCheckOut.CheckInDate = (DateTime)dateIn;
                _checkInCheckOut.CheckOutDate = (DateTime)dateOut;
                _checkInCheckOut.CountDay = countDay;
                if (_checkInCheckOut.ID == 0)
                    HotelManagerEntities.GetContext().CheckInCheckOut.Add(_checkInCheckOut);

                try
                {
                    HotelManagerEntities.GetContext().Reservation.Remove(_reservation);
                    HotelManagerEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int idCheck = _checkInCheckOut.ID;
                ManagerNavigation.MainFrame.Navigate(new Pages.PaymentPage(idCheck));
                
            }
            catch 
            {
                MessageBox.Show("Проверьте правильность заполенния данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.GoBack();
        }

        private void CheckOutDatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateOut = CheckOutDatePick.SelectedDate;
        }

        private void CheckInDatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateIn = CheckInDatePick.SelectedDate;
        }
    }
}
