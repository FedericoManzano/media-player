﻿#pragma checksum "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B23D9D6CF410922721DFE67242E32F35644BF01012ADDD07AD5893187DE6F813"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
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


namespace ReproductorMusicaTagEditables.Controls.ListaAvatar {
    
    
    /// <summary>
    /// ListaAvatarControl
    /// </summary>
    public partial class ListaAvatarControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Controls.ListaAvatar.ListaAvatarControl visorListas;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bordePrincipal;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bordeDefecto;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bordeImagen1;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bordeImagen2;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bordeImagen3;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bordeImagen4;
        
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
            System.Uri resourceLocater = new System.Uri("/ReproductorMusicaTagEditables;component/controls/listaavatar/listaavatarcontrol." +
                    "xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
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
            this.visorListas = ((ReproductorMusicaTagEditables.Controls.ListaAvatar.ListaAvatarControl)(target));
            return;
            case 2:
            this.bordePrincipal = ((System.Windows.Controls.Border)(target));
            
            #line 13 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
            this.bordePrincipal.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Border_MouseEnter);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
            this.bordePrincipal.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Border_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.bordeDefecto = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.bordeImagen1 = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.bordeImagen2 = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.bordeImagen3 = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.bordeImagen4 = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            
            #line 85 "..\..\..\..\Controls\ListaAvatar\ListaAvatarControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
