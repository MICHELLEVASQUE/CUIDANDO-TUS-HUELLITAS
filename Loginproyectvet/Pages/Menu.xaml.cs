
namespace Loginproyectvet.Pages;

public partial class Menu : ContentPage
{
    private readonly LocalDbService _dbService;
    public Menu(LocalDbService dbService)
	{
        _dbService = dbService;
        InitializeComponent();

	}

    private async void citas_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CitasProgramadas(_dbService));
    }

    private async void Registros_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Expedientes(_dbService));
    }

    private async void hospitalizacion_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Hospitalizacion(_dbService));
    }

    private async void farmacia_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new MenuMedicamentos(_dbService));
    }

    private async void adopciones_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new MenuAdopciones(_dbService));
    }

    private async void donaciones_Tapped(object sender, TappedEventArgs e)
    {
       
    }
}





