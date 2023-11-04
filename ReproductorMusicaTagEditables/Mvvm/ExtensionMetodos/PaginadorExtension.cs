
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos
{
    public static class PaginadorExtension
    {
        public static Dictionary<string,bool> OrdenarPorClave(this Dictionary<string,bool> origen)
        {
            return new Dictionary<string, bool>(new SortedDictionary<string, bool>(origen));
        }

        public static Dictionary<string,bool> MarcarClave(this Dictionary<string,bool> origen, string key)
        {
            origen[key] = true;
            return new Dictionary<string, bool>(origen);
        }


        public static Dictionary<string, bool> DesmarcarTodos(this Dictionary<string, bool> origen)
        {
            string[] k = origen.Keys.ToArray();
            foreach (var e in k)
            {
                origen[e] = false;
            }
            return new Dictionary<string, bool>(origen);
        }

        public static ObservableCollection<Cancion> CargarImagenes (this Dictionary<string,Dictionary<string,Cancion>> origen, string key)
        {
            ObservableCollection<Cancion> ret = new ObservableCollection<Cancion> ();
            List<Cancion> listValores = new List<Cancion> (origen[key].Values.ToList());
            for(int i = 0; i < listValores.Count; i ++)
            {
                Cancion c = new Cancion( listValores[i] );
                c.Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(c.Path);
                ret.Add(c);
            }
            return ret;
        } 
    }
}
