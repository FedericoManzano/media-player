using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Filtros;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TagLib.Ogg;


namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class TodosLosGenerosViewModel: ReproductorViewModelBase
    {
        private readonly PaginadorAvanzado _paginadorAvanzado = new PaginadorAvanzado();

        public PaginadorAvanzado PaginadorAvanzado => _paginadorAvanzado;


        public ICommand PlayCommandGenero { get; }


        public TodosLosGenerosViewModel()
        {
            PlayCommandGenero = new RelayCommand(PlayActionGenero);
        }

        private void PlayActionGenero(object obj)
        { 
            if (obj == null) return;

            string genero = (string)obj;

            List<Cancion> lgeneros = irg.Canciones.Where(c => c.Genero == genero).ToList();

            if (lgeneros.Any())
            {
                Irg.CancionesFiltradas = new ObservableCollection<Cancion>(lgeneros);
                Irg.Deseleccionar();
                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(Irg, Irg.CancionesFiltradas[0]);
                Historial.AgregarAHistorialAlbumes(GenerarAlbum(Irg.CancionesFiltradas[0]));
            }

        }

        private List<string> ListadoDeGeneros ()
        {
            List<Cancion> listado = Irg.Canciones;
            return new SortedSet<string>
            (
                listado.Select(c => c.Genero).ToList()
            ).ToList();
        }

        public void CargarListasReproduccion()
        {
            Irg.IsMensajeVisible = System.Windows.Visibility.Visible;
            List<string> listasNombre = ListadoDeGeneros();
            PaginadorAvanzado.CrearDiccionarioDeRecursos(listasNombre, PaginadorAvanzado.LISTA_GENEROS);
            

            if (PaginadorAvanzado.Tamano() > 0)
                Irg.IsMensajeVisible = System.Windows.Visibility.Collapsed;
        }

        public void ActualizarListas(string letra)
        {
            PaginadorAvanzado.ActualizarListasGeneros(letra);
        }

        public void Limpiar()
        {
            PaginadorAvanzado.Limpiar();
        }
    }
}
