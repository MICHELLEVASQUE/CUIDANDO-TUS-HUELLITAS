using Loginproyectvet.Model;

namespace Loginproyectvet.Pages;

public partial class LoginPage : ContentPage
{
    private readonly LocalDbService _dbService;
    private UserDatabase _userDatabase;
    private UserDatabase userDatabase;

    public LoginPage(LocalDbService dbService)
	{
		InitializeComponent();
        
        _userDatabase = new UserDatabase();

        





    }

    public LoginPage(UserDatabase userDatabase)
    {
        this.userDatabase = userDatabase;
    }

    private async void OnLogin_Clicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        var user = await _userDatabase.GetUserAsync(username, password);
        if (user != null)
        {
            await DisplayAlert("Success", "Login successful!", "OK");
            // Navega a la página principal de la app si el login es exitoso

            await Navigation.PushAsync(new Menu(_dbService));
        }
        else
        {
            await DisplayAlert("Error", "Invalid username or password", "OK");
        }

    }

    private async void OnRegister_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new RegistrarPage(_dbService));

    }

}