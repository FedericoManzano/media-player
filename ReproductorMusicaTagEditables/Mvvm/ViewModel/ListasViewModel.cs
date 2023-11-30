using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Filtros;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ListasViewModel:ReproductorViewModel, IRecolector.IRecolector 
    {

        private readonly PaginadorAvanzado _paginadorAvanzado = new PaginadorAvanzado();

        public PaginadorAvanzado PaginadorAvanzado => _paginadorAvanzado;

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
