
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class RegalosViewModel : ReproductorViewModel, IRecolector.IRecolector
    {
        private static readonly string[] MESES =
        {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"
        };

        private Dictionary<string, List<RegalosRep>> _dicRegalosRep = new Dictionary<string, List<RegalosRep>>();

        private ObservableCollection<RegalosRep> _ListadoRegalosRep = new ObservableCollection<RegalosRep>();
        public ObservableCollection<RegalosRep> ListadoRegalosRep
        {
            get => _ListadoRegalosRep;
            set
            {
                _ListadoRegalosRep = value;
                OnPropertyChanged(nameof(ListadoRegalosRep));
            }
        }

        private Dictionary<string, bool> _paginador = new Dictionary<string, bool>();
        public Dictionary<string, bool> Paginador { get => _paginador; set { _paginador = value; OnPropertyChanged(nameof(Paginador)); } }




        public void CargarRegalos(Dictionary<string, List<Cancion>> dic)
        {
          
            if (!dic.Any())
            {
                return;
            }
            string primerAno = AnoString(dic.Keys.First());
            foreach (var e in dic.Keys)
            {
                string ano = AnoString(e);
                if (_dicRegalosRep.ContainsKey(ano))
                {
                    _dicRegalosRep[ano].Add(GenerarRegalo(dic, e));
                }
                else
                {
                    _dicRegalosRep[ano] = new List<RegalosRep>() { GenerarRegalo(dic, e) };
                }
                Paginador[ano] = false;
            }
            ListadoRegalosRep = new ObservableCollection<RegalosRep>(_dicRegalosRep[primerAno]);
        }

        private RegalosRep GenerarRegalo(Dictionary<string,List<Cancion>> dic, string key)
        {
            List<Cancion> listadoCanciones = dic[key];
            if(listadoCanciones != null && listadoCanciones.Any())
            {
                RegalosRep r = new RegalosRep()
                {
                    Nombre = FormatearNombre(key) + " " + AnoString(key),
                    Imagen1 = DameImagen(0, listadoCanciones),
                    Imagen2 = DameImagen(1, listadoCanciones),
                    Imagen3 = DameImagen(2,listadoCanciones),
                    Imagen4 = DameImagen(3, listadoCanciones),
                    Color = "Red"
                };
                return r;
            }
            return new RegalosRep();
        }

        private ImageBrush DameImagen(int index, List<Cancion> listado)
        {
            if(listado == null)
                return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
            if (index >= listado.Count || index < 0)
                return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
            return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(listado[index].Path);
        }


        private string FormatearNombre (string k)
        {
            string mes = MesString(k);
            switch(mes)
            {
                case "1": return MESES[0];
                case "2": return MESES[1];
                case "3": return MESES[2];
                case "4": return MESES[3];
                case "5": return MESES[4];
                case "6": return MESES[5];
                case "7": return MESES[6];
                case "8": return MESES[7];
                case "9": return MESES[8];
                case "10": return MESES[9];
                case "11": return MESES[10];
                case "12": return MESES[11];
                default: return "0";
            }
        } 


        private string AnoString(string fecha)
        {
            if (string.IsNullOrEmpty(fecha))
                return "1600";
            if(Regex.IsMatch(fecha, "^([0-9]{2}-[0-9]{4})$"))
            {
                return fecha.Split('-')[1];
            }
            return "1600";
        }

        private string MesString(string fecha)
        {
            if (string.IsNullOrEmpty(fecha))
                return "0";
            if (Regex.IsMatch(fecha, "^([0-9]{2}-[0-9]{4})$"))
            {
                return fecha.Split('-')[0];
            }
            return "0";
        }

        public void Limpiar()
        {
            _dicRegalosRep.Clear();
            ListadoRegalosRep.Clear();
            Paginador.Clear();
            System.GC.Collect();
        }
    }
}
