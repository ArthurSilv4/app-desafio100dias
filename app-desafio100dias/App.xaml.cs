using System.Globalization;

namespace app_desafio100dias
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var culture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            MainPage = new AppShell();
        }
    }
}
