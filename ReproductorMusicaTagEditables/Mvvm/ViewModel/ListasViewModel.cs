using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Filtros;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ListasViewModel:ReproductorViewModel, IRecolector.IRecolector 
    {

        private readonly PaginadorAvanzado _paginadorAvanzado = new PaginadorAvanzado();

        public PaginadorAvanzado PaginadorAvanzado => _paginadorAvanzado;


        public ICommand PlayCommandLista { get; }


        public ListasViewModel() {
            PlayCommandLista = new RelayCommand(PlayCommandListaAction);
        }

        private void PlayCommandListaAction(object obj)
        {
            if (obj == null) return;

            string nombreLista = (string) obj;
            List<Cancion> listaCanciones = ListasReproduccion.DameListadoCanciones(nombreLista);
            if(listaCanciones != null && listaCanciones.Any())
            {
                Irg.CancionesFiltradas = new ObservableCollection<Cancion>(listaCanciones);
                Irg.Deseleccionar();
                if (EstadosControl.RANDOM)
                {
                    Irg.CancionActual.Index = Irg.CancionesFiltradas.IndexRan();
                    Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                }
                else
                {
                    Irg.CancionActual.Index = 0;
                    Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                }

                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(Irg, Irg.CancionActual.Cancion);
                Historial.AgregarAHistorialListas(nombreLista);
            }
        }

        public void CargarListasReproduccion()
        {
            Irg.BtnNavegacion = false;
            Irg.IsMensajeVisible = System.Windows.Visibility.Visible;
            
            List<string> listasNombre = ListasReproduccion.ListadoNombres();
            PaginadorAvanzado.CrearDiccionarioDeRecursos(listasNombre, PaginadorAvanzado.LISTA_REPRODUCCION);

            if(PaginadorAvanzado.Tamano() > 0 )
                Irg.IsMensajeVisible = System.Windows.Visibility.Collapsed;
            Irg.BtnNavegacion = true;

            
        }

        public void ActualizarListas(string letra)
        {
            Irg.BtnNavegacion = false;
            PaginadorAvanzado.ActualizarListasReproduccion(letra);
            Irg.BtnNavegacion = true;
        }

        public void Limpiar()
        {
            PaginadorAvanzado.Limpiar();   
        }
    }
}
