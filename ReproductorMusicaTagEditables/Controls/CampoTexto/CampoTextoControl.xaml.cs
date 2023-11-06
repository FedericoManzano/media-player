using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReproductorMusicaTagEditables.Controls.CampoTexto
{
    /// <summary>
    /// Lógica de interacción para CampoTextoControl.xaml
    /// </summary>
    public partial class CampoTextoControl : UserControl
    {
        public CampoTextoControl()
        {
            InitializeComponent();
            txtBox.TextChanged += OnTextChanged;
        }


        #region Placeholder

        public static DependencyProperty PlaceholderTextoProperty = 
            DependencyProperty.Register("PlaceholderTexto", typeof(string), typeof(CampoTextoControl),new PropertyMetadata(string.Empty));
          

        public string PlaceholderTexto
        {
            get => GetValue(PlaceholderTextoProperty) as string;
            set => SetValue(PlaceholderTextoProperty, value);
        }

        public static DependencyProperty PlaceholderColorProperty =
            DependencyProperty.Register("PlaceholderColor", typeof(string), typeof(CampoTextoControl), new PropertyMetadata(string.Empty));


        public string PlaceholderColor
        {
            get => GetValue(PlaceholderColorProperty) as string;
            set => SetValue(PlaceholderColorProperty, value);
        }

        #endregion


        public static DependencyProperty TextoProperty =
            DependencyProperty.Register("Texto", typeof(string), typeof(CampoTextoControl), new PropertyMetadata(string.Empty));

        public string Texto
        {
            get => GetValue(TextoProperty) as string;
            set => SetValue(TextoProperty, value);
        }


        public static DependencyProperty FondoProperty =
            DependencyProperty.Register("Fondo", typeof(string), typeof(CampoTextoControl), new PropertyMetadata(string.Empty));

        public string Fondo
        {
            get => GetValue(FondoProperty) as string;
            set => SetValue(FondoProperty, value);
        }


        public static DependencyProperty ColorBordeProperty =
            DependencyProperty.Register("ColorBorde", typeof(string), typeof(CampoTextoControl), new PropertyMetadata(string.Empty));

        public string ColorBorde
        {
            get => GetValue(ColorBordeProperty) as string;
            set => SetValue(ColorBordeProperty, value);
        }


        public static DependencyProperty ColorTextoProperty =
            DependencyProperty.Register("ColorTexto", typeof(string), typeof(CampoTextoControl), new PropertyMetadata(string.Empty));

        public string ColorTexto
        {
            get => GetValue(ColorTextoProperty) as string;
            set => SetValue(ColorTextoProperty, value);
        }


        public static readonly RoutedEvent CambiandoTextoEvent =
            EventManager.RegisterRoutedEvent("CambiandoTexto", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CampoTextoControl));

        public event RoutedEventHandler CambiandoTexto
        {
            add { AddHandler(CambiandoTextoEvent, value); }
            remove { RemoveHandler(CambiandoTextoEvent, value); }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Texto = txtBox.Text;
            RaiseEvent(new RoutedEventArgs(CambiandoTextoEvent));
        }

        public new void Focus()
        {
            txtBox.Focus();
        }

        private void txtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void txtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholder.Visibility = Visibility.Visible;
        }
    }
}
