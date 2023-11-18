using ReproductorMusicaTagEditables.Controls.InfoCancionTablaTags;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;


namespace ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias
{

    public partial class EditarTags : Window
    {
        public EditarTags()
        {
            InitializeComponent();
            
        }

        private bool _todosSeleccionados = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            editorTags.CargarCancionesAEditar();
        }

        private void InfoCancionTablaTagsControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            InfoCancionTablaTagsControl i = (InfoCancionTablaTagsControl)sender;
            Cancion c = new Cancion()
            {
                Numero = i.Numero,
                Titulo = i.Titulo,
                Album = i.Album,
                Artista = i.Artista,
                FechaLanzamiento = i.Ano,
                Genero = i.Genero,
            };

            if(!i.Seleccionado)
            {
                if(!_todosSeleccionados)
                    editorTags.CancionesSeleccionadas.Remove(c);
            }
            else
            {
                if(editorTags.CancionesSeleccionadas.IndexOf(c) == -1 )
                {
                    foreach (Cancion co in editorTags.Canciones)
                    {
                        if (co.Equals(c))
                        {
                            c = co;
                        }
                    }
                    editorTags.CancionesSeleccionadas.Add(c);
                    CargarCancionCampos(c);
                }
            }
        }

       private void CargarCancionCampos (Cancion c)
       {
            SetearNumero(c.Numero);
            SetearTitulo(c.Titulo);
            SetearArtista(c.Artista);
            SetearAlbum(c.Album);
            SetearGenero(c.Genero);
            SetearAno(c.FechaLanzamiento);
         
            imagenAlbum.Background = 
                ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(c.Path);
            FormatearSeleccion();
        }
        
       private void FormatearSeleccion()
       {
            if(editorTags.CancionesSeleccionadas.Count > 1)
            {
                LimpiarCampoNumero();
                DeshabilitarCampoNumero();
                
                LimpiarCampoTitulo();
                DeshabilitarCampoTitulo();

                List<string> lAlbum = new SortedSet<string>(
                    editorTags.CancionesSeleccionadas.Select(c => c.Album).ToList()
                ).ToList() ; 
                if(lAlbum.Count > 1)
                {
                    LimpiarCampoAlbum();
                    LimpiarCampoGenero();
                    LimpiarCampoAno();
                    imagenAlbum.Background = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();   
                }
                List<string> lArtista = new SortedSet<string>(
                    editorTags.CancionesSeleccionadas.Select(c => c.Artista).ToList()
                ).ToList();


                if(lArtista.Count > 1) 
                {
                    LimpiarCampoArtista();
                }
            }
       }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            editorTags.EditarTags();
            LimpiarYHabilitarTodosLosCampos();
        }


        private void LimpiarYHabilitarTodosLosCampos ()
        {
            LimpiarCampoNumero();
            HabilitarCampoNumero();

            LimpiarCampoTitulo();
            HabilitarCampoTitulo();

            LimpiarCampoArtista();
            HabilitarCampoArtista();

            LimpiarCampoAlbum();
            HabilitarCampoAlbum();

            LimpiarCampoGenero();
            HabilitarCampoGenero();

            LimpiarCampoAno();  
            HabilitarCampoAno();

            imagenAlbum.Background = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
            editorTags.IconoMarcado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.SquareRegular;
            _todosSeleccionados = false;
        }

        private void imagenAlbum_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog fs = new OpenFileDialog();
            if(fs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                editorTags.PathImagen = fs.FileName;
                imagenAlbum.Background = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.NUEVA_IMAGEN).DameImagen(fs.FileName);
            }
        }

        private void SetearNumero(string numero)
        {
            txtNumero.Texto = numero;
            txtNumero.DesaparecerPlaceholder();
        }


        private void SetearTitulo(string numero)
        {
            txtTitulo.Texto = numero;
            txtTitulo.DesaparecerPlaceholder();
        }

        private void SetearArtista(string numero)
        {
            txtArtista.Texto = numero;
            txtArtista.DesaparecerPlaceholder();
        }


        private void SetearAlbum(string numero)
        {
            txtAlbum.Texto = numero;
            txtAlbum.DesaparecerPlaceholder();
        }


        private void SetearGenero(string numero)
        {
            txtGenero.Texto = numero;
            txtGenero.DesaparecerPlaceholder();
        }

        private void SetearAno(string numero)
        {
            txtAno.Texto = numero;
            txtAno.DesaparecerPlaceholder();
        }


        private void LimpiarCampoNumero()
        {
            txtNumero.Texto = "";
            txtNumero.AparecerPlaceholder();
        }

        private void DeshabilitarCampoNumero ()
        {
            txtNumero.Habilitado = false;
        }
        private void HabilitarCampoNumero()
        {
            txtNumero.Habilitado = true;
        }



        private void LimpiarCampoTitulo()
        {
            txtTitulo.Texto = "";
            txtTitulo.AparecerPlaceholder();
        }

        private void DeshabilitarCampoTitulo()
        {
            txtTitulo.Habilitado = false;
        }
        private void HabilitarCampoTitulo()
        {
            txtTitulo.Habilitado = true;
        }



        private void LimpiarCampoArtista()
        {
            txtArtista.Texto = "";
            txtArtista.AparecerPlaceholder();
        }

        private void DeshabilitarCampoArtista()
        {
            txtArtista.Habilitado = false;
        }
        private void HabilitarCampoArtista()
        {
            txtArtista.Habilitado = true;
        }


        private void LimpiarCampoAlbum()
        {
            txtAlbum.Texto = "";
            txtAlbum.AparecerPlaceholder();
        }

        private void DeshabilitarCampoAlbum()
        {
            txtAlbum.Habilitado = false;
        }
        private void HabilitarCampoAlbum()
        {
            txtAlbum.Habilitado = true;
        }


        private void LimpiarCampoGenero()
        {
            txtGenero.Texto = "";
            txtGenero.AparecerPlaceholder();
        }

        private void DeshabilitarCampoGenero()
        {
            txtGenero.Habilitado = false;
        }
        private void HabilitarCampoGenero()
        {
            txtGenero.Habilitado = true;
        }

        private void LimpiarCampoAno()
        {
            txtAno.Texto = "";
            txtAno.AparecerPlaceholder();
        }

        private void DeshabilitarCampoAno()
        {
            txtAno.Habilitado = false;
        }
        private void HabilitarCampoAno()
        {
            txtAno.Habilitado = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            LimpiarYHabilitarTodosLosCampos();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _todosSeleccionados = !_todosSeleccionados;
            editorTags.CancionesSeleccionadas.Clear();
            if(_todosSeleccionados)
            {
                editorTags.IconoMarcado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CheckSquareSolid;
                foreach(var i in itemList.Items)
                {
                    Cancion c = (Cancion)i;
                    editorTags.CancionesSeleccionadas.Add(c);
                    CargarCancionCampos(c);
                }

                DeshabilitarCampoNumero();
                DeshabilitarCampoTitulo();
            } else
            {
                editorTags.IconoMarcado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.SquareRegular;
                editorTags.CancionesSeleccionadas.Clear();
                LimpiarYHabilitarTodosLosCampos();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            editorTags.CancionesSeleccionadas.Clear();
            editorTags.Canciones.Clear();
            LimpiarYHabilitarTodosLosCampos();
            Hide();
        }
    }
}
