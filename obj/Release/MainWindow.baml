   M S B A M L   `   `   `  ���� G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HotelManagerHotelManager      HotelManager.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:HotelManager       � Title$  Hotel Manager��$	��700��$
��1000�� � WindowStartupLocation$ CenterScreen=� � Icon$ icon.png��.���  � RowDefinitions �� $��75 ��� $��* ��� $��30 � � ColumnDefinitions �� $	��130 ��� $��* �.+��� ���	#FF494747$��3���� ���	#ff494747$��1���� -   $��BackBt��$��	0 0 100 0q�$��Center=�$��Right=�$��18(�   
btTemplate#��[  
�������$y�Hidden=�$��1��.��
Назад�� $��
logoHM.png��$��UniformToFill=�$��	0,-28,0,0q� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� ��  �� AngleX$ 0.735Q��� T�  T� X$ 	-0.173687Q�� $��1�� � Orientation$ Vertical=�$
��Left=�$��10 5 0 0q�.+��� -   $��MainBt��#��[  
�������$��0 5 0 0q�.��� $ Vertical=�.+��� $��MainPage.png��$��80��$	��100���� $��Главная��$��Center=�$��DemiBold"�$��15(��� -   $��RegistrationBt��#��[  
�������$��0 5 0 0q�.��� $ Vertical=�.+��� $��Registration.png��$��80��$	��100���� $��Регистрация��$��Center=�$��DemiBold"�$��15(��� -   $��RoomsBt��#��[  
�������$��0 5 0 0q�.��� $ Vertical=�.+��� $��Bedroom.png��$��80��$	��100���� $��Комнаты��$��Center=�$��DemiBold"�$��15(��� -   $��GuestBt��#��[  
�������$��0 5 0 0q�.��� $ Vertical=�.+��� $��
People.png��$��80��$	��100���� $��
Гости��$��Center=�$��DemiBold"�$��15(��� -   $��AdditionServiceBt��#��[  
�������$��0 5 0 0q�.��� $ Vertical=�.+��� $��addServise.png��$��80��$	��100���� $��Доп.Услуги��$��Center=�$��DemiBold"�$��15(� � -   $��NavigationFrame��$��1��$��1��	  � NavigationUIVisibility$	 Hidden=�