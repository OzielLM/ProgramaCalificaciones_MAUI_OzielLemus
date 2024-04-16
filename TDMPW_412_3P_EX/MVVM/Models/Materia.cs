using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace TDMPW_412_3P_EX.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Materia
    {
        public string Nombre { get; set; }
        public string Rubro1 { get; set; }
        public string Rubro2 { get; set; }
        public string Rubro3 { get; set; }
        public float ValorRubro1 { get; set; }
        public float ValorRubro2 { get; set; }
        public float ValorRubro3 { get; set; }
        public float CalificacionRubro1 { get; set; }
        public float CalificacionRubro2 { get; set; }
        public float CalificacionRubro3 { get; set; }
        public float CalificacionFinal { get; set; }

        public Materia() { }
    }
}
