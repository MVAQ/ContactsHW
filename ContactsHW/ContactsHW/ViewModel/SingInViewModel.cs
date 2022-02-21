using Acr.UserDialogs;
using Prism.Navigation;
using ContactsHW.Services.Authentication;
using ContactsHW.Services.Manager;
using ContactsHW.View;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsHW.ViewModel
{
    public class SingInViewModel : BaseViewModel
    {
        private IAuthentication _authentication;

        #region -- Public Properties -- 

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public ICommand SignUpCommand => new Command(OnSignUpTap);
        public ICommand SignInCommand => new Command(OnSignInTap);

        #endregion

        public SingInViewModel(INavigationService navigationService, IUserDialogs userDialogs,
            IAuthentication authenticationService, ISettingsManager settingsManager
            ) : base(navigationService, userDialogs, settingsManager)
        {
            _authentication = authenticationService;
           
        }


        #region -- Overrides --

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            parameters.TryGetValue("login", out string login);

            if (login != null)
            {
                Login = login;
            }
        }

        #endregion

        #region -- Private Helpers --

        private async void OnSignUpTap()
        {
            await NavigationService.NavigateAsync($"{nameof(SingUp)}");
        }

        private async void OnSignInTap()
        {
            var signInResult = await _authentication.SingInAsync(Login, Password);

            if (signInResult)
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainListView)}");
            }
          //  else
            //{
            //    await UserDialogs.AlertAsync(Resources["LoginPasswordWrong"], Resources["ErrorLoginPassword"], Resources["Ok"]);
            //}
        }

        #endregion
    }
}