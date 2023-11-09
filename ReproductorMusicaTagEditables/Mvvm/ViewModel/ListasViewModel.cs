using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ListasViewModel:ReproductorViewModel
    {

        private Dictionary<string, List<string>> _diccionarioLista = new Dictionary<string, List<string>>();
        private Dictionary<string, bool> _paginador = new Dictionary<string, bool>();

        public Dictionary<string, bool> Paginador 
        { 
            get => _paginador;
            set { _paginador = value; OnPropertyChanged(nameof(Paginador)); } 
        }

        public static ObservableCollection<ListaRep> _listas = new ObservableCollection<ListaRep>();

        public ObservableCollection<ListaRep> Listas
        { 
            get => _listas;
            set { _listas = value; OnPropertyChanged(nameof(Listas)); } 
        }



        public void CargarListasReproduccion()
        {
            Listas.Clear();
            _diccionarioLista.Clear();
            List<string> listasNombre = ListasReproduccion.ListadoNombres();

            foreach (var item in listasNombre)
            {

                if (!_diccionarioLista.ContainsKey(item.PrimeraLetraMayuscula()))
                {
                    _diccionarioLista[item.PrimeraLetraMayuscula()] = new List<string>();
                }

                _diccionarioLista[item.PrimeraLetraMayuscula()].Add(item);

                Paginador[item.PrimeraLetraMayuscula()] = false;
            }

            if (_diccionarioLista.Count > 0)
            {
                Paginador = Paginador.OrdenarPorClave();
                Paginador = Paginador.MarcarClave(Paginador.Keys.First());
                Listas = _diccionarioLista.DameListadoReproduccion(Paginador.Keys.First());
            }
        }

        public void ActualizarListas(string letra)
        {
            Paginador.DesmarcarTodos();
            Paginador = Paginador.MarcarClave(letra);
            Listas = _diccionarioLista.DameListadoReproduccion(letra);
        }


       
    }
}
