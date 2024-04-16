namespace TDMPW_412_3P_EX.MVVM.Views;
using TDMPW_412_3P_EX.MVVM.ViewModels;

public partial class Materia : ContentPage
{
	public Materia()
	{
		InitializeComponent();
		BindingContext = new MateriaViewModel();
	}
}