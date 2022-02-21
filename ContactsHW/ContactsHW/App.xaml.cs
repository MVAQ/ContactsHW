using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using ContactsHW.View;
using ContactsHW.ViewModel;
using ContactsHW.Services.Repository;
using ContactsHW.Services.Manager;
using ContactsHW.Services.Authorization;
using ContactsHW.Services.Authentication;
using System;

namespace ContactsHW
{
public partial class App
{
    private IAuthorization _authorization;
    public IAuthorization Authorization =>
        _authorization ?? (_authorization = Container.Resolve<IAuthorization>());
    public App( ) {}

 
    #region -- Overrides --

    protected override async void OnInitialized()
    {
        InitializeComponent();
     // var AuthorizationIf = _authorization.IsLoggedIn();
      //if (AuthorizationIf)
       //{
         // await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(SingIn)}");
       //}
       //else
       //{
          await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(SingUp)}");
      // }
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        //Services
        containerRegistry.RegisterInstance<IRepository>(Container.Resolve<Repository>());
        containerRegistry.RegisterInstance<IAuthentication>(Container.Resolve<Authentication>());
        containerRegistry.RegisterInstance<IImgManager>(Container.Resolve<ImgManager>());
        containerRegistry.RegisterInstance<ISettingsManager>(Container.Resolve<SettingsManager>());
        containerRegistry.RegisterInstance<IAuthorization>(Container.Resolve<Authorization>());


        //Navigation
        containerRegistry.RegisterForNavigation<NavigationPage>();
        containerRegistry.RegisterForNavigation<MainListView, MainListViewModel>();
        containerRegistry.RegisterForNavigation<SingIn, SingInViewModel>();
        containerRegistry.RegisterForNavigation<SingUp, SingUpViewModel>();
    }

    #endregion
}
}
