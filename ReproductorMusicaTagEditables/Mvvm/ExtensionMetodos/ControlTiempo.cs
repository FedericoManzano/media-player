using System;
using System.Windows.Controls;

namespace ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos
{
    public static class ControlTiempo
    {
        public static TimeSpan RestarSegundos (this TimeSpan origen, int segundos)
        {
            return origen.Subtract(new TimeSpan(0,0,segundos));
        }

        public static string TiempoFormato(this TimeSpan origen)
        {
            return origen.ToString(@"hh\:mm\:ss");
        }

        public static TimeSpan TiempoTotalPista (this MediaElement origen)
        {
            return origen.NaturalDuration.TimeSpan;
        }

        public static bool TieneTimeSpan(this MediaElement origen)
        {
            return origen.NaturalDuration.HasTimeSpan;
        }

        public static double TotalSegundos(this TimeSpan origen)
        {
            return origen.TotalSeconds;
        }
    }
}
