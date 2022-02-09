using ContactsHW.Model;
using ContactsHW.Services.Repositorys;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsHW.ViewModel
{
    internal class SingUpViewModel : BindableBase
    {

        private DelegateCommand _navigateCommand;
        private UserRepository _repository;



        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public INavigationService NavigationService { get; }
        public SingUpViewModel(INavigationService navigationService, UserRepository repository)
        {
            NavigationService = navigationService;
            _repository = repository;
        }
        async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync("HomePage");
        }
        public ObservableCollection<UserModel> _userList;
        public ObservableCollection<UserModel> UserList
        {
            get => _userList;
            set => SetProperty(ref _userList, value);
        }
       public ICommand AddUserCommand => new Command(OnAddUserCommand);
        private async void OnAddUserCommand( object obj)
        {
            if (Login != null && ConfirmPassword == Password) {
            var User = new UserModel
            {
                Login = Login,
                UserName = UserName,
                Password = Password,
                CreateDate = DateTime.Now
            };
            var id = await _repository.InsertAsync(User);
            User.Id = id;
            
            UserList.Add(User);
            }
        }

     
        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        private string _password;
        public string Password
        {
            get => _password;        
            set => SetProperty(ref _password, value);
        }
        public async Task InitializeAsync(INavigationParameters parameters)
        {
            var userList = await _repository.GetAllAsync<UserModel>();
            UserList = new ObservableCollection<UserModel>(userList);
        }
    }
}
