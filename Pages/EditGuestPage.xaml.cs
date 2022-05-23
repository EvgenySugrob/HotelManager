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
    /// Логика взаимодействия для EditGuestPage.xaml
    /// </summary>
    public partial class EditGuestPage : Page
    {
        private Client _currentClient = new Client();
        public EditGuestPage(Client selectedClient)
        {
            InitializeComponent();
            if (selectedClient != null)
                _currentClient = selectedClient;

            DataContext = _currentClient;
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

            if (numbers.IsMatch(SurnameText.Text)
                || numbers.IsMatch(NameText.Text)
                || numbers.IsMatch(PatronymicText.Text))
                errors.AppendLine("В строке Фамилии/Имени/Отчества не должно быть цифр");
            if (symbols.IsMatch(SurnameText.Text)
                || symbols.IsMatch(NameText.Text)
                || symbols.IsMatch(PatronymicText.Text))
                errors.AppendLine("В строке Фамилии/Имени/Отчества не должно быть спец.символов");
            if (upperCharRu.IsMatch(DataBithText.Text)
                || lowCharRu.IsMatch(DataBithText.Text)
                || upperChar.IsMatch(DataBithText.Text)
                || lowerChar.IsMatch(DataBithText.Text))
                errors.AppendLine("В строке даты рождения должны быть цифры и спец.симфолы");
            if (upperCharRu.IsMatch(PassportDataText.Text)
                || lowCharRu.IsMatch(PassportDataText.Text)
                || upperChar.IsMatch(PassportDataText.Text)
                || lowerChar.IsMatch(PassportDataText.Text))
                errors.AppendLine("В строке паспортных данных необходимо указать серию и номер паспорта");
            if (numbers.IsMatch(NationalityText.Text)
                || symbols.IsMatch(NationalityText.Text))
                errors.AppendLine("В строке Национальность не должно быть цифр и спец.символов");
            if (upperCharRu.IsMatch(TelephonText.Text)
                || lowCharRu.IsMatch(TelephonText.Text)
                || upperChar.IsMatch(TelephonText.Text)
                || lowerChar.IsMatch(TelephonText.Text))
                errors.AppendLine("В строке Телефон должны быть цифры и спец символы");

            if (string.IsNullOrWhiteSpace(_currentClient.Surname)
                || string.IsNullOrWhiteSpace(_currentClient.Name)
                || string.IsNullOrWhiteSpace(_currentClient.Patronymic))
                errors.AppendLine("Строка Фамилии/Имени/Отчества не может быть пустой");
            if (_currentClient.DateOfBirth == null)
                errors.AppendLine("Строка даты рождения не может быть пустой");
            if (string.IsNullOrEmpty(_currentClient.PassportDate))
                errors.AppendLine("Строка паспортные данные не может быть пустой");
            if (string.IsNullOrEmpty(_currentClient.Address))
                errors.AppendLine("Строка адреса не может быть пустой");
            if (string.IsNullOrEmpty(_currentClient.Nationality))
                errors.AppendLine("Строка гражданство не может быть пустой");
            if (string.IsNullOrEmpty(_currentClient.Telephone))
                errors.AppendLine("Строка телефона не может быть пустой");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _currentClient.DateOfBirth = DateTime.Parse(DataBithText.Text);
                HotelManagerEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно изменены","Сообщение",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()+"\nПроверьте правильность заполнения полей","Ошибка",
                    MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
