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

namespace ReproductorMusicaTagEditables.Controls.Paginador
{
    /// <summary>
    /// Lógica de interacción para BotonPaginador.xaml
    /// </summary>
    public partial class BotonPaginador : UserControl
    {
        public BotonPaginador()
        {
            InitializeComponent();
        }

        public static DependencyProperty InicialProperty =
            DependencyProperty.Register("Inicial", typeof(string), typeof(BotonPaginador), new PropertyMetadata(string.Empty));

        public string Inicial
        {
            get => (string)GetValue(InicialProperty);
            set => SetValue(InicialProperty, value);
        }


        public static DependencyProperty MarcadoProperty =
           DependencyProperty.Register("Marcado", typeof(bool), typeof(BotonPaginador), new PropertyMetadata(false));

        public bool Marcado
        {
            get => (bool)GetValue(MarcadoProperty);
            set => SetValue(MarcadoProperty, value);
        }


        public static RoutedEvent DarClickEvent =
            EventManager.RegisterRoutedEvent("DarClick", RoutingStrategy.Bubble, typeof(EventHandler), typeof(BotonPaginador));
        
        public event EventHandler DarClick
        {
            add { AddHandler(DarClickEvent, value); }
            remove { RemoveHandler(DarClickEvent, value);}
        }

        public void OnDarClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DarClickEvent));
        }
    }
}
