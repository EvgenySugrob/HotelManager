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
using Word = Microsoft.Office.Interop.Word;

namespace HotelManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для PaymentGuestPage.xaml
    /// </summary>
    public partial class PaymentGuestPage : Page
    {
        private readonly string WordFileName = @"C:\Mediafiles\C#\HotelManager\gostinka_3.doc";
        private CheckInCheckOut _check = new CheckInCheckOut();
        public PaymentGuestPage(CheckInCheckOut selectedGuest)
        {
            InitializeComponent();

            if (selectedGuest != null)
                _check = selectedGuest;

            DataContext = _check;

            var currentServices = HotelManagerEntities.GetContext().ProvisionOfServices.
                Where(p => p.ClientID == _check.ClientID).ToList();
            LViewAddService.ItemsSource = currentServices;

            int countDay = Convert.ToInt32(_check.CheckOutDate.Subtract(_check.CheckInDate).TotalDays);
            CountDayText.Text = Convert.ToString(countDay);

            var roomID = HotelManagerEntities.GetContext().RoomFund.First(p => p.ID == _check.RoomID);
            var priceRoom = HotelManagerEntities.GetContext().TypeNumber.First(p => p.ID == roomID.TypeID);
            AmountDaysText.Text = Convert.ToString(countDay * priceRoom.Price);

            var countServices = HotelManagerEntities.GetContext().ProvisionOfServices.Where(p=>p.ClientID == _check.ClientID);
            CountServicesText.Text = Convert.ToString(countServices.Count());

            int amountPrice = currentServices.Sum(n=>n.AdditionalServices.Price);
            AmountServicesText.Text = Convert.ToString(amountPrice);

            TotalText.Text = Convert.ToString((countDay * priceRoom.Price) + amountPrice);
        }

        private void closeCheckBtClick(object sender, RoutedEventArgs e)
        {
            var currentServices = HotelManagerEntities.GetContext().ProvisionOfServices.
                Where(p => p.ClientID == _check.ClientID).ToList();

            if (MessageBox.Show($"Вы точно хотите закрыть текущий счет?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                int countDay = Convert.ToInt32(_check.CheckOutDate.Subtract(_check.CheckInDate).TotalDays);
                var roomID = HotelManagerEntities.GetContext().RoomFund.First(p => p.ID == _check.RoomID);
                var priceRoom = HotelManagerEntities.GetContext().TypeNumber.First(p => p.ID == roomID.TypeID);
                int amountPrice = currentServices.Sum(n => n.AdditionalServices.Price);
                try
                {
                    _check.Actual = 0;
                    
                    roomID.Status = true;
                    HotelManagerEntities.GetContext().SaveChanges();

                    var wordApp = new Word.Application();
                    var wordDocuments = wordApp.Documents.Open(WordFileName);
                    ReplaceWordStub("{IdReceipt}",_check.ID.ToString(),wordDocuments);
                    ReplaceWordStub("{DateNow}",DateTime.Now.ToLongDateString(),wordDocuments);
                    ReplaceWordStub("{Date}", DateTime.Now.ToShortDateString(), wordDocuments);
                    ReplaceWordStub("{IdRoomGuest}",_check.RoomID.ToString(),wordDocuments);
                    string clientName = surnameText.Text + " " + nameText.Text + " " + patronymicText.Text;
                    ReplaceWordStub("{NameGuest}", clientName, wordDocuments);
                    ReplaceWordStub("{DateOfCheckIn}",_check.CheckInDate.ToShortDateString(),wordDocuments);
                    ReplaceWordStub("{DateOfCheckOut}", _check.CheckOutDate.ToShortDateString(), wordDocuments);
                    ReplaceWordStub("{CountOfDay}", CountDayText.Text, wordDocuments);
                    ReplaceWordStub("{PriceOneDay}", priceRoom.Price.ToString() + " руб.", wordDocuments);
                    ReplaceWordStub("{AllDayPrice}",(countDay*priceRoom.Price).ToString() + " руб.",wordDocuments);


                    Word.Paragraph tableParagraph = wordDocuments.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;
                    tableParagraph.set_Style("Подзаголовок");
                    Word.Table servicesTable = wordDocuments.Tables.Add(tableRange, currentServices.Count()+1,3);
                    servicesTable.Borders.InsideLineStyle = servicesTable.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                    servicesTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellRange;
                    cellRange = servicesTable.Cell(1, 1).Range;
                    cellRange.Text = "№";
                    cellRange = servicesTable.Cell(1, 2).Range;
                    cellRange.Text = "Услуга";
                    cellRange = servicesTable.Cell(1, 3).Range;
                    cellRange.Text = "Цена";

                    servicesTable.Rows[1].Range.Bold = 1;
                    servicesTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    
                    for (int i = 0; i < currentServices.Count(); i++)
                    {
                        var selectServices = currentServices[i];
                        var additionalServic = HotelManagerEntities.GetContext().AdditionalServices.
                            First(p => p.ID == selectServices.ServicesID);
                        cellRange = servicesTable.Cell(i + 2, 1).Range;
                        cellRange.Text = Convert.ToString(i + 1);

                        cellRange = servicesTable.Cell(i + 2, 2).Range;
                        cellRange.Text = additionalServic.Title; //Сделать switch case

                        cellRange = servicesTable.Cell(i + 2, 3).Range;
                        cellRange.Text = selectServices.PriceServices.ToString()+" руб.";

                    }
                    Word.Paragraph sumServicParagraph = wordDocuments.Paragraphs.Add();
                    Word.Range sumServicRange = sumServicParagraph.Range;
                    sumServicRange.Text ="Сумма доп. услуг: " + amountPrice.ToString() + " руб.";
                    sumServicParagraph.set_Style("Отступ");
                    sumServicRange.Bold = 1;
                    sumServicParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    sumServicRange.InsertParagraphAfter();

                    Word.Paragraph allSumParagraph = wordDocuments.Paragraphs.Add();
                    Word.Range allSumRange = allSumParagraph.Range;
                    allSumRange.Text ="Итого: " + ((countDay * priceRoom.Price) + amountPrice).ToString() + " руб.";
                    allSumParagraph.set_Style("Отступ");
                    allSumRange.Bold = 1;
                    allSumParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    allSumRange.InsertParagraphAfter();

                   




                    //@"C:\Mediafiles\C#\HotelManager\gostinka_3.doc"

                    wordApp.Visible = true;

                    MessageBox.Show("Счет закрыт", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    ManagerNavigation.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
            
        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText:stubToReplace, ReplaceWith:text);
        }
    }
}
