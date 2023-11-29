using ReproductorMusicaTagEditables.Controls.InfoCancionTablaTags;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaInicial;
using ReproductorMusicaTagEditables.Mvvm.View.Pages;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using MessageBox = System.Windows.MessageBox;

namespace ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias.HandlerEditorTags
{
    public class EditorViewModel:ReproductorViewModelBase
    {

        #region Listados Utilizados
        private List<Cancion> _canciones;
        private List<InfoCancionTablaTagsControl> _seleccionadas;
        private List<InfoCancionTablaTagsControl> _todosLosItems;
        public List<Cancion> Canciones
        {
            get => _canciones;
            set
            {
                _canciones = value;
                OnPropertyChanged(nameof(Canciones));
            }
        }
        public List<InfoCancionTablaTagsControl> Seleccionadas
        {
            get => _seleccionadas;
            set
            {
                _seleccionadas = value;
                OnPropertyChanged(nameof(Seleccionadas));
            }
        }
        public List<InfoCancionTablaTagsControl> TodosLosItems
        {
            get => _todosLosItems;
            set
            {
                _todosLosItems = value;
                OnPropertyChanged(nameof(TodosLosItems));
            }
        }
        #endregion

        #region Campos texto
        private string _numero;
        private string _titulo;
        private string _artista;
        private string _album;
        private string _genero;
        private string _ano;
        private ImageBrush _imagen;
        private string _pathImagen;
        private Visibility _mjeVacio;

        private bool _editarNumero;
        private bool _editarTitulo;
        private bool _editarArtista;
        private bool _editarAlbum;
        private bool _editarGenero;
        private bool _editarAno;

        public string Numero
        {
            get => _numero;
            set
            {
                _numero = value;
                OnPropertyChanged(nameof(Numero));  
            }
        }
        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                OnPropertyChanged(nameof(Titulo));
            }
        }
        public string Artista
        {
            get => _artista;
            set
            {
                _artista = value;
                OnPropertyChanged(nameof(Artista)); 
            }
        }
        public string Album
        {
            get => _album;
            set
            {
                _album = value;
                OnPropertyChanged(nameof(Album));
            }
        }
        public string Genero
        {
            get => _genero;
            set
            {
                _genero = value;
                OnPropertyChanged(nameof(Genero));  
            }
        }
        public string Ano
        {
            get => _ano;
            set
            {
                _ano = value;   
                OnPropertyChanged(nameof(Ano)); 
            }
        }
        public ImageBrush Imagen
        {
            get => _imagen;
            set
            {
                _imagen = value;
                OnPropertyChanged(nameof(Imagen));
            }
        }

        public string PathImagen
        {
            get => _pathImagen;
            set
            {
                _pathImagen = value;
                OnPropertyChanged(nameof(PathImagen));
            }
        }

        public bool EditarNumero
        {
            get => _editarNumero;
            set
            {
                _editarNumero = value;
                OnPropertyChanged(nameof(EditarNumero));
            }
        }
        public bool EditarTitulo
        {
            get => _editarTitulo;
            set
            {
                _editarTitulo = value;
                OnPropertyChanged(nameof(EditarTitulo));
            }
        }
        public bool EditarArtista
        {                 
            get => _editarArtista;
            set
            {
                _editarArtista = value;
                OnPropertyChanged(nameof(EditarArtista));
            }
        }
        public bool EditarAlbum
        {
            get => _editarAlbum;
            set
            {
                _editarAlbum = value;
                OnPropertyChanged(nameof(EditarAlbum));
            }
        }
        public bool EditarGenero
        {
            get => _editarGenero;
            set
            {
                _editarGenero = value;
                OnPropertyChanged(nameof(EditarGenero));
            }
        }
        public bool EditarAno
        {
            get => _editarAno;
            set
            {
                _editarAno = value;
                OnPropertyChanged(nameof(EditarAno));
            }
        }
        public Visibility MjeVacio
        {
            get => _mjeVacio;
            set
            {
                _mjeVacio = value;
                OnPropertyChanged(nameof(MjeVacio));
            }
        }

        #endregion



        public EditorViewModel ()
        {
            Seleccionadas = new List<InfoCancionTablaTagsControl> ();
            Canciones = new List<Cancion>();
            MjeVacio = Visibility.Visible;
            LimpiarCampos();
            HabilitarEdicionCampos();
        }

        #region Seleccion
        public void CargarTodosLosItems()
        {

            TodosLosItems = Canciones.Select(c =>
            {
                InfoCancionTablaTagsControl i = new InfoCancionTablaTagsControl(false)
                {
                    Numero = c.Numero,
                    Titulo = c.Titulo,
                    Album = c.Album,
                    Artista = c.Artista,
                    Ano = c.FechaLanzamiento,
                    Genero = c.Genero,
                };
                return i;
            }).ToList();
        }
        public void SeleccionarCancion(InfoCancionTablaTagsControl infoCancion)
        {
            if (infoCancion != null && !ExisteCancionSeleccionada(infoCancion) && infoCancion.Seleccionado)
            {
                Seleccionadas.Add(infoCancion);
                AutocompletarCampos();
            }
        }
        public void DeseleccionarCancion(InfoCancionTablaTagsControl infoCancion)
        {
            if(infoCancion != null && ExisteCancionSeleccionada(infoCancion))
            {
                Seleccionadas = Seleccionadas.Where(ci => !infoCancion.Equals(ci)).ToList();
                AutocompletarCampos();
            }
        }
        public void DeseleccionarTodasLasCanciones () 
        {
            Seleccionadas.ForEach(ci => ci.Seleccionado = false);
            Seleccionadas.Clear();
            TodosLosItems = Canciones.Select(c =>
            {
                InfoCancionTablaTagsControl i = new InfoCancionTablaTagsControl(false)
                {
                    Numero = c.Numero,
                    Titulo = c.Titulo,
                    Album = c.Album,
                    Artista = c.Artista,
                    Ano = c.FechaLanzamiento,
                    Genero = c.Genero,
                };
                return i;
            }).ToList();
            
            AutocompletarCampos();
        }
        public void SeleccionaroDeseleccionar(InfoCancionTablaTagsControl infoCancion)
        {
            if (infoCancion.Seleccionado)
            {
                SeleccionarCancion(infoCancion);
            }
            else
            {
                DeseleccionarCancion(infoCancion);
            }
        }
        public void AutocompletarCampos()
        {
            if (Seleccionadas.Count == 1)
            {
                InfoCancionTablaTagsControl i = Seleccionadas[0];

                Numero = i.Numero;
                Titulo = i.Titulo;
                Artista = i.Artista;
                Album = i.Album;
                Genero = i.Genero;
                Ano = i.Ano;
                Cancion c = DameCancionPorClave(i);
                Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(c.Path);
            } else if(Seleccionadas.Count > 1)
            {
                SortedSet<string> artista = new SortedSet<string>(  Seleccionadas.Select(s => s.Artista).ToList());
                if(artista.Count == 1)
                {
                    InfoCancionTablaTagsControl i = Seleccionadas[0];
                    LimpiarTitulo();
                    DeshabilitarTitulo();
                    LimpiarNumero();
                    DeshabilitarNumero();
                    Artista = i.Artista;
                }

                SortedSet<string> album = new SortedSet<string>(Seleccionadas.Select(s => s.Album).ToList());
                if (album.Count == 1)
                {
                    InfoCancionTablaTagsControl i = Seleccionadas[0];
                    LimpiarTitulo();
                    DeshabilitarTitulo();
                    LimpiarNumero();
                    DeshabilitarNumero();
                    Cancion c = DameCancionPorClave(i);
                    if(c != null)
                        Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(c.Path)??
                        ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
                    else ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
                    Album = i.Album;
                }

                SortedSet<string> genero = new SortedSet<string>(Seleccionadas.Select(s => s.Genero).ToList());
                if (genero.Count == 1)
                {
                    InfoCancionTablaTagsControl i = Seleccionadas[0];
                    LimpiarTitulo();
                    DeshabilitarTitulo();
                    LimpiarNumero();
                    DeshabilitarNumero();
                    Genero = i.Genero;
                }

                SortedSet<string> ano = new SortedSet<string>(Seleccionadas.Select(s => s.Ano).ToList());
                if (ano.Count == 1)
                {
                    InfoCancionTablaTagsControl i = Seleccionadas[0];
                    LimpiarTitulo();
                    DeshabilitarTitulo();
                    LimpiarNumero();
                    DeshabilitarNumero();
                    Ano = i.Ano;
                }

            }else
            {
                LimpiarCampos();
                HabilitarEdicionCampos();
            }
        }
        public void SeleccionarTodasLasCanciones()
        {
            DeseleccionarTodasLasCanciones();
            Seleccionadas = Canciones.Select(c =>
            {
                InfoCancionTablaTagsControl i = new InfoCancionTablaTagsControl(true)
                {
                    Numero  = c.Numero,
                    Titulo  = c.Titulo,
                    Album   = c.Album,
                    Artista = c.Artista,
                    Ano     = c.FechaLanzamiento,
                    Genero  = c.Genero,
                };
                return i;
            }).ToList();
            TodosLosItems = Seleccionadas;
            AutocompletarCampos();
        }
        public bool ExisteCancionSeleccionada(InfoCancionTablaTagsControl infoCancion)
        {
            return Seleccionadas.Where(ic => ic.Equals(infoCancion)).Any();
        }
        public Cancion DameCancionPorClave(InfoCancionTablaTagsControl infoCancion)
        {
            List<Cancion> lu = Canciones.Where(c => c.Titulo == infoCancion.Titulo && c.Album == infoCancion.Album && c.Artista == infoCancion.Artista).ToList();
            if(lu != null && lu.Count == 1) 
            {
                return lu[0];
            }
            return null;
        }
        #endregion

        #region Habilitar
        public void LimpiarCampos()
        {
            LimpiarNumero();
            LimpiarTitulo();
            LimpiarAlbum();
            LimpiarArtista();
            LimpiarGenero();
            LimpiarAno();
            LimpiarImagen();
    
        }
        public void HabilitarEdicionCampos()
        {
            HabilitarNumero();
            HabilitarTitulo();
            HabilitarAlbum();
            HabilitarArtista();
            HabilitarGenero();
            HabilitarAno();
        }


        #region Numero
        public void LimpiarNumero ()
        {
            Numero = string.Empty;
        }

        public void HabilitarNumero()
        {
            EditarNumero = true;
        }

        public void DeshabilitarNumero()
        {
            EditarNumero = false;
        }
        #endregion

        #region Titulo
        public void LimpiarTitulo()
        {
            Titulo = string.Empty;
        }
        public void HabilitarTitulo()
        {
            EditarTitulo = true;
        }
        public void DeshabilitarTitulo()
        {
            EditarTitulo = false;
        }
        #endregion

        #region Artista
        public void LimpiarArtista()
        {
            Artista = string.Empty;
        }
        public void HabilitarArtista()
        {
            EditarArtista = true;
        }
        public void DeshabilitarArtista()
        {
            EditarArtista = false;
        }

        #endregion

        #region Album
        public void LimpiarAlbum()
        {
            Album = string.Empty;
        }
        public void HabilitarAlbum()
        {
            EditarAlbum = true;
        }
        public void DeshabilitarAlbum()
        {
            EditarAlbum = false;
        }
        #endregion

        #region Genero
        public void LimpiarGenero()
        {
            Genero = string.Empty;
        }
        public void HabilitarGenero()
        {
            EditarGenero = true;
        }
        public void DeshabilitarGenero()
        {
            EditarGenero = false;
        }
        #endregion

        #region Ano
        public void LimpiarAno()
        {
            Ano = string.Empty;
        }
        public void HabilitarAno()
        {
            EditarAno = true;
        }
        public void DeshabilitarAno()
        {
            EditarAno = false;
        }
        #endregion


        public void LimpiarImagen ()
        {
            Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
        }

        #endregion

        #region Editar
        public void Editar()
        {
            if (Seleccionadas.Count <= 0)
            {
                System.Windows.Forms.MessageBox.Show(
                           $"No hay canciones seleccionadas.", "Mensaje Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            InfoReproductor ir = InfoReproductor.DameInstancia();

            foreach (var i in Seleccionadas)
            {
                Cancion c = DameCancionPorClave(i);
                
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
                            {
                                ActualizarCancionEnListado(c);
                                return c;
                            }
                                
                            return cl;
                        }).ToList();

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
            
           
            RepositorioDeCanciones.GuardarCanciones(ir.Canciones);
            
        }

        public void EstablecerNumerosDeAlbumes()
        {
            if (Seleccionadas.Count <= 0)
                return;
            SortedSet<string> album = new SortedSet<string>
            (
                Seleccionadas.Select(e => e.Album).ToList()
            );

            if (album.Count == 1)
            {
                InfoReproductor ir = InfoReproductor.DameInstancia();
                uint nroCancion = 1;
                foreach (var i in Seleccionadas)
                {
                    Cancion c = DameCancionPorClave(i);
                    try
                    {
                        
                        if (File.Exists(c.Path))
                        {
                            var tag = TagLib.File.Create(c.Path);
                            tag.Tag.Track = nroCancion;
                            c.Numero = nroCancion.ToString();
                            tag.Save();
                            ir.Canciones = ir.Canciones.Select(cl =>
                            {
                                if (cl.Path == c.Path)
                                {
                                    ActualizarCancionEnListado(c);
                                    return c;
                                }

                                return cl;
                            }).ToList();
                            nroCancion++;
                        }
                    }
                    catch (IOException e)
                    {
                        System.Windows.Forms.MessageBox.Show
                        (
                                $"La canción {c.Titulo} se está reproduciendo justo en este momento. No puede editar sus Tags." +
                                Environment.NewLine +
                                Environment.NewLine +
                                $"Exception: {e.Message}",
                                "Mensaje error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                        );
                    }

                }

      
                RepositorioDeCanciones.GuardarCanciones(ir.Canciones);
            }
        }
        private void ActualizarCancionEnListado(Cancion c)
        {
            for(int i = 0; i < Canciones.Count; i++)
            {
                if (Canciones[i].Path == c.Path)
                    Canciones[i] = c;
            }
            
        }

        private void ModificarImagen(Cancion c, TagLib.File tag)
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

        private void ModificarAno(Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Ano) &&
                Regex.Match(Ano, "^[0-9]{4}$").Success)
            {
                tag.Tag.Year = uint.Parse(Ano);
                c.FechaLanzamiento = Ano;
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

        private void ModificarAlbum(Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Album))
            {
                tag.Tag.Album = Album;
                c.Album = Album;
            }
        }

        private void ModificarArtista(Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Artista))
            {

                tag.Tag.Artists = new string[] { Artista }; ;
                c.Artista = Artista;

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

        private void ModificarNumero(Cancion c, TagLib.File tag)
        {
            if (!string.IsNullOrEmpty(Numero) &&
                Regex.Match(Numero, "^([0-9]{1,5})$").Success)
            {
                tag.Tag.Track = uint.Parse(Numero);
                c.Numero = Numero;
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
        #endregion


        public async Task<bool> CargarCancionesAEditar()
        {
            FolderBrowserDialog fc = new FolderBrowserDialog();

            if (fc.ShowDialog() == DialogResult.OK)
            {
                Seleccionadas.Clear();
                MjeVacio = Visibility.Collapsed;
                CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();
                List<string> paths = new List<string>(await cargarMusica.IniciarCargaReproductor(fc.SelectedPath));
                Canciones = await cargarMusica.CargarListadoDeCancionesAsync(paths);
                if(Canciones.Count > 0)
                {
                    CargarTodosLosItems();
                    return true;
                }
                
            }
            return false;
        }
    }
}
