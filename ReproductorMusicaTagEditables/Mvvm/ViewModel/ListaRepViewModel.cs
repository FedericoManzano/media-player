using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Controls.ListaAvatar;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ListaRepViewModel:ReproductorViewModelBase , IRecolector.IRecolector
    {
        private ListaRep _listaRep = new ListaRep();
        public ListaRep ListaRep { get => _listaRep; set { _listaRep = value; OnPropertyChanged(nameof(ListaRep)); } }

        private string _fechaCreacion = "";
        public string FechaCreacion 
        { 
            get => _fechaCreacion; 
            set { _fechaCreacion = value; OnPropertyChanged(nameof(FechaCreacion)); } 
        }



        public ICommand PlayCommandLista { get; }
       

        public ListaRepViewModel ()
        {
            PlayCommandLista = new RelayCommand(PlayActionLista, CanPlayAction);
        }



        public async void CargarInfoLista(ListaAvatarControl listaAvatarControl)
        {
            ListaRep = await CrearInfoListaRep(listaAvatarControl);
            FechaCreacion = ListasReproduccion.FechaCreacion(ListaRep.Nombre);
            Irg.Presentacion = new ObservableCollection<Cancion>(DameListaPorPartes(ListaRep.Nombre,0,10));
            Irg.Presentacion = new ObservableCollection<Cancion>(await ListadoCancionesFiltrado());
        }

          
        private List<Cancion> DameListaPorPartes(string nombre, int inicio, int final)
        {
            List<Cancion> l = ListasReproduccion.DameListadoCanciones(nombre);
            return l.Count > final-inicio ? l.GetRange(inicio,final):l;
        }
        private async Task<List<Cancion>> CargarListadoCanciones()
        {
            List<Cancion> cancions = await Task.Run(() => Irg.Presentacion.Select(c => c.Clone()).ToList());
            return cancions;
        }

        private async Task<List<Cancion>> ListadoCancionesFiltrado()
        {
            return await Task.Run(() =>
            {
                return Irg.Presentacion.Select(c =>
                {
                    if (c.Titulo == Irg.CancionActual.Cancion.Titulo
                    && c.Artista == Irg.CancionActual.Cancion.Artista
                    && c.Album == Irg.CancionActual.Cancion.Album)
                    {
                        return Irg.CancionActual.Cancion.Clone();
                    }
                    return c;
                }).ToList();
            });
        }

        private async Task<ListaRep> CrearInfoListaRep(ListaAvatarControl listaAvatarControl)
        {
            var context = TaskScheduler.FromCurrentSynchronizationContext();
            ListaRep r = await Task.Factory.StartNew(() =>
            {
                return new ListaRep
                {
                    Nombre = listaAvatarControl.Nombre,
                    CantidadCanciones = listaAvatarControl.Cantidad,
                    Duracion = ListasReproduccion.CalcularDuracionLista(listaAvatarControl.Nombre),
                    Imagen1 = listaAvatarControl.ImagenUno,
                    Imagen2 = listaAvatarControl.ImagenDos,
                    Imagen3 = listaAvatarControl.ImagenTres,
                    Imagen4 = listaAvatarControl.ImagenCuatro,
                };
            }, CancellationToken.None, TaskCreationOptions.None, context);
            return r;
        }

        private bool CanPlayAction(object arg)
        {
            return true;
        }

        private  void PlayActionLista(object obj)
        {
            Irg.Deseleccionar();
            Irg.CancionesFiltradas = new ObservableCollection<Cancion>(ListasReproduccion.DameListadoCanciones(ListaRep.Nombre));
            if (obj == null)
            {
                Irg.CancionActual.Index = 0;
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION)
                        .Ejecutar(irg, Irg.CancionesFiltradas[0]);
            } else
            {
                Cancion c = (Cancion)obj;
                int index = Irg.CancionesFiltradas.IndexOf(c);
               
                Irg.CancionActual.Index = index;
                Irg.CancionActual.Cancion = c;
              

                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION)
                        .Ejecutar(irg, Irg.CancionActual.Cancion);
            }
        }

        public void ActualizarFiltro ()
        {
            List<Cancion> l = ListasReproduccion.DameListadoCanciones(ListaRep.Nombre);
            int diferencia = l.Count - Irg.Presentacion.Count;
            if (diferencia <= 0)
                return;

            if (diferencia > 20 && Irg.Presentacion.Count < l.Count)
            {
                foreach (Cancion can in l.ToList().GetRange(Irg.Presentacion.Count, 20))
                {
                    Irg.Presentacion.Add(can);
                }
            }
            else
            {
                for (int i = Irg.Presentacion.Count; i < l.Count; i++)
                {
                    Irg.Presentacion.Add(l[i]);
                }
            }
            Irg.Seleccionar();
        }

        public void Limpiar()
        {
           ListaRep = new ListaRep();
           Irg.Presentacion = new ObservableCollection<Cancion>();
           System.GC.Collect();   
        }
    }
}
