namespace Loginproyectvet.Pages;

public partial class SplashPage : ContentPage
{
    private readonly LocalDbService _dbService;
    public SplashPage(LocalDbService dbService)
	{
		InitializeComponent();
        StartSplashScreenTimer();
    }
    private async void StartSplashScreenTimer()
    {
        // Esperar 5 segundos
        await Task.Delay(10000);

        // Navegar a la p�gina de inicio de sesi�n (LoginPage)
        await Navigation.PushAsync(new LoginPage(_dbService));

        // Eliminar la SplashPage de la pila de navegaci�n
        Navigation.RemovePage(this);
    }
}