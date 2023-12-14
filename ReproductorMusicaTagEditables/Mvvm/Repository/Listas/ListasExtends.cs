
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.Listas
{
    public static class ListasExtends
    {

        private static readonly string[] MESES =
        {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"
        };



        public static string Ruta(this string nombreLista)
        {
            return ListasReproduccion.PATH_LISTAS + nombreLista + ListasReproduccion.EXT;
        }

        public static string MesString(this string origen)
        {
            if (string.IsNullOrEmpty(origen))
                return "0";
            if (origen.ValidarFormato())
            {
                return origen.Split('-')[0];
            }
            return "0";
        }

        public static string AnoString(this string origen)
        {
            if (string.IsNullOrEmpty(origen))
                return "0";
            if (origen.ValidarFormato())
            {
                return origen.Split('-')[1];
            }
            return "0";
        }

        public static string FormatearNombreDelMes(this string k)
        {
            string mes = k.MesString();
            switch (mes)
            {
                case "1": return MESES[0];
                case "2": return MESES[1];
                case "3": return MESES[2];
                case "4": return MESES[3];
                case "5": return MESES[4];
                case "6": return MESES[5];
                case "7": return MESES[6];
                case "8": return MESES[7];
                case "9": return MESES[8];
                case "10": return MESES[9];
                case "11": return MESES[10];
                case "12": return MESES[11];
                default: return "0";
            }
        }

        public static string ConvertirMesANumero(this string mes)
        {
            switch (mes)
            {
                case "Enero": return "1";
                case "Febrero": return "2";
                case "Marzo": return "3";
                case "Abril": return "4";
                case "Mayo": return "5";
                case "Junio": return "6";
                case "Julio": return "7";
                case "Agosto": return "8";
                case "Septiembre": return "9";
                case "Octubre": return "10";
                case "Noviembre": return "11";
                case "Diciembre": return "12";
                default: return "0";
            }
        }

        public static string DameConFormatoFecha(this string nombre)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                if (Regex.IsMatch(nombre, "^([A-Za-z]+ {1}[0-9]{4})$"))
                {
                    string mes = nombre.Split(' ')[0];
                    string ano = nombre.Split(' ')[1];
                    mes = mes.ConvertirMesANumero();
                    return mes + "-" + ano;
                }
                return nombre;
            }
            return nombre;
        }

        public static string ConvertirFecha(this Cancion c)
        {
            int ano = c.UltimaReproduccion.Year;
            int mes = c.UltimaReproduccion.Month;
            return mes + "-" + ano;
        }

        public static string DameFormatoVisibleFecha(this string fecha)
        {
            return fecha.FormatearNombreDelMes() + " " + fecha.AnoString();
        }

        public static bool EsUnRegalo(this string origen)
        {
            return Regex.IsMatch(origen, "^([0-9]{1,2}-[0-9]{4})$");
        }

        public static List<Cancion> OrdenarPorCantidadDecreciente(this List<Cancion> origen)
        {
            origen.Sort(delegate (Cancion c1, Cancion c2) {
                return c2.Cantidad.CompareTo(c1.Cantidad);
            });
            return origen;
        }

        public static bool ValidarFormato(this string origen)
        {
            return Regex.IsMatch(origen, "^([0-9]{1,2}-[0-9]{4})$");
        }
    }
}
