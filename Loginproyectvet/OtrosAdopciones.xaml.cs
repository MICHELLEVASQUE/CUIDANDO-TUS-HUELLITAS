namespace Loginproyectvet;

public partial class OtrosAdopciones : ContentPage
{
    private readonly LocalDbService _dbService;
    public OtrosAdopciones(LocalDbService dbService)
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
}