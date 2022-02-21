using Acr.UserDialogs;
using ContactsHW.Model;
using ContactsHW.Services.Authentication;
using ContactsHW.Services.Manager;
using ContactsHW.View;
using ContactsHW.ViewModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsHW.ViewModel
{
    public class SingUpViewModel : BaseViewModel
    {
        private IAuthentication _authentication;

        #region -- Public Properties --

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

   //     public ICommand SignUpCommand => new Command(OnSignUpTap);

        #endregion

        public SingUpViewModel(INavigationService navigationService, IUserDialogs userDialogs,
            IAuthentication authentication, ISettingsManager settingsManager) : base(navigationService, userDialogs, settingsManager)
        {
            _authentication = authentication;
        }

        #region -- Private Helpers --

/*private async void OnSignUpTap()
{
    bool isLoginValid = Validator.IsLoginValid(Login);
    bool isPasswrodValid = Validator.IsPasswordValid(Password, ConfirmPassword);

    if (isLoginValid && isPasswrodValid)
    {
        var signUpResult = await _authentication.SingUpAsync(Login, Password);

        if (signUpResult)
        {
            var user = new User { Login = Login, Password = Password };

            await UserDialogs.AlertAsync(Resources["RedirectingToSignIn"], Resources["SuccessfullRegistration"], Resources["Ok"]);

            var parameters = new NavigationParameters
            {
                {"login", user.Login }
            };
            await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(SingIn)}", parameters);
        }

        else
        {
            await UserDialogs.AlertAsync(Resources["LoginIsTaken"], Resources["SignUp"], Resources["Ok"]);
        }
    }

    else
    {
        await UserDialogs.AlertAsync(Validator.alert, Resources["SignUp"], Resources["Ok"]);
    }
}*/


#endregion
}

}
