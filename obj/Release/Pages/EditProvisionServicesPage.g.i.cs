﻿#pragma checksum "..\..\..\Pages\EditProvisionServicesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "971C438644ECAF7816C8C8B4FB6A1485E9C9A2F6C160425C668615CED0CC2A5C"
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
    /// EditProvisionServicesPage
    /// </summary>
    public partial class EditProvisionServicesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Pages\EditProvisionServicesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textTest;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\EditProvisionServicesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomIdText;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\EditProvisionServicesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ServicesIDText;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\EditProvisionServicesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ClientIDText;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\EditProvisionServicesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DateText;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\EditProvisionServicesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBt;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\EditProvisionServicesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBt;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\EditProvisionServicesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LViewGuestInfo;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Pages\EditProvisionServicesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LViewServiceInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/HotelManager;component/pages/editprovisionservicespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\EditProvisionServicesPage.xaml"
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
            this.textTest = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.RoomIdText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ServicesIDText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ClientIDText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.DateText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.CancelBt = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Pages\EditProvisionServicesPage.xaml"
            this.CancelBt.Click += new System.Windows.RoutedEventHandler(this.CancelBt_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SaveBt = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Pages\EditProvisionServicesPage.xaml"
            this.SaveBt.Click += new System.Windows.RoutedEventHandler(this.SaveBt_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LViewGuestInfo = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.LViewServiceInfo = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
