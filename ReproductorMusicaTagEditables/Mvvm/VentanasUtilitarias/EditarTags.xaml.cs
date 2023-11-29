
using ReproductorMusicaTagEditables.Controls.InfoCancionTablaTags;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;


namespace ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias
{

    public partial class EditarTags : Window
    {
        private bool _todosSeleccionados = false;
        public EditarTags()
        {
            InitializeComponent();
            
        }

        public EditarTags(ObservableCollection<Cancion> cancionesAlbum)
        {
            InitializeComponent();
            editorTags.Canciones = new List<Cancion>(cancionesAlbum);
            editorTags.CargarTodosLosItems();
            editorTags.TodosLosItems.ForEach(i =>
            {
                i.MouseLeave += InfoCancionTablaTagsControl_MouseLeave;
            });
            editorTags.MjeVacio = Visibility.Collapsed;
        }

    
        private void Limpiar_Campos(object sender, RoutedEventArgs e)
        {
            editorTags.LimpiarCampos();
            editorTags.HabilitarEdicionCampos();
        }
        private void InfoCancionTablaTagsControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            InfoCancionTablaTagsControl i = (InfoCancionTablaTagsControl)sender;
            editorTags.SeleccionaroDeseleccionar(i);
        }
        private void Editar_Tags(object sender, RoutedEventArgs e)
        {
            editorTags.Editar();
            editorTags.DeseleccionarTodasLasCanciones();
            editorTags.TodosLosItems.ForEach(i =>
            {
                i.MouseLeave += InfoCancionTablaTagsControl_MouseLeave;
            });
           
        }
        private void Seleccionar_Imagen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog fs = new OpenFileDialog();
            if(fs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                editorTags.PathImagen = fs.FileName;
                imagenAlbum.Background = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.NUEVA_IMAGEN).DameImagen(fs.FileName);
            }
        }
        private void Seleccionar_Todas(object sender, RoutedEventArgs e)
        {
            _todosSeleccionados = !_todosSeleccionados;
            if(_todosSeleccionados)
            {
                editorTags.SeleccionarTodasLasCanciones();
                editorTags.TodosLosItems.ForEach(i =>
                {
                    i.MouseLeave += InfoCancionTablaTagsControl_MouseLeave;
                });
            } else
            {
                editorTags.DeseleccionarTodasLasCanciones();
                editorTags.TodosLosItems.ForEach(i =>
                {
                    i.MouseLeave += InfoCancionTablaTagsControl_MouseLeave;
                });
            }
        }
        private void Cerrar_Ventana(object sender, RoutedEventArgs e)
        {
            if(editorTags.Canciones.Count > 0)
            {
                editorTags.Canciones.Clear();
                editorTags.TodosLosItems.Clear();
                editorTags.Seleccionadas.Clear();
                editorTags.LimpiarCampos();
                editorTags.HabilitarEdicionCampos();
                
            }
            Hide();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Formatear_Numeros(object sender, RoutedEventArgs e)
        {
            editorTags.EstablecerNumerosDeAlbumes();
            editorTags.TodosLosItems.ForEach(i =>
            {
                i.MouseLeave += InfoCancionTablaTagsControl_MouseLeave;
            });
        }
        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter) 
            {
                editorTags.Editar();
                editorTags.DeseleccionarTodasLasCanciones();
                editorTags.TodosLosItems.ForEach(i =>
                {
                    i.MouseLeave += InfoCancionTablaTagsControl_MouseLeave;
                });
            }
        }
        private async void Seleccionar_Directorio(object sender, RoutedEventArgs e)
        {
       
            if(await editorTags.CargarCancionesAEditar())
            {
                editorTags.TodosLosItems.ForEach(i =>
                {
                    i.MouseLeave += InfoCancionTablaTagsControl_MouseLeave;
                });
                editorTags.MjeVacio = Visibility.Collapsed;
            }
            
        }
    }
}
