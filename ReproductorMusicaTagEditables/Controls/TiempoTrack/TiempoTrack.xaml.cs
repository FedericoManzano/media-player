
using System.Windows;
using System.Windows.Controls;

namespace ReproductorMusicaTagEditables.Controls.TiempoTrack
{
    public partial class TiempoTrack : UserControl
    {
        public TiempoTrack()
        {
            InitializeComponent();
        }

        public static DependencyProperty TiempoTranscurridoProperty =
            DependencyProperty.Register("TiempoTranscurrido", typeof(string), typeof(TiempoTrack), new PropertyMetadata("00:00:00"));
 
        public string TiempoTranscurrido
        {
            get => GetValue(TiempoTranscurridoProperty) as string; 
            set => SetValue(TiempoTranscurridoProperty, value);
        }

        public static DependencyProperty TiempoFaltanteProperty =
            DependencyProperty.Register("TiempoFaltante", typeof(string), typeof(TiempoTrack), new PropertyMetadata("00:00:00"));

        public string TiempoFaltante
        {
            get => GetValue(TiempoFaltanteProperty) as string;
            set => SetValue(TiempoFaltanteProperty, value);
        }
    }
}
