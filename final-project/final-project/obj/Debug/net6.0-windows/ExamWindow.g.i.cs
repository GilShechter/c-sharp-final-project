﻿#pragma checksum "..\..\..\ExamWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A9F81294BE340D687A90F5DF752FF6535D47C322"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using final_project;


namespace final_project {
    
    
    /// <summary>
    /// ExamWindow
    /// </summary>
    public partial class ExamWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\ExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid InnerGrid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\ExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QuestionsNumberBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxQuestions;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\ExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTime;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\ExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitExamBtn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\ExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel QuestionContent;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\ExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel OptionalAnswers;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\ExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrevBtn;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\ExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/final-project;component/examwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ExamWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\ExamWindow.xaml"
            ((final_project.ExamWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.InnerGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.QuestionsNumberBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.ListBoxQuestions = ((System.Windows.Controls.ListBox)(target));
            
            #line 22 "..\..\..\ExamWindow.xaml"
            this.ListBoxQuestions.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxQuestions_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.exitExamBtn = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\ExamWindow.xaml"
            this.exitExamBtn.Click += new System.Windows.RoutedEventHandler(this.exitBtnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.QuestionContent = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.OptionalAnswers = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.PrevBtn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\ExamWindow.xaml"
            this.PrevBtn.Click += new System.Windows.RoutedEventHandler(this.PrevBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.NextBtn = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\ExamWindow.xaml"
            this.NextBtn.Click += new System.Windows.RoutedEventHandler(this.NextBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

