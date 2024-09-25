namespace Loginproyectvet.Pages;

public partial class SplashPage : ContentPage
{
	public SplashPage()
	{
		InitializeComponent();
        StartSplashScreenTimer();
    }
    private async void StartSplashScreenTimer()
    {
        // Esperar 5 segundos
        await Task.Delay(10000);

        // Navegar a la página de inicio de sesión (LoginPage)
        await Navigation.PushAsync(new LoginPage());

        // Eliminar la SplashPage de la pila de navegación
        Navigation.RemovePage(this);
    }
}