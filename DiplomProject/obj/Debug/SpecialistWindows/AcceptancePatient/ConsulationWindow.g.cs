﻿#pragma checksum "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2557B9AB16BF9B90C6B10F7CC21E2759731D919CF5AFC7B64BCD3128636E6016"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DiplomProject.RegistrationWindows;
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


namespace DiplomProject.RegistrationWindows {
    
    
    /// <summary>
    /// ConsulationWindow
    /// </summary>
    public partial class ConsulationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox specialization_cmb;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox employees_cmb;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox room_cmb;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_dp;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox time_cmb;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patients_txb;
        
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
            System.Uri resourceLocater = new System.Uri("/DiplomProject;component/specialistwindows/acceptancepatient/consulationwindow.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
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
            
            #line 25 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.specialization_cmb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
            this.specialization_cmb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.specialization_cmb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.employees_cmb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 31 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
            this.employees_cmb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.employees_cmb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.room_cmb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
            this.room_cmb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.employees_cmb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.date_dp = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.time_cmb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
            this.time_cmb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.time_cmb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.patients_txb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 43 "..\..\..\..\SpecialistWindows\AcceptancePatient\ConsulationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

