using VehiculosMaui.ViewModels;

namespace VehiculosMaui.Views;

public partial class DetalleVehiculoPage : ContentPage
{
	public DetalleVehiculoPage()
	{
		InitializeComponent();
		BindingContext = new DetalleVehiculoViewModel();
	}
}