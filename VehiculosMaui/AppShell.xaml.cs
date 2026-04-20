using VehiculosMaui.Views;

namespace VehiculosMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
			Routing.RegisterRoute(nameof(RegistrarVehiculoPage), typeof(RegistrarVehiculoPage));
			Routing.RegisterRoute(nameof(ListaVehiculosPage), typeof(ListaVehiculosPage));
			Routing.RegisterRoute(nameof(DetalleVehiculoPage), typeof(DetalleVehiculoPage));
			Routing.RegisterRoute(nameof(EditarVehiculoPage), typeof(EditarVehiculoPage));
			Routing.RegisterRoute(nameof(HistorialMantenimientosPage), typeof(HistorialMantenimientosPage));
			Routing.RegisterRoute(nameof(ReporteFallaPage), typeof(ReporteFallaPage));
			Routing.RegisterRoute(nameof(CatalogosPage), typeof(CatalogosPage));
		}
    }
}
