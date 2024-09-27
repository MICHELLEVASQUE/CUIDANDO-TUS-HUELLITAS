namespace Loginproyectvet;

public partial class Opcion3 : ContentPage
{
    private readonly LocalDbService _dbService;
    public Opcion3(LocalDbService dbService)
	{
        _dbService = dbService;
        InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormCompras(_dbService));
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormCompras(_dbService));
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormCompras(_dbService));
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormCompras(_dbService));
    }

    private async void Button_Clicked_4(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormCompras(_dbService));
    }

    private async void Button_Clicked_5(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormCompras(_dbService));
    }
}