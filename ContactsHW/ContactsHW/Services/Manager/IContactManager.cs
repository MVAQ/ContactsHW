using ContactsHW.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ContactsHW.Services.Manager
{
    internal interface IContactManager
    {
        ObservableCollection<ContactModel> ContactList { get; set; }
        ContactModel contactModel { get; set; }

    }
}
