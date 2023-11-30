using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Filtros
{
    public class PaginadorAvanzado : ViewModelBase, IRecolector.IRecolector
    {
        public static readonly int LISTA_GENEROS = 0;
        public static readonly int LISTA_REPRODUCCION = 1;
        
        private Dictionary<string, List<string>> _diccionarioLista = new Dictionary<string, List<string>>();
        private Dictionary<string, bool> _paginador = new Dictionary<string, bool>();

        public Dictionary<string, bool> Paginador
        {
            get => _paginador;
            set { _paginador = value;OnPropertyChanged(nameof(Paginador)); }
        }

        public static ObservableCollection<ListaRep> _listas = new ObservableCollection<ListaRep>();

        public ObservableCollection<ListaRep> Listas
        {
            get => _listas;
            set { _listas = value; OnPropertyChanged(nameof(Listas)); }
        }

        public void CrearDiccionarioDeRecursos(List<string> listadoNombres, int tipoListado)
        {
            Listas.Clear();
            _diccionarioLista.Clear();

            foreach (var item in listadoNombres)
            {
                if (!_diccionarioLista.ContainsKey(item.PrimeraLetraMayuscula()))
                {
                    _diccionarioLista[item.PrimeraLetraMayuscula()] = new List<string>();
                }

                _diccionarioLista[item.PrimeraLetraMayuscula()].Add(item);

                Paginador[item.PrimeraLetraMayuscula()] = false;
            }
            if(tipoListado == LISTA_GENEROS)
            {
                if (_diccionarioLista.Count > 0)
                {
                    ActualizarListasGeneros(Paginador.Keys.First());
                }
            } else
            {
                if(_diccionarioLista.Count > 0)
                {
                    ActualizarListasReproduccion(Paginador.Keys.First());
                }
            }
        }
        
        public void ActualizarListasGeneros(string letra)
        {
            Paginador.DesmarcarTodos();
            Paginador = Paginador.MarcarClave(letra);
            Listas = _diccionarioLista.DameListadoGeneros(letra);
        }

        public void ActualizarListasReproduccion(string letra)
        {
            Paginador.DesmarcarTodos();
            Paginador = Paginador.MarcarClave(letra);
            Listas = _diccionarioLista.DameListadoReproduccion(letra);
        }

        public int Tamano ()
        {
            return _diccionarioLista.Count;
        }

        public void Limpiar()
        {
            _diccionarioLista.Clear();
            Listas.Clear();
            Paginador.Clear();
            System.GC.Collect();
        }
    }
}
