namespace TDMPW_412_3P_EX.MVVM.Views;

public partial class Bienvenida : FlyoutPage
{
	public Bienvenida()
	{
		InitializeComponent();
	}

	private void aMateria(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Materia());
	}

	private void aSemestre(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Semestre());
	}
}