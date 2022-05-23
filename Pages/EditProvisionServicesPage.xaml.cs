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
    /// Логика взаимодействия для EditProvisionServicesPage.xaml
    /// </summary>
    public partial class EditProvisionServicesPage : Page
    {
        DateTime? dateProvision;
        private ProvisionOfServices _currentPrServices = new ProvisionOfServices();
        string selectedRoom, selectClient,selectServices;
        public EditProvisionServicesPage(ProvisionOfServices selectedProvision)
        {
            InitializeComponent();
            
            if (selectedProvision != null)
                _currentPrServices = selectedProvision;

            DataContext = _currentPrServices;

            RoomIdCombo.ItemsSource = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.Actual == 1)
                .OrderBy(p=>p.RoomID).ToList();
            ServicesIDCombo.ItemsSource = HotelManagerEntities.GetContext().AdditionalServices.ToList();

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

            //if (upperCharRu.IsMatch(RoomIdCombo.Text)
            //    || lowCharRu.IsMatch(RoomIdCombo.Text)
            //    || upperChar.IsMatch(RoomIdCombo.Text)
            //    || lowerChar.IsMatch(RoomIdCombo.Text)
            //    || symbols.IsMatch(RoomIdCombo.Text))
            //    errors.AppendLine("В строке Номер не должно быть букв и спец.символов");
            //if (upperCharRu.IsMatch(ServicesIDCombo.Text)
            //    || lowCharRu.IsMatch(ServicesIDCombo.Text)
            //    || upperChar.IsMatch(ServicesIDCombo.Text)
            //    || lowerChar.IsMatch(ServicesIDCombo.Text)
            //    || symbols.IsMatch(ServicesIDCombo.Text))
            //    errors.AppendLine("В строке ID Услуги не должно быть букв и спец.символов");
            //if (upperCharRu.IsMatch(DateText.Text)
            //    || lowCharRu.IsMatch(DateText.Text)
            //    || upperChar.IsMatch(DateText.Text)
            //    || lowerChar.IsMatch(DateText.Text))
            //    errors.AppendLine("В строке даты должны быть цифры и спец.симфолы");
            try
            {
                _currentPrServices.RoomID = Convert.ToInt32(selectedRoom);
                _currentPrServices.ClientID = Convert.ToInt32(selectClient);
                _currentPrServices.ServicesID = Convert.ToInt32(selectServices);
                _currentPrServices.Date = (DateTime)dateProvision;
                var price = HotelManagerEntities.GetContext().AdditionalServices.First(p=>p.ID == _currentPrServices.ServicesID);
                _currentPrServices.PriceServices = price.Price;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(),"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            if (_currentPrServices.RoomID == null)
                errors.AppendLine("Выберете комнату");
            if (_currentPrServices.ServicesID == null)
                errors.AppendLine("Выберете услугу");
            if (_currentPrServices.Date == null)
                errors.AppendLine("Укажите дату");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_currentPrServices.ID == 0)
            {
                HotelManagerEntities.GetContext().ProvisionOfServices.Add(_currentPrServices);
            }
            try
            {
               
                //_currentPrServices.Date = DateTime.Parse(DateText.Text);
                HotelManagerEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                ManagerNavigation.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.GoBack();
        }

        private void DatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateProvision = DatePick.SelectedDate;
        }

        private void RoomIdCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoomIdCombo.SelectedItem != null)
            {
                string strId = RoomIdCombo.SelectedValue.ToString();
                selectedRoom = strId;
                int roomId = Convert.ToInt32(strId);
                var clienID = HotelManagerEntities.GetContext().CheckInCheckOut.First(p => p.RoomID == roomId && p.Actual == 1);
                selectClient = clienID.ClientID.ToString();
                var clientName = HotelManagerEntities.GetContext().Client.First(p => p.ID == clienID.ClientID);
                ClientText.Text = clientName.Surname.ToString() + " " +
                   clientName.Name.ToString() + " " +
                   clientName.Patronymic.ToString();

            }
        }

        private void ServicesIDCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServicesIDCombo.SelectedItem != null)
            {
                string strId = ServicesIDCombo.SelectedValue.ToString();
                selectServices = strId;
                
            }
        }
    }
}
