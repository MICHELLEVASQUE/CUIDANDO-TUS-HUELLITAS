namespace Loginproyectvet.Pages;

public partial class SplashPage : ContentPage
{
    private readonly LocalDbService _dbService;
    public SplashPage(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
     
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage(_dbService));
    }
}