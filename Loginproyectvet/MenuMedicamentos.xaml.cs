namespace Loginproyectvet;

public partial class MenuMedicamentos : ContentPage
{
    private readonly LocalDbService _dbService;
    public MenuMedicamentos(LocalDbService dbService)
	{
        _dbService = dbService;
        InitializeComponent();
	}

    private void MenuButton_Clicked(object sender, EventArgs e)
    {

        Menupanel.IsVisible = !Menupanel.IsVisible;
    }

    private async void Categoria_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Opcion1(_dbService));
       
    }

    private async void Opcion1_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Opcion2(_dbService));
       
    }

    private async void Opcion2_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Opcion3(_dbService));
  
    }

    private void Menubutton_Clicked_1(object sender, EventArgs e)
    {
        Menupanel.IsVisible = !Menupanel.IsVisible;
    }
}