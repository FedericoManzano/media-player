using ControlTiempoMultimedia.MetodosExtendidos;
using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class InfoGeneroViewModel:ReproductorViewModelBase, IRecolector.IRecolector
    {
        private ListaRep _infoGenero = new ListaRep();

        public ListaRep InfoGenero { get => _infoGenero; set { _infoGenero = value; OnPropertyChanged(nameof(InfoGenero)); } }
      
        public ICommand PlayCommandGenero { get; }

        public InfoGeneroViewModel() 
        {
            PlayCommandGenero = new RelayCommand(DarPlayGenero);
        }

        private async void DarPlayGenero(object obj)
        {
            Irg.Deseleccionar();
            Irg.CancionesFiltradas = new ObservableCollection<Cancion>(await DameTodasCancionesDelGenero(InfoGenero.Nombre));
            if (obj == null)
            {
                Irg.CancionActual.Index = 0;
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION)
                        .Ejecutar(irg, Irg.CancionesFiltradas[0]);
                Historial.AgregarAHistorialAlbumes(GenerarAlbum(Irg.CancionesFiltradas[0]));
            }
            else
            {
                Cancion c = (Cancion)obj;
                int index = Irg.CancionesFiltradas.IndexOf(c);

                Irg.CancionActual.Index = index;
                Irg.CancionActual.Cancion = c;


                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION)
                        .Ejecutar(irg, Irg.CancionActual.Cancion);
                Historial.AgregarAHistorialAlbumes(GenerarAlbum(Irg.CancionActual.Cancion));
            }
        }

        private async Task<List<Cancion>> DameTodasCancionesDelGenero(string genero)
        {
            return await Task.Run(() => Irg.Canciones.Where(c => c.Genero == genero).ToList());
        }
        private async  Task<List<Cancion>> DameCancionesDelGenero(string genero)
        {
            List<Cancion> l = await Task.Run(() => Irg.Canciones.Where(c => c.Genero == genero).ToList());
            if(l.Count > 10)
                return l.GetRange(0,10);
            else
                return l;
        }

        public async void CargarInfoGenero(string genero) 
        {
            Irg.BtnNavegacion = false;
            InfoGenero = await CargarInfoGeneroAsync(genero);
        }

        public async Task<ListaRep> CargarInfoGeneroAsync (string genero) 
        {
            
            Irg.Presentacion = new ObservableCollection<Cancion> (await DameCancionesDelGenero(genero));
            
            List<Cancion> l = await DameTodasCancionesDelGenero(genero);

            
            var context = TaskScheduler.FromCurrentSynchronizationContext();
            ListaRep r = await Task.Factory.StartNew(() =>
            {
                ListaRep rp = new ListaRep
                {
                    Nombre = genero,
                    CantidadCanciones = DameCantidadCanciones(genero) + " Canciones",
                    Duracion = DameDuracionString(genero),
                    Imagen1 = DameImagenNumero(l,l.IndexRan()),
                    Imagen2 = DameImagenNumero(l,l.IndexRan()),
                    Imagen3 = DameImagenNumero(l,l.IndexRan()),
                    Imagen4 = DameImagenNumero(l,l.IndexRan()),
                };
                Irg.BtnNavegacion = true;
                return rp;
            }, CancellationToken.None, TaskCreationOptions.None, context);
            return r;
        }

        private ImageBrush DameImagenNumero (List<Cancion> l, int numero)
        {
            if(numero < l.Count)
            {
                return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[numero].Path);
            }
            return null;
        }

        private string DameDuracionString (string genero)
        {
            ulong? tiempo = 0;
            foreach (var c in Irg.Canciones)
            {
                if(c.Genero == genero)
                    tiempo += c.DuracionLong;
            }
            return ((long)tiempo).DuracionLongAStringConDescripcion();
        }

        private string DameCantidadCanciones(string genero)
        {
            return Irg.Canciones.Where(c=>c.Genero == genero).ToList().Count.ToString();
        }

        public void ActualizarFiltro()
        {
            List<Cancion> l = Irg.Canciones.Where(c => c.Genero == InfoGenero.Nombre).ToList();
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
            Irg.Presentacion.Clear();
            InfoGenero = new ListaRep();
            System.GC.Collect();
        }
    }
}
