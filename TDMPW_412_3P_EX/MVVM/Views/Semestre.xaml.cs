namespace TDMPW_412_3P_EX.MVVM.Views;
using TDMPW_412_3P_EX.MVVM.ViewModels;

public partial class Semestre : ContentPage
{
	public Semestre()
	{
		InitializeComponent();
		BindingContext = new SemestreViewModel();
	}
}