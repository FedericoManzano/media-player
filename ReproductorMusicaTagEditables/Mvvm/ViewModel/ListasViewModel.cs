using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ListasViewModel:ReproductorViewModel
    {

        private Dictionary<string, List<ListaRep>> _diccionarioLista = new Dictionary<string, List<ListaRep>>();
        private Dictionary<string, bool> _paginador = new Dictionary<string, bool>();

        public Dictionary<string, bool> Paginador 
        { 
            get => _paginador;
            set { _paginador = value; OnPropertyChanged(nameof(Paginador)); } 
        }

        

        private ObservableCollection<ListaRep> _listas = new ObservableCollection<ListaRep>();

        public ObservableCollection<ListaRep> Listas
        { 
            get => _listas;
            set { _listas = value; OnPropertyChanged(nameof(Listas)); } 
        }



        public void CargarListasReproduccion()
        {
            List<string> listasNombre = ListasReproduccion.ListadoNombres();

            foreach (var item in listasNombre)
            {
                if(!_diccionarioLista.ContainsKey(item.PrimeraLetraMayuscula()))
                {
                    _diccionarioLista[item.PrimeraLetraMayuscula()] = new List<ListaRep>();
                }
           
                _diccionarioLista[item.PrimeraLetraMayuscula()].Add(new ListaRep
                {
                    Nombre = item,
                    CantidadCanciones = ListasReproduccion.DameListadoCanciones(item).Count.ToString(),
                    Duracion = ""
                });

                Paginador[item.PrimeraLetraMayuscula()] = false;
            }

            if (_diccionarioLista.Count > 0)
            {
                Paginador = Paginador.OrdenarPorClave();
                Paginador = Paginador.MarcarClave(Paginador.Keys.First());
                
                foreach(ListaRep r in _diccionarioLista[Paginador.Keys.First()])
                {
                    List<Cancion> l = ListasReproduccion.DameListadoCanciones(r.Nombre);
                    if(l.Count >= 4) 
                    {
                    
                        r.Imagen1 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[0].Path);
                        r.Imagen2 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[1].Path);
                        r.Imagen3 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[2].Path);
                        r.Imagen4 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[3].Path);
                    } else if(l.Count == 3) 
                    {
                        r.Imagen1 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[0].Path);
                        r.Imagen2 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[1].Path);
                        r.Imagen3 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[2].Path);
                    } else if(l.Count == 2)
                    {
                        r.Imagen1 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[0].Path);
                        r.Imagen2 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[1].Path);

                    } else if(l.Count == 1)
                    {
                        r.Imagen1 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[0].Path);
                    }
                    Listas.Add(r);
                }
            }
        }
    }
}
