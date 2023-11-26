using MahApps.Metro.Controls;
using ReproductorMusicaTagEditables.Controls.DescargarCancion;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using System.Windows;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    /// <summary>
    /// Lógica de interacción para DescargasPage.xaml
    /// </summary>
    public partial class DescargasPage : Page
    {
        public DescargasPage()
        {
            InitializeComponent();
            SeleccionarExtension();
            DescargarCancionControl d = new DescargarCancionControl();
            d.Click += DescargarCancionControl_Click;
            
            itemDescargas.Items.Add(d);
            descargarViewModel.MostrarNotificacion();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton r = (RadioButton) sender;

            if(r.IsChecked == true) 
            {
                DeseleccionarTodos();
                MahApps.Metro.IconPacks.PackIconFontAwesome i = r.FindChild<MahApps.Metro.IconPacks.PackIconFontAwesome>();
                i.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CircleSolid;
                r.IsChecked = true;
                
                if(r.Name  == "mp3")
                    descargarViewModel.ExtensionAudio = ".mp3";
                if(r.Name as string == "m4a")
                {
                    descargarViewModel.ExtensionAudio = ".m4a";
                }

                if (r.Name as string == "wav")
                {
                    descargarViewModel.ExtensionAudio = ".wav";
                }
            }
        }

        private void SeleccionarExtension()
        {
            mp3.IsChecked = true;
            iconMp3.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CircleSolid;
            descargarViewModel.ExtensionAudio = ".mp3";
        }
        private void DeseleccionarTodos()
        {
            RadioButton[] ra = selectores.FindChildren<RadioButton>().ToArray();
            foreach (RadioButton rb in ra)
            {
                rb.IsChecked = false;
                MahApps.Metro.IconPacks.PackIconFontAwesome i = rb.FindChild<MahApps.Metro.IconPacks.PackIconFontAwesome>();
                i.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CircleRegular;
            }
        }

        private void DescargarCancionControl_Click(object sender, System.EventArgs e)
        {

            DescargarCancionControl d = (DescargarCancionControl)sender;
            if (string.IsNullOrEmpty(d.Texto) || !Uri.IsWellFormedUriString(d.Texto, UriKind.Absolute))
            {
                MessageBox.Show("Complete el campo URL con la url del video que desea convertir.");
                return;
            }
            descargarViewModel.ConvertirVideo(d);
            DescargarCancionControl dPlus = new DescargarCancionControl();
            dPlus.Click += DescargarCancionControl_Click;
            itemDescargas.Items.Add(dPlus);
        }

        private async void Editar_Tags_Canciones(object sender, RoutedEventArgs e)
        {
            List<Cancion> l = await descargarViewModel.DameListadoCanciones();

            foreach(Cancion c in l)
            {
                
            }


            EditarTags ed = new EditarTags(new ObservableCollection<Cancion>(l));
            ed.ShowDialog();
        }

        private void Mover_Archivos(object sender, RoutedEventArgs e)
        {
            descargarViewModel.MoverArchivosDescargados();
        }
    }
}
