using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Filtros;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TagLib.Ogg;


namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class TodosLosGenerosViewModel: ReproductorViewModelBase
    {
        private readonly PaginadorAvanzado _paginadorAvanzado = new PaginadorAvanzado();

        public PaginadorAvanzado PaginadorAvanzado => _paginadorAvanzado;

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
