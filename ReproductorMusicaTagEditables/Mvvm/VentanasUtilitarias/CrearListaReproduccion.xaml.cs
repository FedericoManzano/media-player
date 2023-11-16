using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel;
using System.Windows;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias
{
    public partial class CrearListaReproduccion : Window
    {
        private ListasViewModel lista;
        public CrearListaReproduccion(ListasViewModel listasViewModel)
        {
            InitializeComponent();
            txtTitulo.Focus();
            mensajeEstado.Text = "Campo Vacío.";
            mensajeEstado.Foreground = Brushes.Red;
            lista = listasViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mensajeEstado.Text = "Campo Vacío.";
            txtTitulo.Focus();
            txtTitulo.Texto = "";
            Hide();
        }

        private void CampoTextoControl_CambiandoTexto(object sender, RoutedEventArgs e)
        {
            mensajeEstado.Text = "";

            if(ListasReproduccion.ValidarNombre(txtTitulo.Texto))
            {
                if(!ListasReproduccion.ExisteLista(txtTitulo.Texto))
                {
                    txtTitulo.ColorBorde = "LightGreen";
                    MensajeestadoOk("Ese nombre de lista cumple las condiciones de creación.");
                    
                } else
                {
                    txtTitulo.ColorBorde = "Red";
                    MensajeestadoErr("El nombre ya existe.");
                }
            } else
            {
                txtTitulo.ColorBorde = "Red";
                MensajeestadoErr("Err Formato: a-z | A-Z | 0-9 y espacios. Min 3 Max 25 Caracteres");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (ListasReproduccion.ValidarNombre(txtTitulo.Texto))
            {
                if (!ListasReproduccion.ExisteLista(txtTitulo.Texto))
                {
                    if(ListasReproduccion.Crear(txtTitulo.Texto))
                    {
                        MessageBox.Show($"La lista {txtTitulo.Texto} fué creada exitosamente.");
                        txtTitulo.Texto = "";
                        
                        lista.CargarListasReproduccion();
                        Hide();
                    }
                }
                else
                {
                    MensajeestadoErr("La lista ya estaba creada con ese nombre.");
                }
            }
            else
            {
                MensajeestadoErr("Verifique el nombre ingresado. No cumple con los requisitos de ingreso.");
            }

            txtTitulo.Focus();
        }

        private void MensajeestadoOk (string mensaje = null)
        {
            if(mensaje == null)
            {
                mensajeEstado.Text = "La lista fue creada.";
            } else
            {
                mensajeEstado.Text = mensaje;
            }
            
            mensajeEstado.Foreground = Brushes.LightGreen;
        }

        private void MensajeestadoErr(string mensaje = null)
        {

            if (mensaje == null)
            {
                mensajeEstado.Text = "La lista no fue creada.";
            }
            else
            {
                mensajeEstado.Text = mensaje;
            }

            mensajeEstado.Foreground = Brushes.Red;
        }
    }
}
