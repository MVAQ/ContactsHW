

using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using ContactsHW.View;
using ContactsHW.ViewModel;
using ContactsHW.Services.Settings;


namespace ContactsHW
{
    public partial class App : PrismApplication
    {
        public App()
        {

        }
        #region ---- Ovverides----
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Services
            containerRegistry.RegisterInstance<ISettingsManager>(Container.Resolve<SettingsManager>());
            //Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();  
        }

        protected override void OnInitialized()
        { 
            InitializeComponent();
            NavigationService.NavigateAsync($"{nameof(HomePage)}");
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
        #endregion
    }
}
