﻿#pragma checksum "..\..\..\UserControl\UserControlStudy.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "292DDD6F441E36C9C7B8CAF0430EA5F277CB6C91496FC18609DD4085D651A852"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Fiszki;
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


namespace Fiszki {
    
    
    /// <summary>
    /// UserControlStudy
    /// </summary>
    public partial class UserControlStudy : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\UserControl\UserControlStudy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TrainsitionigContentSlide;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UserControl\UserControlStudy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxCategory;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UserControl\UserControlStudy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Start;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UserControl\UserControlStudy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelFiszka;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UserControl\UserControlStudy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxAnswer;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UserControl\UserControlStudy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LockAnswer;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UserControl\UserControlStudy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelAnswer;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UserControl\UserControlStudy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelStatistics;
        
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
            System.Uri resourceLocater = new System.Uri("/Fiszki;component/usercontrol/usercontrolstudy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControl\UserControlStudy.xaml"
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
            this.TrainsitionigContentSlide = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 2:
            this.ComboBoxCategory = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Start = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\UserControl\UserControlStudy.xaml"
            this.Start.Click += new System.Windows.RoutedEventHandler(this.Start_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LabelFiszka = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.TextBoxAnswer = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\UserControl\UserControlStudy.xaml"
            this.TextBoxAnswer.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBoxAnswer_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LockAnswer = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\UserControl\UserControlStudy.xaml"
            this.LockAnswer.Click += new System.Windows.RoutedEventHandler(this.LockAnswer_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LabelAnswer = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.LabelStatistics = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
