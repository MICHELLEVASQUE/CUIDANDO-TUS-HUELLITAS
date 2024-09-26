namespace Loginproyectvet;

public partial class ReptilesAdopciones : ContentPage
{
    private readonly LocalDbService _dbService;
    public ReptilesAdopciones(LocalDbService dbService)
	{
        _dbService = dbService;
        InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormAdopciones(_dbService));
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormAdopciones(_dbService));
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormAdopciones(_dbService));
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FormAdopciones(_dbService));
    }
}