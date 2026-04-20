
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
	}
}
