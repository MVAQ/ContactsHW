using ContactsHW.Model;
using ContactsHW.Services.Repositorys;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContactsHW.ViewModel
{
    internal class MainListViewModel:BindableBase
    {
        private IRepository _repository;
        public MainListViewModel(IRepository repository)
        {
            _repository=repository;
            ObservableCollection<ContactModel> ContactList = new ObservableCollection<ContactModel>()
            {
            new ContactModel()
            {
                FirstName="Vasya",
                 LastName = "Fedorov",
                  CreationTime= DateTime.Now,
                    UserID=1
            }
            };
        }
    }
}
