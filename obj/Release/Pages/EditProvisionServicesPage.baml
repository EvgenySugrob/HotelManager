   M S B A M L   `   `   `  ���� G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HotelManager.PagesHotelManager.Pages  2    ,HotelManager.Pages.EditProvisionServicesPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:HotelManager.Pages       N� Title$  EditProvisionServicesPage��.���  � RowDefinitions �� �� �� �� �� ��  � ColumnDefinitions �� $	��230 ��� $	��220 ��� .+��� -   $��textTest��$��30(�$��1���� $��24(�$��DemiBold"�$��2��$��Center=�$��35 0 0 0q�64Добавление и редактирование�� $��20(�$��DemiBold"�$��1��$��Center=�$
��Left=�$��10 0 0 0q�Номер:�� $��20(�$��DemiBold"�$��3��$��Center=�$
��Left=�$��10 0 0 0q�ID услуги:�� $��20(�$��DemiBold"�$��2��$��Center=�$
��Left=�$��10 0 0 0q�ID Гостя:�� $��20(�$��DemiBold"�$��4��$��Center=�$
��Left=�$��10 0 0 0q�Дата оказания:�� -   $��
RoomIdText��$��1��$��1��$��18(�$
��Left=�$
��Left=�$��Center=�$	��200������ *RoomID+�� -   $��ServicesIDText��$��3��$��1��$��18(�$
��Left=�$
��Left=�$��Center=�$	��200������ *
ServicesID+�� -   $��ClientIDText��$��2��$��1��$��18(�$
��Left=�$
��Left=�$��Center=�$	��200������ *
ClientID+�� -   $��DateText��$��18(�$
��Left=�$
��Left=�$��Center=�$	��200��$��4��$��1������ *Date+ �� StringFormat$ {0:dd.MM.yyyy}��.�� � ToolTip _�  _� HasDropShadow .   _� 	Placement$ Relative=� _� VerticalOffset$ 10��.����  �� Orientation$ Vertical=�.+��� $��14(�$��DemiBold"�Формат даты�� $��14(�$��DemiBold"�
dd.MM.yyyy.���� $��5��$��2��$��Center=�$��Center=�$ 
Horizontal=�.+��� -   $��CancelBt��   
btTemplate#��[  $��18(�$��DemiBold"�$	��125��.��Отмена�� -   $��SaveBt��#��[  $��18(�$��DemiBold"�$	��125��$��15 0 0 0q�.��Сохранить�� $ Vertical=�$��0��$��2��$��3��.+��� $��2��$��20(�$;��5Справочная таблица по гостям��$��DemiBold"�$��Center=�$��Center=�$��0 0 10 0q��� -   $��LViewGuestInfo��$��0 0 10 0q�$��Hidden=�$	��200������ .R��� $ Vertical=����#D3D3D3$
��1000��.+��� $��18(�$��DemiBold"����� *	Client.ID+$ ID: {0}���� $ 
Horizontal=�.+��� $��18(����� *Client.Surname+$
 {0} ���� $��18(����� *Client.Name+$
 {0} ���� $��18(����� *Client.Patronymic+�� $��18(����� *RoomID+$ Номер: {0}���� $ Vertical=�$��3��$��2��$��3��.+��� $��2��$��20(�$=��7Справочная таблица по услугам��$��DemiBold"�$��Center=�$��Center=�$��0 0 10 0q��� -	   $��LViewServiceInfo��$��0 0 10 0q�$��Hidden=�$	��200������ .R��� $ Vertical=����#D3D3D3$
��1000��.+��� $��18(�$��DemiBold"����� *ID+$ ID: {0}���� $��18(����� *Title+