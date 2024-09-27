namespace Loginproyectvet.Pages;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
        
	}

   

 

    private async void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());

    }

    private async void TapGestureRecognizer_Tapped_4(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }


}