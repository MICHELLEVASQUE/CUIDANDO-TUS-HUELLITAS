using Loginproyectvet.Model;

namespace Loginproyectvet.Pages;

public partial class RegistrarPage : ContentPage
{
    private readonly LocalDbService _dbService;
    private UserDatabase _userDatabase;
    public RegistrarPage(LocalDbService dbService)
	{
		InitializeComponent();
        _userDatabase = new UserDatabase();
    }

    private async void Regresar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnRegister_Clicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Por favor,rellene todos los campos", "OK");
            return;
        }

        var user = new User
        {
            Username = username,
            Password = password
        };

        await _userDatabase.SaveUserAsync(user);
        await DisplayAlert("¡Registro Exitoso!","Ya tiene una cuenta para que ingreses a nuestra app", "OK");

        await Navigation.PushAsync(new LoginPage(_dbService));
    }
}