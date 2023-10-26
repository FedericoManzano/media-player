using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    public partial class TodasLasCanciones : Page
    {

        List<Cancion> lPrueba = new List<Cancion>()
        {
            new Cancion
            {
                Numero = "1",
                Titulo = "Un Angel para tu Soledad",
                Artista = "Patricio Rey",
                Album = "Lobo Suelto, Cordero Atado",
                Genero = "Rock Nacional",
                FechaLanzamiento = "1995",
                Duracion = "4:35"
            },


            new Cancion
            {
                Numero = "10",
                Titulo = "Enter Sandman",
                Artista = "Metallica",
                Album = "Black",
                Genero = "Heavy Metal",
                FechaLanzamiento = "1992",
                Duracion = "5:20"
            },


            new Cancion
            {
                Numero = "12",
                Titulo = "Brillan los Fantasmas",
                Artista = "Callejeros",
                Album = "Presión",
                Genero = "Rock Nacional",
                FechaLanzamiento = "2001",
                Duracion = "3:44"
            },

            new Cancion
            {
                Numero = "10",
                Titulo = "Fear of the Dark",
                Artista = "Iron Maiden",
                Album = "Fear of the Dark",
                Genero = "Heavy Metal",
                FechaLanzamiento = "1998",
                Duracion = "5:40"
            },


             new Cancion
            {
                Numero = "7",
                Titulo = "Fade to Black",
                Artista = "Metallica",
                Album = "Black",
                Genero = "Heavy Metal",
                FechaLanzamiento = "1993",
                Duracion = "6:00"
            },
        };
        public TodasLasCanciones()
        {
            InitializeComponent();
            itemList.ItemsSource = lPrueba;
        }

        private void InfoCancionTabla_PlayClick(object sender, EventArgs e)
        {
            InfoCancionTabla infoCancionTabla = (InfoCancionTabla) sender ;
            //MessageBox.Show(infoCancionTabla.Artista);
        }
    }
}
