using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ContactsHW.Model;
using ContactsHW.Services.Manager;
using ContactsHW.Services.Repositorys;
using Prism.Mvvm;

namespace ContactsHW.Services.Manager
{
    internal class ContactManager: BindableBase
    {
        private Repository _reposytory;

        public ObservableCollection<ContactModel> ContactList { get; set; }
        public ContactModel contactModel { get ; set ; }

       
        public ContactManager(Repository repository)
        {
           _reposytory= repository;
        }


      
    }
}
