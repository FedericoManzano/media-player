using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos
{
    public static class FormatoCampos
    {
        public static string Longitud(this string origen, int longitud)
        {
            return origen.Length > longitud ? origen.Substring(0, longitud) + "..." : origen;
        }

        public static string PrimeraLetraMayuscula(this string origen)
        {
            return origen.First().ToString().ToUpper();
        }
    }
}
