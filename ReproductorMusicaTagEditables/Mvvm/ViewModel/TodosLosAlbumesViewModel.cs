﻿using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class TodosLosAlbumesViewModel:ReproductorViewModelBase
    {

        private Dictionary<string, Dictionary<string, Cancion>> diccionarioalbumes = 
                    new Dictionary<string, Dictionary<string, Cancion>>();


        private Dictionary<string, bool> paginacion =
                    new Dictionary<string, bool>();

        private ObservableCollection<Cancion> _avatarAlbums = 
                    new ObservableCollection<Cancion>();


        public ObservableCollection<Cancion> AvatarAlbums 
        { 
            get => _avatarAlbums; 
            set
            {
                _avatarAlbums = value;
                OnPropertyChanged(nameof(AvatarAlbums));
            } 
        }

        public Dictionary<string, bool> Paginacion 
        { 
            get => paginacion;
            set 
            { 
                paginacion = value;
                OnPropertyChanged(nameof(Paginacion)); 
            } 
        }

        public  void CargarAvatarAlbumes()
        {
            for(int i = 0; i < Irg.Canciones.Count; i ++)
            {
                if (diccionarioalbumes.ContainsKey(Irg.Canciones[i].Album.PrimeraLetraMayuscula()))
                {
                    diccionarioalbumes[Irg.Canciones[i].Album.PrimeraLetraMayuscula()][Irg.Canciones[i].Album] = Irg.Canciones[i];
                }
                else
                {
                    diccionarioalbumes[Irg.Canciones[i].Album.PrimeraLetraMayuscula()] = new Dictionary<string, Cancion>
                    {
                        [Irg.Canciones[i].Album] = Irg.Canciones[i]
                    };
                }
                Paginacion[Irg.Canciones[i].Album.PrimeraLetraMayuscula()] = false;
            }
            if (diccionarioalbumes.Count > 0)
            {
                Paginacion = Paginacion.OrdenarPorClave();
                Paginacion = Paginacion.MarcarClave(Paginacion.Keys.First());
                AvatarAlbums = diccionarioalbumes.CargarImagenes(Paginacion.Keys.First());
            }
        }

        public void BuscarPorAlbum(string inicialAlbum)
        {
            Paginacion = Paginacion.DesmarcarTodos();
            Paginacion = Paginacion.MarcarClave(inicialAlbum);
            AvatarAlbums = diccionarioalbumes.CargarImagenes(inicialAlbum);
        }
    }
}
