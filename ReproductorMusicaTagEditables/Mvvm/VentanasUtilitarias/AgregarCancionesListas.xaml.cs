
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias
{
    public partial class AgregarCancionesListas : Window
    {
        private ReproductorViewModelBase ReproductorViewModelBase;
        private List<Cancion> listadoCancionesAgregar = new List<Cancion>();



        public AgregarCancionesListas(ReproductorViewModelBase reproductorViewModel)
        {
            InitializeComponent();
            this.ReproductorViewModelBase = reproductorViewModel;
        }

        public bool AgregarCancion(Cancion c)
        {
            List<string> l = ListasReproduccion.ListadoNombres();
            if(l.Count == 0)
            {
                
                MostrarMensajeError("No hay listas de reproducciones creadas. Dirijase a la opción 'Mis listas' del menú lateral.");
                Hide();
                return false;
            }
            listadoCancionesAgregar = new List<Cancion>() { c };
            lstListasRepro.ItemsSource = l;
            lstAgregar.ItemsSource = listadoCancionesAgregar;
            return true;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(lstListasRepro.Items.Count > 0 && lstListasRepro.SelectedIndex < 0)
            {
                MostrarMensajeError($"Para poder cargar canciones a una determinada lista debe seleccionarla primero. Desde el panel que está a su izquierda con los nombres de las listas existentes.");
                return;
            }

            if(lstAgregar.Items.Count > 0)
            {
                lstAgregar.SelectAll();

                listadoCancionesAgregar.ForEach(c =>
                {
                    ReproductorViewModelBase.Irg.Canciones.ForEach(cl =>
                    {
                        if (cl.Titulo == c.Titulo)
                        {
                            if (lstListasRepro.Items.Count > 0)
                            {
                                if(ListasReproduccion.AgregarCancion(lstListasRepro.Items[lstListasRepro.SelectedIndex].ToString(), cl))
                                {
                                    MostrarMensajeInfo($"La canción/s fueron agregadas a {lstListasRepro.Items[lstListasRepro.SelectedIndex]} con exito.");
                                    Hide();
                                } else
                                {
                                    MostrarMensajeError($"La cación/s que intenta agregar ya se encuentran en la lista seleccionada. ");
                                }
                            }
                        }
                    });
                });
            }
        }

        public void MostrarMensajeInfo(string mje)
        {
            System.Windows.Forms.MessageBox.Show(mje,"Ingreso de canciones",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void MostrarMensajeError (string mje)
        {
            System.Windows.Forms.MessageBox.Show(mje, "Ingreso de canciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listadoCancionesAgregar.Clear();
            lstAgregar.SelectedIndex = -1;
            lstListasRepro.SelectedIndex = -1;
            Hide();
        }
    }
}
