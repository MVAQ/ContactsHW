using ContactsHW.Model;
using ContactsHW.Services.Repository;
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
            ObservableCollection<Contact> ContactList = new ObservableCollection<Contact>()
            {
            new Contact()
            {
                FirstName="Vasya",
                 LastName = "Chernov",
                  CreationTime= DateTime.Now,
                    UserID=1
            }
            };
        }
    }
}
