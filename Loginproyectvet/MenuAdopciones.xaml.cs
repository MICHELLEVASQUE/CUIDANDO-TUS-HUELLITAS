namespace Loginproyectvet;

public partial class MenuAdopciones : ContentPage
{
    private readonly LocalDbService _dbService;
    public MenuAdopciones(LocalDbService dbService)
	{
        _dbService = dbService;
        InitializeComponent();
	}

    private void MenuButton_Clicked(object sender, EventArgs e)
    {
        Menupanel.IsVisible = !Menupanel.IsVisible;
    }

    private async void CANINOS_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CaninosAdopciones(_dbService));
    }

    private async void FELINOS_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FelinosAdopciones(_dbService));
    }

    private async void REPTILES_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReptilesAdopciones(_dbService));
    }

    private async void OTROS_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OtrosAdopciones(_dbService));
    }

    private void Menubutton_Clicked_1(object sender, EventArgs e)
    {
        Menupanel.IsVisible = !Menupanel.IsVisible;
    }
}
