﻿#pragma checksum "..\..\..\..\Pages\Admin\QuestionGroupView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D4074C74929FBFA615CAE7097AB93FBE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
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


namespace TheEnterprise.Pages {
    
    
    /// <summary>
    /// QuestionGroupView
    /// </summary>
    public partial class QuestionGroupView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\Pages\Admin\QuestionGroupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid viewGrid;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Pages\Admin\QuestionGroupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView QuestionGroupListBox;
        
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
            System.Uri resourceLocater = new System.Uri("/TheEnterprise;component/pages/admin/questiongroupview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Admin\QuestionGroupView.xaml"
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
            this.viewGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 9 "..\..\..\..\Pages\Admin\QuestionGroupView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenQuestionGroup_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 10 "..\..\..\..\Pages\Admin\QuestionGroupView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateQuestionGroup_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 11 "..\..\..\..\Pages\Admin\QuestionGroupView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateQuetionGroup_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 12 "..\..\..\..\Pages\Admin\QuestionGroupView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteQuestionGroup_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 13 "..\..\..\..\Pages\Admin\QuestionGroupView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backToStart_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.QuestionGroupListBox = ((System.Windows.Controls.ListView)(target));
            
            #line 17 "..\..\..\..\Pages\Admin\QuestionGroupView.xaml"
            this.QuestionGroupListBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.QuestionGroupListBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

