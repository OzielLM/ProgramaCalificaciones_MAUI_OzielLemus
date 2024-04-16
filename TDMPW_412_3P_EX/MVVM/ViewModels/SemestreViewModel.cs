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
    public class SemestreViewModel
    {
        public Semestre Semestre { get; set; }
        public ICommand cmdCalCularCalificacionSemestral { get; }
        public ICommand cmdReiniciarValores { get; }

        public SemestreViewModel()
        {
            Semestre = new Semestre();
            cmdCalCularCalificacionSemestral = new Command(() =>
            {
                if (string.IsNullOrEmpty(Semestre.NombreMateria))
                {

                    App.Current.MainPage.DisplayAlert("Campo vacío.", "Revisa el campo del nombre de la materia.", "OK");
                }
                else
                {
                    float sumaPorcentajesDeCadaParcial = Semestre.ValorParcial1 + Semestre.ValorParcial2 + Semestre.ValorParcial3;

                    if ((sumaPorcentajesDeCadaParcial == 100) && (Semestre.CalificacionParcial1 >= 0 && Semestre.CalificacionParcial1 <= 10) && (Semestre.CalificacionParcial2 >= 0 && Semestre.CalificacionParcial2 <= 10))
                    {
                        if(Semestre.CalificacionParcial1 < 6 && Semestre.CalificacionParcial2 < 6)
                        {
                            Semestre.CalificacionParcial3Necesaria6 = (6 - (Semestre.CalificacionParcial1 * (Semestre.ValorParcial1 / 100) + (Semestre.CalificacionParcial2 * (Semestre.ValorParcial2 / 100)))) / (Semestre.ValorParcial3 / 100);
                            Semestre.CalificacionParcial3Necesaria10 = (10 - (Semestre.CalificacionParcial1 * (Semestre.ValorParcial1 / 100) + Semestre.CalificacionParcial2 * (Semestre.ValorParcial2 / 100))) / (Semestre.ValorParcial3 / 100);
                        }
                        else
                        {
                            Semestre.CalificacionParcial3Necesaria10 = (10 - (Semestre.CalificacionParcial1 * (Semestre.ValorParcial1 / 100) + Semestre.CalificacionParcial2 * (Semestre.ValorParcial2 / 100))) / (Semestre.ValorParcial3 / 100);
                        }
                        

                        if (Semestre.CalificacionParcial3Necesaria10 > 10)
                        {
                            App.Current.MainPage.DisplayAlert("Ya no alcanzas el 10.", $"Diste lo mejor de ti no hay porque ponerse tristes, se te mostrara la calificación que tendrías que sacar para obtener un 10 --> {Semestre.CalificacionParcial3Necesaria10} .", "OK");
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert("FELICIDADES", "Esoooo, Sigue manteniendo asi, felicidades", "OK");
                        }
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("ERROR.", "Revisa que el valor de los porcentajes sumen 100 y que el valor de los campos de calificación sea un número entre 0 y 10.", "OK");
                    }
                }
            });

            cmdReiniciarValores = new Command(() =>
            {
                Semestre.NombreMateria = "";
                Semestre.ValorParcial1 = 0;
                Semestre.ValorParcial2 = 0;
                Semestre.ValorParcial3 = 0;
                Semestre.CalificacionParcial1 = 0;
                Semestre.CalificacionParcial2 = 0;
                Semestre.CalificacionParcial3Necesaria6 = 0;
                Semestre.CalificacionParcial3Necesaria10 = 0;
            });
        }
    }
}
