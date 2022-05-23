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
using System.Windows.Shapes;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace HotelManager
{
    /// <summary>
    /// Логика взаимодействия для DialogExportWindow.xaml
    /// </summary>
    public partial class DialogExportWindow : Window
    {
        DateTime? firstDate, secondDate;
        public DialogExportWindow()
        {
            InitializeComponent();
        }



        private void firstDateChang(object sender, SelectionChangedEventArgs e)
        {
            firstDate = firstDatePicker.SelectedDate;
        }

        private void createExcelClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook;
                Excel.Worksheet worksheet;
                workbook = application.Workbooks.Open(@"C:\Mediafiles\C#\HotelManager\Shablon.xlsx");
                worksheet = workbook.Worksheets["Лист1"];

                worksheet.Range["B2"].Value = firstDate.Value.Date.ToShortDateString() + " - " + secondDate.Value.Date.ToShortDateString();
                int countDay = Convert.ToInt32(secondDate.Value.Subtract(firstDate.Value).TotalDays);
                worksheet.Range["B4"].Value = countDay;
                int numberOfNight = countDay * HotelManagerEntities.GetContext().RoomFund.Count();
                worksheet.Range["B5"].Value = numberOfNight;
                var currentNumbOfNight = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.CheckInDate >= firstDate &&
                p.CheckInDate <= secondDate || p.CheckOutDate >= firstDate && p.CheckOutDate <= secondDate).ToList();

                int sellNight = numberOfNight * currentNumbOfNight.Count() / HotelManagerEntities.GetContext().RoomFund.Count();
                worksheet.Range["B6"].Value = sellNight;
                worksheet.Range["B7"].Value = numberOfNight - sellNight;
                worksheet.Range["B9"].Value = currentNumbOfNight.Sum(p => p.CountOfPeopl);
                worksheet.Range["B11"].Value = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.CheckInDate >= firstDate &&
                p.CheckInDate <= secondDate).Count();
                worksheet.Range["B12"].Value = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.CheckOutDate >= firstDate &&
                p.CheckOutDate <= secondDate).Count();
                worksheet.Range["B13"].Value = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.CheckInDate >= firstDate &&
                p.CheckInDate <= secondDate).Sum(p => p.CountOfPeopl);
                worksheet.Range["B14"].Value = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.CheckOutDate >= firstDate &&
                p.CheckOutDate <= secondDate).Sum(p => p.CountOfPeopl);


                worksheet.Range["B16"].Value = HotelManagerEntities.GetContext().ProvisionOfServices.Where(p=>p.Date >= firstDate && p.Date <= secondDate)
                    .Sum(p=>p.PriceServices) + HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.CheckInDate >= firstDate &&
                p.CheckInDate <= secondDate || p.CheckOutDate >= firstDate && p.CheckOutDate <= secondDate).Sum(p => p.PriceAllDay);
                worksheet.Range["B17"].Value = HotelManagerEntities.GetContext().CheckInCheckOut.Where(p => p.CheckInDate >= firstDate &&
                p.CheckInDate <= secondDate || p.CheckOutDate >= firstDate && p.CheckOutDate <= secondDate).Sum(p => p.PriceAllDay);



                application.Visible = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        private void secondDateChang(object sender, SelectionChangedEventArgs e)
        {
            secondDate = secondDatePicker.SelectedDate;
        }

        
    }
}
