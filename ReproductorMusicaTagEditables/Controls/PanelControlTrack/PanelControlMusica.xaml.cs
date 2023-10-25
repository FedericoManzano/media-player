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

namespace ReproductorMusicaTagEditables.Controls.PanelControlTrack
{
    
    public partial class PanelControlMusica : UserControl
    {
        public bool visibilidadSliderVolumen = false;
        
        public PanelControlMusica()
        {
            InitializeComponent();
        }


        #region EventoAnterior Definición
        public static readonly RoutedEvent AnteriorEvent = 
            EventManager.RegisterRoutedEvent("AnteriorClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelControlMusica));  


        public event RoutedEventHandler AnteriorClick
        {
            add => AddHandler(AnteriorEvent,value);
            remove => RemoveHandler(AnteriorEvent,value);
        }

        public void OnClickAnterior (object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AnteriorEvent));
        }
        #endregion


        #region EventoSiguiente Definición
        public static readonly RoutedEvent SiguienteEvent =
           EventManager.RegisterRoutedEvent("SiguienteClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelControlMusica));


        public event RoutedEventHandler SiguienteClick
        {
            add => AddHandler(SiguienteEvent, value);
            remove => RemoveHandler(SiguienteEvent, value);
        }
        

        public void OnClickSiguiente(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SiguienteEvent));
        }
        #endregion


        #region EventoPlay Definición
        public static readonly RoutedEvent PlayEvent =
           EventManager.RegisterRoutedEvent("PlayClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelControlMusica));
        public event RoutedEventHandler PlayClick
        {
            add => AddHandler(PlayEvent, value);
            remove => RemoveHandler(PlayEvent, value);
        }

        public void OnClickPlay(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(PlayEvent));
        }
        #endregion


        private void Mostrar_Slider_Volumen(object sender, RoutedEventArgs e)
        {
            if(contenedorVolumen.Visibility == Visibility.Visible)
            {
                contenedorVolumen.Visibility = Visibility.Collapsed;
                btnVolumen.Foreground = Brushes.White;
            }
            else
            {
                contenedorVolumen.Visibility = Visibility.Visible;
                btnVolumen.Foreground = Brushes.Orange;
            }
        }
    }
}
