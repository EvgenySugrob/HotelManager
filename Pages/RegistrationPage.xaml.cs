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
    /// Логика взаимодействия для RegistrationFrame.xaml
    /// </summary>
    public partial class RegistrationFrame : Page
    {
       public string selectedRoom, selectedRoomReserv;
       public DateTime? dateBith, dateCheckIn, dateCheckOut, dateReserv;

        public RegistrationFrame()
        {
            InitializeComponent();
            RoomIdCombo.ItemsSource = HotelManagerEntities.GetContext().RoomFund.Where(p=>p.Status == true).ToList();
            ReservRoomIdCombo.ItemsSource = HotelManagerEntities.GetContext().RoomFund.Where(p => p.Status == true).ToList();

        }
        private void SaveDataRegistration()
        {
            StringBuilder errors = new StringBuilder();
            var numbers = new Regex(@"[0-9]");
            var upperCharRu = new Regex(@"[А-Я]");
            var lowCharRu = new Regex(@"[а-я]");
            var upperChar = new Regex(@"[A-Z]");
            var lowerChar = new Regex(@"[a-z]");
            var symbols = new Regex(@"[!@#$%^&*()_+=\[{\]};~:<>\-]");

            if (numbers.IsMatch(SurnameText.Text)
                || numbers.IsMatch(NameText.Text)
                || numbers.IsMatch(PatronymicText.Text))
                errors.AppendLine("В строке Фамилии/Имени/Отчества не должно быть цифр");
            if (symbols.IsMatch(SurnameText.Text)
                || symbols.IsMatch(NameText.Text)
                || symbols.IsMatch(PatronymicText.Text))
                errors.AppendLine("В строке Фамилии/Имени/Отчества не должно быть спец.символов");
            if (upperCharRu.IsMatch(DateBithText.Text)
                || lowCharRu.IsMatch(DateBithText.Text)
                || upperChar.IsMatch(DateBithText.Text)
                || lowerChar.IsMatch(DateBithText.Text)
                || upperChar.IsMatch(CheckInDateText.Text)
                || upperCharRu.IsMatch(CheckInDateText.Text)
                || lowerChar.IsMatch(CheckInDateText.Text)
                || lowCharRu.IsMatch(CheckInDateText.Text)
                || upperChar.IsMatch(CheckOutDateText.Text)
                || upperCharRu.IsMatch(CheckOutDateText.Text)
                || lowerChar.IsMatch(CheckOutDateText.Text)
                || lowCharRu.IsMatch(CheckOutDateText.Text))
                errors.AppendLine("В строке даты должны быть цифры и спец.симфолы");
            if (upperCharRu.IsMatch(PassportDataText.Text)
                || lowCharRu.IsMatch(PassportDataText.Text)
                || upperChar.IsMatch(PassportDataText.Text)
                || lowerChar.IsMatch(PassportDataText.Text))
                errors.AppendLine("В строке паспортных данных необходимо указать серию и номер паспорта");
            if (numbers.IsMatch(NationalityText.Text)
                || symbols.IsMatch(NationalityText.Text))
                errors.AppendLine("В строке Национальность не должно быть цифр и спец.символов");
            if (upperCharRu.IsMatch(TelephoneText.Text)
                || lowCharRu.IsMatch(TelephoneText.Text)
                || upperChar.IsMatch(TelephoneText.Text)
                || lowerChar.IsMatch(TelephoneText.Text))
                errors.AppendLine("В строке Телефон должны быть цифры и спец символы");
            if (upperCharRu.IsMatch(RoomIdCombo.Text)
                || lowCharRu.IsMatch(RoomIdCombo.Text)
                || upperChar.IsMatch(RoomIdCombo.Text)
                || lowerChar.IsMatch(RoomIdCombo.Text)
                || symbols.IsMatch(RoomIdCombo.Text))
                errors.AppendLine("В строке Номер комнаты должны быть только цифры");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(),"Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            var userContex = HotelManagerEntities.GetContext();
            try
            {
                int countDay = Convert.ToInt32(dateCheckOut.Value
                    .Subtract(dateCheckIn.Value).TotalDays);
                //var roomID = HotelManagerEntities.GetContext().RoomFund.First(p => p.ID == _check.RoomID);
                //var priceRoom = HotelManagerEntities.GetContext().TypeNumber.First(p => p.ID == roomID.TypeID);
                //AmountDaysText.Text = Convert.ToString(countDay * priceRoom.Price);

                Client client = new Client
                {
                    Surname = SurnameText.Text.ToString(),
                    Name = NameText.Text.ToString(),
                    Patronymic = PatronymicText.Text.ToString(),
                    DateOfBirth = (DateTime)dateBith,
                    PassportDate = PassportDataText.Text.ToString(),
                    Address = AddresText.Text.ToString(),
                    Nationality = NationalityText.Text.ToString(),
                    Telephone = TelephoneText.Text.ToString()
                };
                CheckInCheckOut checkInCheckOut = new CheckInCheckOut
                {
                    ClientID = client.ID,
                    RoomID = Int32.Parse(selectedRoom),
                    CountOfPeopl = Int32.Parse(CountPeopleText.Text),
                    CheckInDate = (DateTime)dateCheckIn,
                    CheckOutDate = (DateTime)dateCheckOut,
                    CountDay = countDay,
                    Actual = 1
                };

                int roomID = Convert.ToInt32(selectedRoom);
                var currentRoomId = userContex.RoomFund.First(p => p.ID == roomID);
                if (currentRoomId != null)
                {
                    currentRoomId.Status = false;
                    userContex.SaveChanges();
                }
                var roomIdType = HotelManagerEntities.GetContext().RoomFund.First(p => p.ID == checkInCheckOut.RoomID);
                var priceRoom = HotelManagerEntities.GetContext().TypeNumber.First(p => p.ID == roomIdType.TypeID);
                checkInCheckOut.PriceAllDay = Convert.ToInt32(countDay * priceRoom.Price);

                userContex.Client.Add(client);
                userContex.CheckInCheckOut.Add(checkInCheckOut);
                userContex.SaveChanges();
                CancelCompletPanel.Visibility = Visibility.Hidden;
                DataFillPanel.Visibility = Visibility.Hidden;
                ConfirmPanel.Visibility = Visibility;

                

                SurnameText.Clear();
                NameText.Clear();
                PatronymicText.Clear();
                dateBith = DateTime.Now;
                PassportDataText.Clear();
                AddresText.Clear();
                NationalityText.Clear();
                TelephoneText.Clear();
                RoomIdCombo.SelectedIndex = 0;
                dateCheckIn = DateTime.Now;
                dateCheckOut = DateTime.Now;

                int idCheck = checkInCheckOut.ID;
                ManagerNavigation.MainFrame.Navigate(new Pages.PaymentPage(idCheck));
                MessageBox.Show("Регистрация успешна!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    ("Проверьте правильность заполнения данных" + ex.ToString(),
                     "Ошибка",
                     MessageBoxButton.OK,
                     MessageBoxImage.Warning);
            }
        }

        private void SaveDataReservation()
        {
            StringBuilder errors = new StringBuilder();
            var numbers = new Regex(@"[0-9]");
            var upperCharRu = new Regex(@"[А-Я]");
            var lowCharRu = new Regex(@"[а-я]");
            var upperChar = new Regex(@"[A-Z]");
            var lowerChar = new Regex(@"[a-z]");
            var symbols = new Regex(@"[!@#$%^&*()_+=\[{\]};~:<>\-]");

            if (numbers.IsMatch(SurnameText.Text)
                || numbers.IsMatch(NameText.Text)
                || numbers.IsMatch(PatronymicText.Text))
                errors.AppendLine("В строке Фамилии/Имени/Отчества не должно быть цифр");
            if (symbols.IsMatch(SurnameText.Text)
                || symbols.IsMatch(NameText.Text)
                || symbols.IsMatch(PatronymicText.Text))
                errors.AppendLine("В строке Фамилии/Имени/Отчества не должно быть спец.символов");
            if (upperCharRu.IsMatch(DateBithText.Text)
                || lowCharRu.IsMatch(DateBithText.Text)
                || upperChar.IsMatch(DateBithText.Text)
                || lowerChar.IsMatch(DateBithText.Text)
                || upperChar.IsMatch(ReservDateText.Text)
                || upperCharRu.IsMatch(ReservDateText.Text)
                || lowerChar.IsMatch(ReservDateText.Text)
                || lowCharRu.IsMatch(ReservDateText.Text))
                errors.AppendLine("В строке даты должны быть цифры и спец.симфолы");
            if (upperCharRu.IsMatch(PassportDataText.Text)
                || lowCharRu.IsMatch(PassportDataText.Text)
                || upperChar.IsMatch(PassportDataText.Text)
                || lowerChar.IsMatch(PassportDataText.Text))
                errors.AppendLine("В строке паспортных данных необходимо указать серию и номер паспорта");
            if (numbers.IsMatch(NationalityText.Text)
                || symbols.IsMatch(NationalityText.Text))
                errors.AppendLine("В строке Национальность не должно быть цифр и спец.символов");
            if (upperCharRu.IsMatch(TelephoneText.Text)
                || lowCharRu.IsMatch(TelephoneText.Text)
                || upperChar.IsMatch(TelephoneText.Text)
                || lowerChar.IsMatch(TelephoneText.Text))
                errors.AppendLine("В строке Телефон должны быть цифры и спец символы");
            if (upperCharRu.IsMatch(ReservRoomIdCombo.Text)
                || lowCharRu.IsMatch(ReservRoomIdCombo.Text)
                || upperChar.IsMatch(ReservRoomIdCombo.Text)
                || lowerChar.IsMatch(ReservRoomIdCombo.Text)
                || symbols.IsMatch(ReservDateText.Text))
                errors.AppendLine("В строке Номер комнаты должны быть только цифры");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var userContex = HotelManagerEntities.GetContext();
            try
            {
                //сохранение данных при регистрации
                Client client = new Client
                {
                    Surname = SurnameText.Text.ToString(),
                    Name = NameText.Text.ToString(),
                    Patronymic = PatronymicText.Text.ToString(),
                    DateOfBirth = (DateTime)dateBith,
                    PassportDate = PassportDataText.Text.ToString(),
                    Address = AddresText.Text.ToString(),
                    Nationality = NationalityText.Text.ToString(),
                    Telephone = TelephoneText.Text.ToString()
                };
                Reservation reservation = new Reservation
                {
                    ClientID = client.ID,
                    RoomID = Int32.Parse(selectedRoomReserv),
                    ReservationDate = (DateTime)dateReserv
                };
                
                int roomID = Convert.ToInt32(selectedRoomReserv);
                var currentRoomId = userContex.RoomFund.First(p => p.ID == roomID);
                if (currentRoomId != null)
                {
                    currentRoomId.Status = false;
                    userContex.SaveChanges();
                }

                userContex.Client.Add(client);
                userContex.Reservation.Add(reservation);
                userContex.SaveChanges();
                CancelCompletPanel.Visibility = Visibility.Hidden;
                DataFillPanel.Visibility = Visibility.Hidden;
                ConfirmPanel.Visibility = Visibility;

                //Отчистка полей при успешном сохранении
                SurnameText.Clear();
                NameText.Clear();
                PatronymicText.Clear();
                dateBith = DateTime.Now;
                PassportDataText.Clear();
                AddresText.Clear();
                NationalityText.Clear();
                TelephoneText.Clear();
                ReservRoomIdCombo.SelectedIndex = 0;
                dateReserv = DateTime.Now;
            }
            catch
            {
                MessageBox.Show
                    ("Проверьте правильность заполнения данных",
                     "Ошибка",
                     MessageBoxButton.OK,
                     MessageBoxImage.Warning);
            }
        }
        private void ConfirmRegistrationBt_Click(object sender, RoutedEventArgs e)
        {
            ConfirmPanel.Visibility = Visibility.Hidden;
            DataFillPanel.Visibility = Visibility.Visible;
            CheckInDataFill.Visibility = Visibility.Visible;
            CancelCompletPanel.Visibility = Visibility.Visible;
        }

        private void ConfirmReservationBt_Click(object sender, RoutedEventArgs e)
        {
            ConfirmPanel.Visibility = Visibility.Hidden;
            DataFillPanel.Visibility = Visibility.Visible;
            ReservationDataFill.Visibility = Visibility.Visible;
            CompleteReservPanel.Visibility = Visibility.Visible;
        }

        private void CompleteBt_Click(object sender, RoutedEventArgs e)
        {
            SaveDataRegistration();
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            CancelCompletPanel.Visibility = Visibility.Hidden;
            CheckInDataFill.Visibility = Visibility.Hidden;
            DataFillPanel.Visibility = Visibility.Hidden;
            ConfirmPanel.Visibility = Visibility.Visible;
            SurnameText.Clear();
            NameText.Clear();
            PatronymicText.Clear();
            dateBith = DateTime.Now;
            PassportDataText.Clear();
            AddresText.Clear();
            NationalityText.Clear();
            TelephoneText.Clear();
            RoomIdCombo.SelectedIndex = 0;
            dateCheckIn = DateTime.Now;
            dateCheckOut = DateTime.Now;
        }

        private void CancelReservBt_Click(object sender, RoutedEventArgs e)
        {
            CompleteReservPanel.Visibility = Visibility.Hidden;
            DataFillPanel.Visibility = Visibility.Hidden;
            ReservationDataFill.Visibility = Visibility.Hidden;
            ConfirmPanel.Visibility = Visibility.Visible;
            SurnameText.Clear();
            NameText.Clear();
            PatronymicText.Clear();
            dateBith = DateTime.Now;
            PassportDataText.Clear();
            AddresText.Clear();
            NationalityText.Clear();
            TelephoneText.Clear();
            ReservRoomIdCombo.SelectedIndex = 0;
            dateReserv = DateTime.Now;
        }

        private void CompleteReservBt_Click(object sender, RoutedEventArgs e)
        {
            SaveDataReservation();
        }

        private void ReservDateChange(object sender, SelectionChangedEventArgs e)
        {
            dateReserv = ReservDateText.SelectedDate;
        }

        private void RoomIdText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoomIdCombo.SelectedItem != null)
            {
                string strId = RoomIdCombo.SelectedValue.ToString();
                selectedRoom = strId;
                //string strID2 = ((RoomFund)RoomIdText.SelectedItem).ID.ToString();
                int intId = Convert.ToInt32(strId);
                var countPeople = HotelManagerEntities.GetContext().RoomFund.First(p => p.ID == intId);
                CountPeopleText.Text = countPeople.NumberSeats.ToString();
            }
        }

        private void ReservRoomIdCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReservRoomIdCombo.SelectedItem != null)
            {
                string strId = ReservRoomIdCombo.SelectedValue.ToString();
                selectedRoomReserv = strId;
                
            }
        }

        private void CheckInDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateCheckIn = CheckInDateText.SelectedDate;
        }

        private void CheckOutDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateCheckOut = CheckOutDateText.SelectedDate;
        }

        private void DateBithChange(object sender, SelectionChangedEventArgs e)
        {
            dateBith = DateBithText.SelectedDate;
        }
    }
}
