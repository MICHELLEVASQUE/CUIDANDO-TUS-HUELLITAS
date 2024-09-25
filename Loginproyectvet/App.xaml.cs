

using Loginproyectvet.Model;
using Loginproyectvet.Pages;

namespace Loginproyectvet
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SplashPage());
        }
    }
}
