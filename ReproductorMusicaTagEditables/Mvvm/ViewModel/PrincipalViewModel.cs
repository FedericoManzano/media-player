using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class PrincipalViewModel:ReproductorViewModelBase
    {
        private static double _scrollVertical = 0;

        public PrincipalViewModel()
        {
            Irg.TitutloVentana = "Página Principal";
        }

        public double ScrollVertical { get => _scrollVertical; set => _scrollVertical = value; }
    }
}
