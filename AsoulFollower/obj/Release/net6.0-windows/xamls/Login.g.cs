﻿#pragma checksum "..\..\..\..\xamls\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BCB829CED7732D88EABDCAE639F14AAC8E196916"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using AsoulFollower.xamls;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace AsoulFollower.xamls {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\xamls\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AsoulFollower.xamls.Login LoginWindow;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\xamls\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Refresh;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\xamls\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image QRCodeImage;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\xamls\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.TextBox MessageText;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\xamls\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.ToggleSwitch Toggle_RememberMe;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AsoulFollower;component/xamls/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\xamls\Login.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LoginWindow = ((AsoulFollower.xamls.Login)(target));
            
            #line 9 "..\..\..\..\xamls\Login.xaml"
            this.LoginWindow.Deactivated += new System.EventHandler(this.LoginWindow_Deactivated);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\xamls\Login.xaml"
            this.LoginWindow.Closed += new System.EventHandler(this.LoginWindow_Closed);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\xamls\Login.xaml"
            this.LoginWindow.Loaded += new System.Windows.RoutedEventHandler(this.LoginWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Button_Refresh = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\xamls\Login.xaml"
            this.Button_Refresh.Click += new System.Windows.RoutedEventHandler(this.Button_Refresh_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.QRCodeImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.MessageText = ((HandyControl.Controls.TextBox)(target));
            return;
            case 5:
            this.Toggle_RememberMe = ((MahApps.Metro.Controls.ToggleSwitch)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

