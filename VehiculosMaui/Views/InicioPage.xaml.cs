
using Microsoft.Maui.Controls;

namespace VehiculosMaui.Views
{
	public partial class InicioPage : ContentPage
	{
		public InicioPage()
		{
			InitializeComponent();
		}
		private async void OnVehiculosClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync(nameof(ListaVehiculosPage));
		}
		private async void OnMantenimientosClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync(nameof(HistorialMantenimientosPage));
		}
		private async void OnReportesClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync(nameof(ReporteFallaPage));
		}
		private async void OnCatalogosClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync(nameof(CatalogosPage));
		}
	}
}
