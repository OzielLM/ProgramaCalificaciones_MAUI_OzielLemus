using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using TDMPW_412_3P_EX.MVVM.Models;
using System.Windows.Input;

namespace TDMPW_412_3P_EX.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MateriaViewModel
    {
        public Materia Materia { get; set; }
        public ICommand cmdCalcularResultado { get; }
        public ICommand cmdReiniciarCampos { get; }

        public MateriaViewModel()
        {
            Materia = new Materia();
            cmdCalcularResultado = new Command(() =>
            {
                if(string.IsNullOrEmpty(Materia.Nombre) || string.IsNullOrEmpty(Materia.Rubro1) || string.IsNullOrEmpty(Materia.Rubro2) || string.IsNullOrEmpty(Materia.Rubro3))
                {
                    App.Current.MainPage.DisplayAlert("ATENCION", "Campos vacios, revise los campos, puede que te haya faltado uno","OK");
                }
                else
                {
                    float sumaDePorcentajes = Materia.ValorRubro1 + Materia.ValorRubro2 + Materia.ValorRubro3;
                    if(sumaDePorcentajes == 100 && ((Materia.CalificacionRubro1 >= 0) && (Materia.CalificacionRubro1 <= 10)) && ((Materia.CalificacionRubro2 >= 0) && (Materia.CalificacionRubro2 <= 10)) && ((Materia.CalificacionRubro3 >= 0) && (Materia.CalificacionRubro3 <= 10)))
                    {
                        float calificacionTotalPrimerRubro = (Materia.ValorRubro1 / 100) * Materia.CalificacionRubro1;
                        float calificacionTotalSegundoRubro = (Materia.ValorRubro2 / 100) * Materia.CalificacionRubro2;
                        float calificacionTotalTercerRubro = (Materia.ValorRubro3 / 100) * Materia.CalificacionRubro3;

                        float sumaDeLasTresCalificacionRubros = calificacionTotalPrimerRubro + calificacionTotalSegundoRubro + calificacionTotalTercerRubro;
                        Materia.CalificacionFinal = sumaDeLasTresCalificacionRubros;
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("ERROR", "Porcentajes invalidos, los porcentajes tienen que sumar 100 y/o las calificaciones deben ir del 0 al 10, por favor revisa tus valores", "OK");
                    }
                }
            });

            cmdReiniciarCampos = new Command(() =>
            {
                Materia.Nombre = "";
                Materia.Rubro1 = "";
                Materia.Rubro2 = "";
                Materia.Rubro3 = "";
                Materia.ValorRubro1 = 0;
                Materia.ValorRubro2 = 0;
                Materia.ValorRubro3 = 0;
                Materia.CalificacionRubro1 = 0;
                Materia.CalificacionRubro2 = 0;
                Materia.CalificacionRubro3 = 0;
                Materia.CalificacionFinal = 0;
            });
        }
    }
}
