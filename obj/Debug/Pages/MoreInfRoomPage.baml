   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HotelManager.PagesHotelManager.Pages  5      (    "HotelManager.Pages.MoreInfRoomPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:HotelManager.Pages     5        N� Title$  MoreInfRoomPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��24(�6   $��DemiBold"�6"   $��2��6h   $
��Left=�6|   $��10 5 0 0q�6�   ��68   �� *ID+ �� StringFormat$ Номер: {0}��6�   �� 5   
   -   5        $��
lvRoomInfo��5   2   $
��Left=�6   $��1��6D   $��2��6Q   $��Hidden=�6e   ��6�   Z� ��6�   Z� ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   $	��Top=�6:   $��Center=�6R   .+�5      �� $	��550��6    $	��450��6,   $
��Fill=�69   $��10 0 0 0q�6H   ��5      �� 5   "    �� Path$ 	ImageRoom�6*   5   #   5       �� 5!      $ Vertical=�6%   $
��Left=�6<   $��1��6W   $��1��6d   $	��300��6t   .+�5"      �� $��18(�6(   $��DemiBold"�66   $��В комнате:��6L   $��	10 10 0 0q�6^   6s   �� 5#      $��
inRoomText��66   $��18(�6(   $
��Wrap=�6`   $��	10 10 0 0q�6t   ��6H   �� *InRoom+6t   �� 5$      $��18(�6(   $��DemiBold"�66   $��В ванной:��6L   $��	10 10 0 0q�6]   6r   �� 5%      $��inBathroomText��66   $��18(�6(   $
��Wrap=�6h   $��	10 10 0 0q�6|   ��6L   �� *
InBathroom+6�   5&      5'      5(      5*      59      5:      