#pragma checksum "..\..\..\Pages\EditReservationInRegistration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DA41E5C60BD4625BCD8EB14E1A7F3BED96EC20293E4BB865B3EA05B8BD02E693"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HotelManager.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HotelManager.Pages {
    
    
    /// <summary>
    /// EditReservationInRegistration
    /// </summary>
    public partial class EditReservationInRegistration : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\Pages\EditReservationInRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountPeopleText;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\EditReservationInRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomIdText;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\EditReservationInRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker CheckInDatePick;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\EditReservationInRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker CheckOutDatePick;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Pages\EditReservationInRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBt;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Pages\EditReservationInRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HotelManager;component/pages/editreservationinregistration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\EditReservationInRegistration.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CountPeopleText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.RoomIdText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.CheckInDatePick = ((System.Windows.Controls.DatePicker)(target));
            
            #line 40 "..\..\..\Pages\EditReservationInRegistration.xaml"
            this.CheckInDatePick.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.CheckInDatePick_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CheckOutDatePick = ((System.Windows.Controls.DatePicker)(target));
            
            #line 41 "..\..\..\Pages\EditReservationInRegistration.xaml"
            this.CheckOutDatePick.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.CheckOutDatePick_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SaveBt = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Pages\EditReservationInRegistration.xaml"
            this.SaveBt.Click += new System.Windows.RoutedEventHandler(this.SaveBt_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CancelBt = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\Pages\EditReservationInRegistration.xaml"
            this.CancelBt.Click += new System.Windows.RoutedEventHandler(this.CancelBt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

