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
        public List<AvatarArtista> _artistas;

        public List<AvatarArtista> Avatars 
        { 
            get => _artistas;
            set
            {
                _artistas = value;
                OnPropertyChanged(nameof(Avatars));

            }
        }

        public TodosLosArtistasViewModel() { 
            Avatars = new List<AvatarArtista>();
        }

        public async void CargarListaDeAvataresArtistas()
        {
            Avatars = new SortedSet<AvatarArtista>
                (
                    await CargarAvatares()
                ).ToList();

            Avatars = Avatars.Select(a =>
            {
                a.ImagenArtista = ArchivoImagenBase.archivoImagenFabrica(
                    ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(a.PathImagen);
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
                        return a.NombreArtista.ToUpper().Contains(artista.ToUpper());
                    }).ToList();
                });
            }
            else
            {
                CargarListaDeAvataresArtistas();
            }
            
        }

        private async Task<List<AvatarArtista>> CargarAvatares ()
        {
            return await Task.Run(() =>
            {
                return Irg.Canciones.Where(c=>System.IO.File.Exists(c.Path)).Select(c =>
                {
                    return new AvatarArtista { NombreArtista = c.Artista, PathImagen = c.Path};
                }).ToList();
            });
        }

    }
}
