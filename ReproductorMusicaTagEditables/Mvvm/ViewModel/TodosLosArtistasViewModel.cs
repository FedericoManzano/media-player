using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class TodosLosArtistasViewModel:ReproductorViewModelBase
    {
        public List<Cancion> _artistas;

        public List<Cancion> Avatars 
        { 
            get => _artistas;
            set
            {
                _artistas = value;
                OnPropertyChanged(nameof(Avatars));

            }
        }

        public TodosLosArtistasViewModel() { 
            Avatars = new List<Cancion>();
        }

        public async void CargarListaDeAvataresArtistas()
        {
            Avatars = await CargarAvatares();
                

            Avatars = Avatars.Select(a =>
            {
                a.Imagen = ArchivoImagenBase.archivoImagenFabrica(
                    ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(a.Path);
                return a;
            }).ToList();
        }

        public async void BuscarPorNombre(string artista)
        {
            if(!string.IsNullOrWhiteSpace(artista))
            {
                Avatars = await Task<List<AvatarArtista>>.Run(() =>
                {
                    return Avatars.Where(a =>
                    {
                        return a.Artista.ToUpper().Contains(artista.ToUpper());
                    }).ToList();
                });
            }
            else
            {
                CargarListaDeAvataresArtistas();
            }
            
        }

        private async Task<List<Cancion>> CargarAvatares ()
        {
            Dictionary<string, Cancion> d = new Dictionary<string, Cancion> ();

            await Task.Run(() =>
            {
                foreach (var c in Irg.Canciones)
                {
                    d[c.Artista] = c;
                }
            });

            return d.Values.ToList();
        }

    }
}
