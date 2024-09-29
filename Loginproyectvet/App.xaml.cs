

using Loginproyectvet.Model;
using Loginproyectvet.Pages;

namespace Loginproyectvet
{
    public partial class App : Application
    {
        


        public App()
        {
            InitializeComponent();

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Citas.db3");
            var dbService = new LocalDbService(dbPath);

            // Configura la navegación inicial con la página de lista de expedientes
            MainPage = new NavigationPage(new SplashPage(dbService));

        }
    }
}
