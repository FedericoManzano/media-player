using ReproductorMusicaTagEditables.Controls.ListaAvatar;
using ReproductorMusicaTagEditables.Mvvm.View.Pages;
using ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas;
using System.Windows.Controls;

namespace ReproductorMusicaTagEditables.Mvvm.View.Generador
{
    public class FabricaPage
    {
        public static readonly int TODAS_LAS_CANCIONES = 0;
        public static readonly int TODOS_LOS_ARTISTAS = 1;
        public static readonly int TODAS_LOS_ALBUMES = 2;
        public static readonly int TODAS_LAS_LISTAS = 3;
        public static readonly int TODOS_LOS_GENEROS = 4;
        public static readonly int INFO_ARTISTA_PAGE = 5;
        public static readonly int INFO_ALBUM_PAGE = 6;
        public static readonly int INFO_LISTA_REP = 7;
        public static readonly int DESCARGAS_PAGE = 8;
        private FabricaPage() { }

        private static FabricaPage _ins = null;


        public static FabricaPage DameInstancia()
        {
            if(_ins == null )
                _ins = new FabricaPage();
            return _ins;
        }

        public static Page DamePagina(int codPagina, object parametro = null)
        {
            if(codPagina == INFO_ARTISTA_PAGE)
            {
                string p = (string)parametro;
                return new InfoArtistaPage(p);
            }
            if (codPagina == INFO_ALBUM_PAGE)
            {
                string p = (string)parametro;
                return new InfoAlbumPage(p);
            }
            if(codPagina == TODAS_LAS_CANCIONES)
            {
                return new TodasLasCanciones();
            }
            if(codPagina == TODAS_LOS_ALBUMES)
            {
                return new TodosLosAlbumes();
            }
            if (codPagina == TODOS_LOS_ARTISTAS)
            {
                return new TodosLosArtistas();
            }
            if (codPagina == TODAS_LAS_LISTAS)
            {
                return new ListasPage();
            }
            if (codPagina == TODOS_LOS_GENEROS)
            {
                return new TodosLosGeneros();
            }
            if (codPagina == DESCARGAS_PAGE)
            {
                return new DescargasPage();
            }
            if (codPagina == INFO_LISTA_REP)
            {
                ListaAvatarControl p = (ListaAvatarControl)parametro;
                return new InfoListasPage(p);
            }

            return null;
        }

    }
}
