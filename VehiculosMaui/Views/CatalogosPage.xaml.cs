using Microsoft.Maui.Controls;
using VehiculosMaui.ViewModels;

namespace VehiculosMaui.Views;

public partial class CatalogosPage : ContentPage
{
	public CatalogosPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext is CatalogosViewModel viewModel)
		{
			viewModel.CargarMarcasCommand.Execute(null);
		}
	}
}