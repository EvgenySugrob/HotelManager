   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HotelManager.PagesHotelManager.Pages  5      6    0HotelManager.Pages.EditReservationInRegistration   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:HotelManager.Pages     5        N� Title$#  EditReservationInRegistration��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��24(�6   $��DemiBold"�6"   $��2��68   $
��Left=�6L   $��50 0 0 0q�6g   $��Center=�6y   <:Регистрация после бронирования6�   �� 5   
   $��1��6   $��18(�6!   $��DemiBold"�6/   $��Right=�6E   $��Center=�6a   $��0 0 5 0q�6|   Гость:6�   �� 5   
   $��2��6   $��18(�6!   $��DemiBold"�6/   $��Right=�6E   $��Center=�6a   $��0 0 5 0q�6|   Комната:6�   �� 5   
   $��3��6   $��18(�6!   $��DemiBold"�6/   $��Right=�6E   $��Center=�6a   $��0 0 5 0q�6|   Кол-во человек:6�   �� 5   
   $��4��6   $��18(�6!   $��DemiBold"�6/   $��Right=�6E   $��Center=�6a   $��0 0 5 0q�6|   Дата заезда:6�   �� 5   
   $��5��6   $��18(�6!   $��DemiBold"�6/   $��Right=�6E   $��Center=�6a   $��0 0 5 0q�6|   Дата отъезда:6�   �� 5!   
   $��1��6   $��1��6%    �� Orientation$ 
Horizontal=�62   $
��Left=�6K   $��Center=�6f   .+�5"      �� $��18(�6   $��0 0 5 0q�6&   ��67   �� *Client.Surname+6Y   �� 5#      $��18(�6   $��0 0 5 0q�6&   ��67   �� *Client.Name+6V   �� 5$      $��18(�6   ��6&   �� *Client.Patronymic+6K   5%      �� 5&   
   -   5        $��CountPeopleText��5&   #   $��5 0 0 0q�6   $��1��6;   $��3��6K   $
��Left=�6X   $��Center=�6s   $��18(�6�   $	��250��6�   6�   �� 5'   
   -   5        $��
RoomIdText��5'   #   $��5 0 0 0q�6   $��1��6M   $��2��6]   $
��Left=�6j   $��Center=�6�   $��18(�6�   $	��250��6�   ��65   �� *RoomID+6�   (  "System.Windows.Controls.DatePicker  5(   
   -   5        $��CheckInDatePick��5(   `   $��5 0 0 0q�6   $��1��6w   $��4��6�   $
��Left=�6�   $��Center=�6�   $��18(�6�   $	��250��6�   6�     5)   
   -   5        $��CheckOutDatePick��5)   a   $��5 0 0 0q�6   $��1��6y   $��5��6�   $
��Left=�6�   $��Center=�6�   $��18(�6�   $	��250��6�   5+      �� 5-   
   $��6��6   $��2��6"   $��Center=�66   $��Center=�6Q   $ 
Horizontal=�6n   .+�5.      �� -   5        $��SaveBt��5.      $��18(�68      
btTemplate#��[  6F   $��DemiBold"�6m   $	��125��6�   $��0 0 15 0q�6�   .��6�   Сохранить6�   �� 5/      -   5        $��CancelBt��5/      $��18(�6<   #��[  6J   $��DemiBold"�6q   $	��125��6�   $��15 0 0 0q�6�   .��6�   Отмена6�   50      51      52      