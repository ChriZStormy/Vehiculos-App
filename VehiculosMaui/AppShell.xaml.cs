using VehiculosMaui.Views;

namespace VehiculosMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
			Routing.RegisterRoute(nameof(RegistrarVehiculoPage), typeof(RegistrarVehiculoPage));
		}
    }
}
