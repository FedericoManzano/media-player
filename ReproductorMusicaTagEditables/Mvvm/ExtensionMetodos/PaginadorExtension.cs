
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
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
        public static Cancion ElementoRandon(this List<Cancion> lista)
        {
            Random r = new Random();
            return lista[r.Next(0, lista.Count)];
        }
        private static List<Cancion> DameListadoGeneros(string genero)
        {
            InfoReproductor i = InfoReproductor.DameInstancia();
            return i.Canciones.Where(c => c.Genero == genero).ToList();
        }
        public static ObservableCollection<ListaRep> DameListadoGeneros(this Dictionary<string, List<string>> _diccionario, string letra)
        {
            ObservableCollection<ListaRep> ret = new ObservableCollection<ListaRep>();
            foreach (string ln in _diccionario[letra])
            {
                List<Cancion> lista =DameListadoGeneros(ln).Where(cancion => System.IO.File.Exists(cancion.Path)).ToList();
                if (lista != null && lista.Count >= 4)
                {
                    ListaRep r = new ListaRep
                    {
                        Nombre = ln,
                        CantidadCanciones = lista.Count + " Canciones",
                        Duracion = "",
                        Imagen1 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lista.ElementoRandon().Path),
                        Imagen2 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lista.ElementoRandon().Path),
                        Imagen3 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lista.ElementoRandon().Path),
                        Imagen4 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lista.ElementoRandon().Path),
                    };
                    ret.Add(r);
                }
                else
                {
                    ListaRep r = new ListaRep
                    {
                        Nombre = ln,
                        CantidadCanciones = lista.Count + " Canciones",
                        Duracion = "",
                    };
                    ret.Add(r);
                }
            }
            return ret;
        }

        public static ObservableCollection<ListaRep> DameListadoReproduccion(this Dictionary<string, List<string>> _diccionario, string letra)
        {
            ObservableCollection<ListaRep> ret = new ObservableCollection<ListaRep>();
            foreach (string ln in _diccionario[letra])
            {
                List<Cancion> lista = ListasReproduccion.DameListadoCanciones(ln).Where(cancion => System.IO.File.Exists(cancion.Path)).ToList();
                if (lista != null && lista.Count >= 4)
                {
                    ListaRep r = new ListaRep
                    {
                        Nombre = ln,
                        CantidadCanciones = lista.Count + " Canciones",
                        Duracion = "",
                        Imagen1 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lista.ElementoRandon().Path),
                        Imagen2 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lista.ElementoRandon().Path),
                        Imagen3 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lista.ElementoRandon().Path),
                        Imagen4 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lista.ElementoRandon().Path),
                    };
                    ret.Add(r);
                }
                else
                {
                    ListaRep r = new ListaRep
                    {
                        Nombre = ln,
                        CantidadCanciones = lista.Count + " Canciones",
                        Duracion = "",
                    };
                    ret.Add(r);
                }
            }
            return ret;
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
                c.Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(c.Path) ??
                           ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
                ret.Add(c);
            }
            return ret;
        } 
    }
}
