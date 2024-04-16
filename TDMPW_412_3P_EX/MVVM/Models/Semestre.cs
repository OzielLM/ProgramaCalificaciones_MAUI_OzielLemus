using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace TDMPW_412_3P_EX.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Semestre
    {
        public string NombreMateria { get; set; }
        public float ValorParcial1 { get; set; }
        public float ValorParcial2 { get; set; }
        public float ValorParcial3 { get; set; }
        public float CalificacionParcial1 { get; set; }
        public float CalificacionParcial2 { get; set; }
        public float CalificacionParcial3Necesaria6 { get; set; }
        public float CalificacionParcial3Necesaria10 { get; set; }

        public Semestre() { }
    }
}
