using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias
{
    /// <summary>
    /// Lógica de interacción para CrearListaReproduccion.xaml
    /// </summary>
    public partial class CrearListaReproduccion : Window
    {
        public CrearListaReproduccion()
        {
            InitializeComponent();
            txtTitulo.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mensajeEstado.Text = "";
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
                    ListasReproduccion.Crear(txtTitulo.Texto);
                    txtTitulo.Texto = "";
                    MensajeestadoOk();
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
