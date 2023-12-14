
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class RegalosViewModel : ReproductorViewModel, IRecolector.IRecolector
    {

       
        private static readonly string[] COLORES =
        {
            "Purple",
            "DarkRed",
            "DarkBlue",
            "DarkMagenta"
        };
        
        private Dictionary<string, List<RegalosRep>> _dicRegalosRep = new Dictionary<string, List<RegalosRep>>();

        private ObservableCollection<RegalosRep> _ListadoRegalosRep = new ObservableCollection<RegalosRep>();
        public ObservableCollection<RegalosRep> ListadoRegalosRep
        {
            get => _ListadoRegalosRep;
            set
            {
                _ListadoRegalosRep = value;
                OnPropertyChanged(nameof(ListadoRegalosRep));
            }
        }

        private Dictionary<string, bool> _paginador = new Dictionary<string, bool>();
        public Dictionary<string, bool> Paginador { get => _paginador; set { _paginador = value; OnPropertyChanged(nameof(Paginador)); } }




        public void CargarRegalos(Dictionary<string, List<Cancion>> dic)
        {
          
            if (!dic.Any())
            {
                return;
            }
            string primerAno = dic.Keys.First().AnoString();
            foreach (var e in dic.Keys)
            {
                string ano = e.AnoString();
                if (_dicRegalosRep.ContainsKey(ano))
                {
                    _dicRegalosRep[ano].Add(GenerarRegalo(dic, e));
                }
                else
                {
                    _dicRegalosRep[ano] = new List<RegalosRep>() { GenerarRegalo(dic, e) };
                }
                Paginador[ano] = false;
            }
            SeleccionarPagina(primerAno);
            
        }


        public void SeleccionarPagina(string ano) 
        {
            ListadoRegalosRep = new ObservableCollection<RegalosRep>(_dicRegalosRep[ano]);
            Paginador = Paginador.DesmarcarTodos();
            Paginador = Paginador.MarcarClave(ano);

        }

        private RegalosRep GenerarRegalo(Dictionary<string,List<Cancion>> dic, string key)
        {
            List<Cancion> listadoCanciones = dic[key];
            if(listadoCanciones != null && listadoCanciones.Any())
            {
                RegalosRep r = new RegalosRep()
                {
                    Nombre = key.DameFormatoVisibleFecha(),
                    Imagen1 = DameImagen(0, listadoCanciones),
                    Imagen2 = DameImagen(1, listadoCanciones),
                    Imagen3 = DameImagen(2, listadoCanciones),
                    Imagen4 = DameImagen(3, listadoCanciones),
                    Color = DameColorRandom()
                };
                return r;
            }
            return new RegalosRep();
        }


        private string DameColorRandom()
        {
            Random r = new Random();
            return COLORES[r.Next(0, COLORES.Length)];
        }

        private ImageBrush DameImagen(int index, List<Cancion> listado)
        {
            if (listado == null)
                return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
            if (index >= listado.Count || index < 0)
                return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
            return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(listado[index].Path);
        }


        public void Limpiar()
        {
            _dicRegalosRep.Clear();
            ListadoRegalosRep.Clear();
            Paginador.Clear();
            System.GC.Collect();
        }
    }
}
