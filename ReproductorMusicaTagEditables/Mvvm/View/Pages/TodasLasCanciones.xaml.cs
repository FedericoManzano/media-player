
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias;
using ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas;
using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    public partial class TodasLasCanciones : Page
    {
        
        public TodasLasCanciones()
        {
            InitializeComponent();
           
            panelPrincipal.AgregarElementosAlFiltro();
            scrollCanciones.ScrollToVerticalOffset(panelPrincipal.ScrollVertical);
        }

        private void InfoCancionTabla_PlayClick(object sender, EventArgs e)
        {
            panelPrincipal.ScrollVertical = scrollCanciones.VerticalOffset;
        }

        private void Actualiza_El_Listado_Canciones(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            panelPrincipal.ScrollVertical = scrollCanciones.VerticalOffset;
            panelPrincipal.AgregarElementosAlFiltro();
        }

        private void Cargar_Archivos_Directorio(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void InfoCancionTabla_ArtistaClick(object sender, EventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla)sender;
            if (i.ArtistaInfo == "Desconocido")
            {
                System.Windows.Forms.MessageBox.Show("El artista que intenta acceder es desconocido, por lo tanto, la metadata de los archivos de audio es inexistente. Puede solucionar esto desde el botón (EDITAR TAGS) de la pestaña 'Inicio' para agregar la información pertinente.", "Artista Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            this.NavigationService.Navigate(new InfoArtistaPage(i.ArtistaInfo));
        }

        private void InfoCancionTabla_AlbumClick(object sender, EventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla)sender;
            if (i.AlbumInfo == "Desconocido")
            {
                System.Windows.Forms.MessageBox.Show("El álbum al que intenta acceder es desconocido, por lo tanto, la metadata de los archivos de audio es inexistente. Puede solucionar esto desde el botón (EDITAR TAGS) de la pestaña 'Inicio' para agregar la información pertinente.", "Álbum Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            this.NavigationService.Navigate(new InfoAlbumPage(i.AlbumInfo));  
        }

       
        private void InfoCancionTabla_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla)sender;
            if (i.EstaSeleccionado())
            {
                panelPrincipal.SeleccionarCancion(i);
                agregarControl.Visibilidad = System.Windows.Visibility.Visible;
            }
            else
            {
                panelPrincipal.DeseleccionarCancion(i);
                if(panelPrincipal.CantidadSeleccionado() == 0 && agregarControl.Visibilidad == System.Windows.Visibility.Visible)
                {
                    agregarControl.Visibilidad = System.Windows.Visibility.Hidden;
                }
            }
        }

        private void agregarControl_AgregarClick(object sender, EventArgs e)
        {
            panelPrincipal.CargarListadoEneditorListas();
        }

        private void agregarControl_DesmarcarClick(object sender, EventArgs e)
        {
            panelPrincipal.Irg.Partes.Clear();
            panelPrincipal.AgregarElementosAlFiltro();
            panelPrincipal.DeseleccionarTodas();
            agregarControl.Visibilidad = System.Windows.Visibility.Hidden;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditarTags editor = new EditarTags();
            editor.ShowDialog();
        }
    }
}
