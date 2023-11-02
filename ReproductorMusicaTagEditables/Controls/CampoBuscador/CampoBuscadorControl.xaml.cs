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

namespace ReproductorMusicaTagEditables.Controls.CampoBuscador
{
    /// <summary>
    /// Lógica de interacción para CampoBuscadorControl.xaml
    /// </summary>
    public partial class CampoBuscadorControl : UserControl
    {
        public CampoBuscadorControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty TextoProperty =
            DependencyProperty.Register("Texto", typeof(string), typeof(CampoBuscadorControl), new PropertyMetadata(string.Empty));

        public string Texto
        {
            get => (string)GetValue(TextoProperty);
            set => SetValue(TextoProperty, value);
        }


        public static RoutedEvent CambioCampoEvent =
            EventManager.RegisterRoutedEvent("TextChange", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CampoBuscadorControl));

        public event RoutedEventHandler TextChange
        {
            add { AddHandler(CambioCampoEvent, value); }
            remove { RemoveHandler(CambioCampoEvent, value); }
        }

        public void OnTextChange(object sender, RoutedEventArgs e)
        {
            Texto = txtSearch.Text;
            RaiseEvent(new RoutedEventArgs(CambioCampoEvent));
        }

        public new void Focus()
        {
            txtSearch.Focus();
        }
    }
}
