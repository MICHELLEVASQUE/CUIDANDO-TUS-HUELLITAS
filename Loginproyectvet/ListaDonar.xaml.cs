namespace Loginproyectvet;

public partial class ListaDonar : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editDonarId;

    public ListaDonar(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        Task.Run(async () => listview.ItemsSource = await _dbService.GetDonar());
    }

    private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;

        var donarSeleccionada = (Donar)e.Item;

        var action = await DisplayActionSheet("Seleccione una opci�n", "Cancelar", null, "Editar", "Eliminar");

        switch (action)
        {
            case "Editar":
                // Navega a la p�gina de edici�n y pasa el registro seleccionado
                await Navigation.PushAsync(new Donacion(_dbService, donarSeleccionada));
                break;

            case "Eliminar":
                // Elimina el registro seleccionado
                await _dbService.Delete(donarSeleccionada);
                // Refresca la lista de expedientes
                listview.ItemsSource = await _dbService.GetDonar();
                break;
        }

        ((ListView)sender).SelectedItem = null;
    }
}