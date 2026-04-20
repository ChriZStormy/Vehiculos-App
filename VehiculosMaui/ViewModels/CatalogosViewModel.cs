using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VehiculosMaui.Models;
using VehiculosMaui.Services;
using Microsoft.Maui.Controls;

namespace VehiculosMaui.ViewModels
{
    public class CatalogosViewModel : INotifyPropertyChanged
    {
        private readonly VehiculoApiService _apiService;
        public ObservableCollection<CatMarca> Marcas { get; set; }
        
        public ICommand CargarMarcasCommand { get; }

        public CatalogosViewModel()
        {
            _apiService = new VehiculoApiService();
            Marcas = new ObservableCollection<CatMarca>();
            CargarMarcasCommand = new Command(async () => await CargarMarcas());
        }

        public async Task CargarMarcas()
        {
            var marcasApi = await _apiService.GetMarcasAsync();
            Marcas.Clear();
            foreach (var m in marcasApi)
            {
                Marcas.Add(m);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
