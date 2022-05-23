using System;
using System.Collections.Generic;
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
using System.Data.Entity;
using System.Linq;

namespace HotelManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        public RoomsPage()
        {
            InitializeComponent();

            // Заполнение значений ComboBox
            var allTypes = HotelManagerEntities.GetContext().TypeNumber.ToList();
            allTypes.Insert(0, new TypeNumber
            {
                Title = "Все типы"
            });
            ComboType.ItemsSource = allTypes;
            ComboType.SelectedItem = 0;
            CheckStatus.IsChecked = false;
            var currentRooms = HotelManagerEntities.GetContext().RoomFund.ToList();
            LViewRooms.ItemsSource = currentRooms;
            UpdateRooms();
        }

        private void UpdateRooms()
        {
            var currentRooms = HotelManagerEntities.GetContext().RoomFund.ToList();

            //Фильтрация
            if (ComboType.SelectedIndex > 0)
                currentRooms = currentRooms.Where(p => p.TypeID == ComboType.SelectedIndex).ToList();

            //Сортировка
            int sortIndex = Convert.ToInt32(ComboSort.SelectedIndex);
            switch (sortIndex)
            {
                case 1:
                    currentRooms = currentRooms.OrderBy(p => p.Floor).ToList();
                    break;
                case 2:
                    currentRooms = currentRooms.OrderByDescending(p => p.Floor).ToList();
                    break;
                case 3:
                    currentRooms = currentRooms.OrderBy(p => p.NumberSeats).ToList();
                    break;
                case 4:
                    currentRooms = currentRooms.OrderByDescending(p => p.NumberSeats).ToList();
                    break;
            }
            //Проверка на свободные номера
            if (CheckStatus.IsChecked.Value)
                currentRooms = currentRooms.Where(p => p.Status).ToList();

            LViewRooms.ItemsSource = currentRooms;
        }
        private void CheckStatus_Checked(object sender, RoutedEventArgs e)
        {
            UpdateRooms();
        }

        private void CheckStatus_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateRooms();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRooms();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRooms();

        }

        private void moreInfBt(object sender, RoutedEventArgs e)
        {
            ManagerNavigation.MainFrame.Navigate(new Pages.MoreInfRoomPage((sender as Button).DataContext as RoomFund));
        }
    }
}
