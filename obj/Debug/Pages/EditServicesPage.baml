   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HotelManager.PagesHotelManager.Pages  5      )    #HotelManager.Pages.EditServicesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:HotelManager.Pages     5        N� Title$  EditServicesPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��30 �6   6*   .+�5   
   �� $��0��6   $��0��6!   $��2��61   $b��\Добавление и редактирование дополнительных услуг��6F   $��DemiBold"�6~   $��24(�6�   $��25 0 0 0q�6�   6�   �� 5   
   $��1��6   $��DemiBold"�6!   $��Right=�67   $��Center=�6S   $��24(�6n   '%Название доп.услуги:6�   �� 5   
   $��2��6   $��DemiBold"�6!   $��Right=�67   $��Center=�6S   $��24(�6n   Цена (руб.):6�   �� 5   
   -   5        $��	TitleText��5   R   $��1��6)   $��1��66   $	��350��6F   $
��Left=�6c   $��Center=�6~   $��24(�6�   $��Center=�6�   $��10 0 0 0q�6�   ��6   �� *Title+6�   �� 5   
   -   5        $��	PriceText��5   R   $��2��6)   $��1��66   $	��350��6F   $
��Left=�6c   $��Center=�6~   $��24(�6�   $��Center=�6�   $��10 0 0 0q�6�   ��6   �� *Price+6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��3��6B   $��Center=�6O   $��Center=�6l   .+�5      �� -   5        $��SaveBt��5   A   $	��100��6   $��14(�6!   $��0 0 10 0q�6/      
btTemplate#��[  6d   .��6�   Сохранить6�   �� 5      -   5        $��CancelBt��5   /   $	��100��6   $��14(�6!   #��[  6V   .��6}   Отмена6�   5      5!      5"      