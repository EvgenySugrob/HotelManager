﻿#pragma checksum "..\..\..\Pages\EditGuestPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D04A97FA83E36DF30E8B7FC3783ACE10698E7DDA77BC5DD274C34BC68E73F4CE"
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
    /// EditGuestPage
    /// </summary>
    public partial class EditGuestPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\Pages\EditGuestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameText;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\EditGuestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameText;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\EditGuestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PatronymicText;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\EditGuestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DataBithText;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\EditGuestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PassportDataText;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\EditGuestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NationalityText;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Pages\EditGuestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TelephonText;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Pages\EditGuestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBt;
        
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
            System.Uri resourceLocater = new System.Uri("/HotelManager;component/pages/editguestpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\EditGuestPage.xaml"
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
            this.SurnameText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.NameText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PatronymicText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DataBithText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PassportDataText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.NationalityText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TelephonText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.SaveBt = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Pages\EditGuestPage.xaml"
            this.SaveBt.Click += new System.Windows.RoutedEventHandler(this.SaveBt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
