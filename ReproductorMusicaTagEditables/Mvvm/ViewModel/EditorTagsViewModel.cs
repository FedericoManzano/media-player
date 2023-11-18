using MahApps.Metro.IconPacks;
using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaInicial;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class EditorTagsViewModel : ViewModelBase
    {

        #region Listados
        private ObservableCollection<Cancion> _canciones = new ObservableCollection<Cancion>();
        private ObservableCollection<Cancion> _cancionesSeleccionadas = new ObservableCollection<Cancion>();

        public ObservableCollection<Cancion> Canciones
        {
            get => _canciones;
            set { _canciones = value; OnPropertyChanged(nameof(Canciones)); }
        }
        public ObservableCollection<Cancion> CancionesSeleccionadas
        {
            get => _cancionesSeleccionadas;
            set { _cancionesSeleccionadas = value; OnPropertyChanged(nameof(CancionesSeleccionadas)); }
        }
        #endregion

        #region Campos
        private string _numero;
        public string Numero
        {
            get => _numero;
            set { _numero = value; OnPropertyChanged(nameof(Numero));}
        }

        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set { _titulo = value; OnPropertyChanged(nameof(Titulo)); }
        }

        private string _artista;
        public string Artista
        {
            get => _artista;
            set { _artista = value; OnPropertyChanged(nameof(Artista)); }
        }


        private string _album;
        public string Album
        {
            get => _album;
            set { _album = value; OnPropertyChanged(nameof(Album)); }
        }

        private string _genero;
        public string Genero
        {
            get => _genero;
            set { _genero = value; OnPropertyChanged(nameof(Genero)); }
        }

        private string _ano;
        public string Ano
        {
            get => _ano;
            set { _ano = value; OnPropertyChanged(nameof(Ano)); }
        }


        private ImageBrush _imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();

        public ImageBrush Imagen
        {
            get => _imagen;
            set { _imagen = value; OnPropertyChanged(nameof(Imagen));}
        }

        private string _pathImagen = null;
        public string PathImagen
        {
            get => _pathImagen;
            set { _pathImagen = value; }
        }

        public PackIconFontAwesomeKind IconoMarcado { 
            get => _iconoMarcado;
            set { _iconoMarcado = value; OnPropertyChanged(nameof( IconoMarcado )); } 
        }

        private MahApps.Metro.IconPacks.PackIconFontAwesomeKind _iconoMarcado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.SquareRegular;


        #endregion




        public void EditarTags ()
        {
            InfoReproductor ir = InfoReproductor.DameInstancia();
            foreach (var c in CancionesSeleccionadas)
            {
                try
                {
                    if (File.Exists(c.Path))
                    {
                        var t = TagLib.File.Create(c.Path);
                        ModificarNumero(c, t);
                        ModificarTitulo(c, t);
                        ModificarArtista(c, t);
                        ModificarAlbum(c, t);
                        ModificarGenero(c, t);
                        ModificarAno(c, t);
                        ModificarImagen(c, t);

                        t.Save();
                        ir.Canciones = ir.Canciones.Select(cl =>
                        {
                            if (cl.Path == c.Path)
                                return c;
                            return cl;
                        }).ToList();
                        Canciones = new ObservableCollection<Cancion>(Canciones);
                        CancionesSeleccionadas.Clear();
                        RepositorioDeCanciones.GuardarCanciones(ir.Canciones);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(
                            $"El archivo físico {c.Path} fué eliminado en tiempo de ejecución.", "Mensaje error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (IOException e)
                {
                    System.Windows.Forms.MessageBox.Show(
                        $"La canción {c.Titulo} se está reproduciendo justo en este momento. No puede editar sus Tags." +
                        Environment.NewLine +
                        Environment.NewLine +
                        $"Exception: {e.Message}",
                        "Mensaje error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }



        private void ModificarNumero(Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Numero) && Regex.Match(Numero,"^([0-9]{1,5})$").Success)
            {
                tag.Tag.Track = uint.Parse(Numero);
                c.Numero = Numero;
            }
        }

        private void ModificarTitulo(Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Titulo))
            {
                tag.Tag.Title = Titulo;
                c.Titulo = Titulo;
            }
        }

        private void ModificarArtista (Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Artista))
            {
                
                tag.Tag.Artists = new string[] { Artista }; ;
                c.Artista = Artista;
                
            }
        } 

        private void ModificarAlbum (Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Album))
            {
                tag.Tag.Album = Album;
                c.Album = Album;
            }
        }


        private void ModificarGenero(Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Genero))
            {
                tag.Tag.Genres = new string[] { Genero };
                c.Genero = Genero;
            }
        }

        private void ModificarAno(Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Ano) && Regex.Match(Ano, "^[0-9]{4}$").Success)
            {
                tag.Tag.Year = uint.Parse(Ano);
                c.FechaLanzamiento = Ano;
            }
        }

        private void ModificarImagen (Cancion c, TagLib.File tag)
        {
            if (PathImagen != null)
            {
                using (MemoryStream ms = new MemoryStream(ImagenAByte(PathImagen)))
                {
                    TagLib.Picture pic = new TagLib.Picture
                    {
                        Data = TagLib.ByteVector.FromStream(ms)
                    };
                    tag.Tag.Pictures = new TagLib.IPicture[1] { pic };
                }
            }
        }

        public async void CargarCancionesAEditar()
        {
            FolderBrowserDialog fc = new FolderBrowserDialog();

            if(fc.ShowDialog() == DialogResult.OK)
            {
                CancionesSeleccionadas.Clear();
                CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();
                List<string> paths = new List<string>(await cargarMusica.IniciarCargaReproductor(fc.SelectedPath));
                Canciones = new ObservableCollection<Cancion>(await cargarMusica.CargarListadoDeCancionesAsync(paths));        
                
            }
        }

        public byte[] ImagenAByte(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] ImageData = new byte[fs.Length];
                    fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
                    return ImageData;
                }
            }
            return null;
        }
    }
}