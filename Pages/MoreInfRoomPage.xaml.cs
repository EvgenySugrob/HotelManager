using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MoreInfRoomPage.xaml
    /// </summary>
    public partial class MoreInfRoomPage : Page
    {
        private RoomFund _room = new RoomFund();
        public MoreInfRoomPage(RoomFund selectedRoom)
        {
            InitializeComponent();
            if (selectedRoom != null)
                _room = selectedRoom;
            DataContext = _room;

            var currentInRoom = HotelManagerEntities.GetContext().FillingRoom.Where(p => p.RoomID == _room.ID).ToList();
            lvRoomInfo.ItemsSource = currentInRoom;



        }
    }
}
