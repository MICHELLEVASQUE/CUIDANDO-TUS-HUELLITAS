namespace Loginproyectvet;

public partial class ListaCitas : ContentPage
{
    private int _editCitaId;


    private readonly LocalDbService _dbService;

    public ListaCitas(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;

        Task.Run(async () => listview.ItemsSource = await _dbService.GetCita());
    }

    private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;

        var citaSeleccionado = (Citas)e.Item;

        // Muestra opciones para editar o eliminar
        var action = await DisplayActionSheet("Seleccione una opción", "Cancelar", null, "Editar", "Eliminar");

        switch (action)
        {
            case "Editar":
                // Navega a la página de edición y pasa el registro seleccionado
                await Navigation.PushAsync(new CitasProgramadas(_dbService, citaSeleccionado));
                break;

            case "Eliminar":
                // Elimina el registro seleccionado
                await _dbService.Delete(citaSeleccionado);
                // Refresca la lista de expedientes
                listview.ItemsSource = await _dbService.GetCita();
                break;
        }

    // Deselecciona el elemento
    ((ListView)sender).SelectedItem = null;

    }
}