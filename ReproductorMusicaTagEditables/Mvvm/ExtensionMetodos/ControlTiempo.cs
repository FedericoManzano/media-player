using Microsoft.WindowsAPICodePack.Shell;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            if (origen.NaturalDuration.HasTimeSpan)
            {
                return origen.NaturalDuration.TimeSpan;
            }
            return new TimeSpan();
        }

        public static bool TieneTimeSpan(this MediaElement origen)
        {
            return origen.NaturalDuration.HasTimeSpan;
        }

        public static double TotalSegundos(this TimeSpan origen)
        {
            return origen.TotalSeconds;
        }

        public static ulong? DuracionLong (this Cancion cancion, string path)
        {
            if (!System.IO.File.Exists(path))
            {
                return 0;
            }
            FileInfo fi = new FileInfo(path);
            ShellObject shellObj = ShellObject.FromParsingName(fi.FullName);
            ulong? du = shellObj.Properties.System.Media.Duration.Value;
            return du;
        }

        public static string DuracionString(this ulong? timeLong, string formato)
        {
            if (timeLong == null || timeLong <= 0)
                return "00:00:00";
            TimeSpan ts = TimeSpan.FromTicks((long)timeLong.GetValueOrDefault(0UL));
            if(ts.Days > 0)
            {
                return ts.ToString(@"dd\:hh\:mm\:ss") + " Días";
            } 
            if(ts.Hours > 0)
            {
                return ts.ToString(@"hh\:mm\:ss") + " Horas";
            }
            if(ts.Minutes > 0)
            {
                return ts.ToString(@"mm\:ss") + " Minutos";
            }
            if (ts.Seconds > 0)
            {
                return ts.ToString(@"ss") + " Segundos";
            }
            return "00:00:00";
        }

        public static string DuracionString(this List<Cancion> cancions)
        {
            if (cancions == null || cancions.Count == 0)
                return "00:00:00";
            ulong? res = 0;
            foreach(var c in cancions)
            {
                res += c.DuracionLong;
            }

            return res.DuracionString(@"hh\:mm\:ss");
        }

        public static string DuracionString(this ObservableCollection<Cancion> cancions)
        {
            if (cancions == null || cancions.Count == 0)
                return "00:00:00";
            ulong? res = 0;
            foreach (var c in cancions)
            {
                res += c.DuracionLong;
            }
            return res.DuracionString(@"hh\:mm\:ss");
        }

        public static ulong? DuracionAlbum (this Cancion cancion)
        {
            
            if (File.Exists(cancion.Path))
            {
                InfoReproductor irg = InfoReproductor.DameInstancia();
                ulong? res = 0;
                foreach(var c in irg.Canciones) 
                {
                    if(cancion.Album == c.Album)
                    {
                        res += c.DuracionLong;
                    }
                
                }
                return res;
            }
            return 0;
        }

    }
}
