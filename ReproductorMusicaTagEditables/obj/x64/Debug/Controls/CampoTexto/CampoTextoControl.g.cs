﻿#pragma checksum "..\..\..\..\..\Controls\CampoTexto\CampoTextoControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E7E8EC698435F72A37A48FBEB06E568BFE03CCABB7077801C81C565502EA8C7B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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


namespace ReproductorMusicaTagEditables.Controls.CampoTexto {
    
    
    /// <summary>
    /// CampoTextoControl
    /// </summary>
    public partial class CampoTextoControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 4 "..\..\..\..\..\Controls\CampoTexto\CampoTextoControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Controls.CampoTexto.CampoTextoControl campoTexto;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\..\Controls\CampoTexto\CampoTextoControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtPlaceholder;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\Controls\CampoTexto\CampoTextoControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBox;
        
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
            System.Uri resourceLocater = new System.Uri("/ReproductorMusicaTagEditables;component/controls/campotexto/campotextocontrol.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controls\CampoTexto\CampoTextoControl.xaml"
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
            this.campoTexto = ((ReproductorMusicaTagEditables.Controls.CampoTexto.CampoTextoControl)(target));
            return;
            case 2:
            this.txtPlaceholder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\..\..\Controls\CampoTexto\CampoTextoControl.xaml"
            this.txtBox.GotFocus += new System.Windows.RoutedEventHandler(this.txtBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\..\..\Controls\CampoTexto\CampoTextoControl.xaml"
            this.txtBox.LostFocus += new System.Windows.RoutedEventHandler(this.txtBox_LostFocus);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\..\..\Controls\CampoTexto\CampoTextoControl.xaml"
            this.txtBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

