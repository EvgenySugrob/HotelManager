   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HotelManager.PagesHotelManager.Pages  5      2    ,HotelManager.Pages.EditProvisionServicesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:HotelManager.Pages     5        N� Title$  EditProvisionServicesPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $	��230 �6   6-   �� 5      $	��300 �6   6-   .+�5   
   �� -   5        $��textTest��5   2   $��30(�6   $��1��6"   6D   �� 5   
   $��24(�6   $��DemiBold"�6"   $��2��68   $��Center=�6L   $��35 0 0 0q�6g   64Добавление и редактирование6�   �� 5   
   $��20(�6   $��DemiBold"�6#   $��1��69   $��Center=�6F   $
��Left=�6a   $��10 0 0 0q�6|   Номер:6�   �� 5   
   $��20(�6   $��DemiBold"�6#   $��3��69   $��Center=�6F   $
��Left=�6a   $��10 0 0 0q�6|   Услуга:6�   �� 5   
   $��20(�6   $��DemiBold"�6#   $��2��69   $��Center=�6F   $
��Left=�6a   $��10 0 0 0q�6|   Гость:6�   �� 5   
   $��20(�6   $��DemiBold"�6#   $��4��69   $��Center=�6F   $
��Left=�6a   $��10 0 0 0q�6|   Дата оказания:6�   �� 5!   
   -   5        $��RoomIdCombo��5!   Q   �� SelectedValuePath$ RoomID��6�    �� DisplayMemberPath$ RoomID��6�   $��1��6�   $��1��6�   $��18(�6�   $
��Left=�6�   $
��Left=�6  $��Center=�6*  $	��200��6E   �� SelectedValue 6C   �� *RoomID+��6d   �� *CheckInCheckOut+6g  �� 5#   
   -   5        $��ServicesIDCombo��5#   c  $ ID��6�   $ Title��6�   $��3��6�   $��1��6�   $��18(�6�   $
��Left=�6�   $
��Left=�6!  $��Center=�6<  $	��200��6W   6G   �� *AdditionalServices.ID+��6w   �� *AdditionalServices+6}  �� 5%   
   -   5        $��
ClientText��5%   x   $��2��6   $��1��6"   $��18(�62   $
��Left=�6A   $��Center=�6\   6�   (  "System.Windows.Controls.DatePicker  5&   
   -   5        $��DatePick��5&     $��18(�6H      DisplayDateStart$ 1/1/2022X�6V      DisplayDateEnd$ 
12/31/2090X�6r      SelectedDateFormat$ Short=�6�   $
��Left=�6�   $
��Left=�6�   $��Center=�6�   $��4��6  $��1��6  5(      �� 5+   
   $��5��6   $��2��6"   $��Center=�66   $��Center=�6S   	 �� Orientation$	 
Horizontal=�6n   .+�5,      �� -   5        $��CancelBt��5,         
btTemplate#��[  6<   $��18(�6c   $��DemiBold"�6q   $	��125��6�   .��6�   Отмена6�   �� 5-      -   5        $��SaveBt��5-      #��[  68   $��18(�6_   $��DemiBold"�6m   $	��125��6�   $��15 0 0 0q�6�   .��6�   Сохранить6�   5.      51      52      