using VehiculosMaui.ViewModels;

namespace VehiculosMaui.Views;

public partial class ListaVehiculosPage : ContentPage
{
	private ListaVehiculosViewModel _viewModel;

	public ListaVehiculosPage()
	{
		InitializeComponent();
		_viewModel = new ListaVehiculosViewModel();
		BindingContext = _viewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.CargarVehiculos();
	}
}