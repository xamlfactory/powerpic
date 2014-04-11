﻿#pragma checksum "..\..\..\Views\SettingsWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "23302308266A87D6F9AAABE53E47EBB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using PicBro.Foundation.Windows.Utils;
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


namespace PicBro.Shell.Windows.Views {
    
    
    /// <summary>
    /// SettingsWindow
    /// </summary>
    public partial class SettingsWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\Views\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox accentlist;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Views\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BackgroundList;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Views\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TagPaneList;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Views\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox list;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Views\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CleanupDatabase;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\Views\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DBLocationPath;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\Views\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DBLocationBrowse;
        
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
            System.Uri resourceLocater = new System.Uri("/PicBro.Shell.Windows;component/views/settingswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\SettingsWindow.xaml"
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
            this.accentlist = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.BackgroundList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.TagPaneList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 79 "..\..\..\Views\SettingsWindow.xaml"
            this.TagPaneList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TagPaneList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.list = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.CleanupDatabase = ((System.Windows.Controls.Button)(target));
            
            #line 140 "..\..\..\Views\SettingsWindow.xaml"
            this.CleanupDatabase.Click += new System.Windows.RoutedEventHandler(this.CleanupDatabase_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DBLocationPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.DBLocationBrowse = ((System.Windows.Controls.Button)(target));
            
            #line 167 "..\..\..\Views\SettingsWindow.xaml"
            this.DBLocationBrowse.Click += new System.Windows.RoutedEventHandler(this.DBLocationBrowse_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 175 "..\..\..\Views\SettingsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnReset);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 195 "..\..\..\Views\SettingsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnSave);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 202 "..\..\..\Views\SettingsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnResetSettings);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

