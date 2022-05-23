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
    /// Логика взаимодействия для EditServicesPage.xaml
    /// </summary>
    public partial class EditServicesPage : Page
    {
        private AdditionalServices _currentAdditionalaServices = new AdditionalServices();
        public EditServicesPage( AdditionalServices selectedServices)
        {
            InitializeComponent();
            if (selectedServices!=null)
            {
                _currentAdditionalaServices = selectedServices;
            }
            DataContext = _currentAdditionalaServices;
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

            if (upperCharRu.IsMatch(PriceText.Text)
                || lowCharRu.IsMatch(PriceText.Text)
                || upperChar.IsMatch(PriceText.Text)
                || lowerChar.IsMatch(PriceText.Text)
                || symbols.IsMatch(PriceText.Text))
                errors.AppendLine("Поле Цены не может содержать в себе буквы и спец.симфолы");
            
            if (string.IsNullOrWhiteSpace(_currentAdditionalaServices.Title))
                errors.AppendLine("Укажите название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_currentAdditionalaServices.ID == 0)
                HotelManagerEntities.GetContext().AdditionalServices.Add(_currentAdditionalaServices);

            try
            {
                HotelManagerEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена","Сообщение",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            TitleText.Clear();
            PriceText.Clear();
            ManagerNavigation.MainFrame.GoBack();
        }
    }
}
