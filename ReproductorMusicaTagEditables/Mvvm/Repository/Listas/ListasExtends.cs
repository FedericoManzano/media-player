
namespace ReproductorMusicaTagEditables.Mvvm.Repository.Listas
{
    public static class ListasExtends
    {
        public static string Ruta(this string nombreLista)
        {
            return ListasReproduccion.PATH_LISTAS + nombreLista + ListasReproduccion.EXT;
        }
    }
}
