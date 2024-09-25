using Microsoft.Win32;

namespace Loginproyectvet;

public partial class ListaExpedientes : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editExpedienteId;
    public ListaExpedientes(LocalDbService dbService)
    {
        InitializeComponent();

        _dbService = dbService;

        Task.Run(async () => listview.ItemsSource = await _dbService.GetRegistros());
    }
    private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;

        var registroSeleccionado = (Registro)e.Item;

        // Muestra opciones para editar o eliminar
        var action = await DisplayActionSheet("Seleccione una opción", "Cancelar", null, "Editar", "Eliminar");

        switch (action)
        {
            case "Editar":
                // Navega a la página de edición y pasa el registro seleccionado
                await Navigation.PushAsync(new Expedientes(_dbService, registroSeleccionado));
                break;

            case "Eliminar":
                // Elimina el registro seleccionado
                await _dbService.Delete(registroSeleccionado);
                // Refresca la lista de expedientes
                listview.ItemsSource = await _dbService.GetRegistros();
                break;
        }

    // Deselecciona el elemento
    ((ListView)sender).SelectedItem = null;


    }

}