using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Linq;


namespace ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos
{
    public static class FormatoCampos
    {
        public static string Longitud(this string origen, int longitud)
        {
            if (string.IsNullOrEmpty(origen))
                return origen;
            return origen.Length > longitud ? origen.Substring(0, longitud) + "..." : origen;
        }

        public static string PrimeraLetraMayuscula(this string origen)
        {
            if(string.IsNullOrEmpty(origen))
                return origen;
            return origen.First().ToString().ToUpper();
        }
    }
}
