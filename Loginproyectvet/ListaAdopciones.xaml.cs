namespace Loginproyectvet;

public partial class ListaAdopciones : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editFormAdopcionesId;
    public ListaAdopciones(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
        Task.Run(async () => listview.ItemsSource = await _dbService.GetRegistroAdopciones());
    }

    private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;

        var especieseleccionada = (RegistroAdopciones)e.Item;

        var action = await DisplayActionSheet("Seleccione una opción", "Cancelar", null, "Editar", "Eliminar");

        switch (action)
        {
            case "Editar":
                // Navega a la página de edición y pasa el registro seleccionado
                await Navigation.PushAsync(new FormAdopciones(_dbService, especieseleccionada));
                break;

            case "Eliminar":
                // Elimina el registro seleccionado
                await _dbService.Delete(especieseleccionada);
                // Refresca la lista de expedientes
                listview.ItemsSource = await _dbService.GetRegistroAdopciones();
                break;
        }

          ((ListView)sender).SelectedItem = null;
    }

}