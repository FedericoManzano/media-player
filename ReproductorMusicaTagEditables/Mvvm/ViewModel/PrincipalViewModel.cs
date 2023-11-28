using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System.Windows;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class PrincipalViewModel:ReproductorViewModelBase
    {
        private string _cantidadCanciones = string.Empty;



        public PrincipalViewModel()
        {
            Irg.TitutloVentana = "Página Principal";
            CantidadCanciones = " (" + Irg.Canciones.Count + " Canciones)";
        }





        public string CantidadCanciones { get => _cantidadCanciones; set { _cantidadCanciones = value;OnPropertyChanged(nameof(CantidadCanciones)); } }
    }
}
