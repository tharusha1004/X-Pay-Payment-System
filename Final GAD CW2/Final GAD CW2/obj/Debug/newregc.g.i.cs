﻿#pragma checksum "..\..\newregc.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F43E7BD9BA28F94BFB7F6A059DDFFCE44B97CE099AF3C0A8B4C1D63F08CC2D7E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Final_GAD_CW2;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Final_GAD_CW2 {
    
    
    /// <summary>
    /// newregc
    /// </summary>
    public partial class newregc : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_name;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_age;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtp_birth;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_nic;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_mobile;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_username;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_password;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_email;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image upd_img;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\newregc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCloseMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/Xpay;component/newregc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\newregc.xaml"
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
            this.txt_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txt_age = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dtp_birth = ((System.Windows.Controls.DatePicker)(target));
            
            #line 41 "..\..\newregc.xaml"
            this.dtp_birth.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dtp_birth_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_nic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_mobile = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txt_username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.txt_email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.upd_img = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            
            #line 100 "..\..\newregc.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.buttonCloseMessage = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\newregc.xaml"
            this.buttonCloseMessage.Click += new System.Windows.RoutedEventHandler(this.buttonCloseMessage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

