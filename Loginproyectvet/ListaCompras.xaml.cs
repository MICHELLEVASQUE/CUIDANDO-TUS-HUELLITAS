namespace Loginproyectvet;

public partial class ListaCompras : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editFormComprasId;
    public ListaCompras(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
        Task.Run(async () => listview.ItemsSource = await _dbService.GetCompraProductos());
    }

    private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;

        var mascotaSeleccionada = (CompraProductos)e.Item;

        var action = await DisplayActionSheet("Seleccione una opción", "Cancelar", null, "Editar", "Eliminar");

        switch (action)
        {
            case "Editar":
                // Navega a la página de edición y pasa el registro seleccionado
                await Navigation.PushAsync(new FormCompras(_dbService, mascotaSeleccionada));
                break;

            case "Eliminar":
                // Elimina el registro seleccionado
                await _dbService.Delete(mascotaSeleccionada);
                // Refresca la lista de expedientes
                listview.ItemsSource = await _dbService.GetCompraProductos();
                break;
        }

  ((ListView)sender).SelectedItem = null;
    }
}