using BarcodeScanner.Repositories;
using Xamarin.Forms;

namespace BarcodeScanner
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<BarcodeRepository>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
