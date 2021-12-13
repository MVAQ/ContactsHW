
using Prism.Mvvm;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Collections.ObjectModel;
using ContactsHW.Model;
using ContactsHW.Services.Repositorys;
using Prism.Navigation;
using System.Threading.Tasks;

namespace ContactsHW.ViewModel
{
   
    internal class HomePageViewModel : BindableBase, IInitializeAsync
    {
        private IRepository _repository;
        public HomePageViewModel(IRepository repository)
        {
            _repository = repository;
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName; 
            set => SetProperty(ref _lastName, value); 
        }
          
        private ContactModel _selectedItem;
        public ContactModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        } 

        public ObservableCollection<ContactModel> _contactsList;
        public ObservableCollection<ContactModel> ContactsList
        {
            get => _contactsList;
            set => SetProperty(ref _contactsList, value);
        }

        #region ---PUBLIC --- 
   
        public async Task InitializeAsync(INavigationParameters parameters)
        {
            var contactList = await _repository.GetAllAsync<ContactModel>();
            ContactsList = new ObservableCollection<ContactModel>(contactList);
        }
        #endregion

        public ICommand AddButtonTapCommand => new Command(OnAddButtonTap);
        public ICommand DeleteTapComand => new Command(OnDeleteTap);
        public ICommand UpdateTapComand => new Command(OnUpdateTap);

        #region --- PRIVATE HELPERS --- 
        private async void OnAddButtonTap(object obj)
        {

            var Contact = new ContactModel
            { 
                FirstName = FirstName,
                LastName = LastName,
                CreationTime = DateTime.Now
             };
            var id = await _repository.InsertAsync(Contact);
            Contact.Id = id;

            ContactsList.Add(Contact);
        }
        private async void OnDeleteTap()
        {

            if (SelectedItem != null)
            {
                await _repository.DeleteAsync(SelectedItem);
                ContactsList.Remove(SelectedItem);
            }
        }
        private async void OnUpdateTap()
        {

            if (SelectedItem != null)
            {
                var contact = new ContactModel()
                {
                    Id = SelectedItem.Id,
                    FirstName = FirstName,
                    LastName = LastName,
                    CreationTime = DateTime.Now
                };
                var index = ContactsList.IndexOf(SelectedItem);
                ContactsList.Remove(SelectedItem);
                await _repository.UpdateAsync(contact);
                ContactsList.Insert(index, contact);
              
            }
        }

        #endregion

        #region ---OVERRIDES --- 


        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            if (args.PropertyName == nameof(SelectedItem))
            {
                FirstName = SelectedItem.FirstName;
                LastName = SelectedItem.LastName;
            }
        }


        #endregion
        #region ---  --- 
        #endregion
    }
} 
