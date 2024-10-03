using Loginproyectvet.Model;

namespace Loginproyectvet.Pages;

public partial class LoginPage : ContentPage
{
    private readonly LocalDbService _dbService;
    private UserDatabase _userDatabase;

    public LoginPage(LocalDbService dbService)
	{
		InitializeComponent();
        
        _userDatabase = new UserDatabase();
        _dbService = dbService;

    }

    public LoginPage(UserDatabase userDatabase)
    {
        this._userDatabase = userDatabase;
    }

    private async void OnLogin_Clicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        var user = await _userDatabase.GetUserAsync(username, password);
        if (user != null)
        {
            await DisplayAlert("¡Inicio de sesion exitoso!", "Disfruta de nuestros servicios hacia tus patitas", "OK");
            // Navega a la página principal de la app si el login es exitoso

            await Navigation.PushAsync(new Menu(_dbService));
        }
        else
        {
            await DisplayAlert("Error", "Nombre de usuario o contraseña no son validos", "OK");
        }

    }

    private async void OnRegister_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new RegistrarPage(_dbService));

    }

}