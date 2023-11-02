using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class TodosLosAlbumesViewModel:ReproductorViewModelBase
    {

        private List<AvatarAlbum> _avatarAlbums = new List<AvatarAlbum>();


        public List<AvatarAlbum> AvatarAlbums 
        { 
            get => _avatarAlbums; 
            set
            {
                _avatarAlbums = value;
                OnPropertyChanged(nameof(AvatarAlbums));
            } 
        }


        public async void CargarAvatarAlbumes()
        {
            AvatarAlbums = await Task<List<AvatarAlbum>>.Run(() => new SortedSet<AvatarAlbum>
            (
                Irg.Canciones.Select(c => new AvatarAlbum { NombreAlbum = c.Album, Ano = c.FechaLanzamiento, PathImagen = c.Path }).ToList()

            ).ToList());


            await Task.Run(() =>
            {
                AvatarAlbums.Sort(delegate (AvatarAlbum a1, AvatarAlbum a2)
                {
                    return a1.NombreAlbum.CompareTo(a2.NombreAlbum);
                });

            });



            AvatarAlbums = AvatarAlbums.Select(a =>
            {
                a.Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(a.PathImagen);
                return a;
            }).ToList();
        }

        public async void BuscarPorAlbum(string Album)
        {
            if(string.IsNullOrWhiteSpace(Album)) 
                CargarAvatarAlbumes();
            else
                AvatarAlbums = await Task<List<AvatarAlbum>>.Run(() => AvatarAlbums.Where(a => a.NombreAlbum.ToUpper().Contains(Album.ToUpper())).ToList());
        }

    }
}
