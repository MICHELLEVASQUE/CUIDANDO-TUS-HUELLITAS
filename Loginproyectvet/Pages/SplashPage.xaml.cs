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

        // Navegar a la página de inicio de sesión (LoginPage)
        await Navigation.PushAsync(new LoginPage(_dbService));

        // Eliminar la SplashPage de la pila de navegación
        Navigation.RemovePage(this);
    }
}