using System;
using System.Collections;
using ContactsHW.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

public interface IContactsManager
{
	Task<Contact> GetAllContactsAsync();
	Task<Contact> SaveContactsAsync(Contact contact);
	Task<Contact> DeleteContactsAsync(Contact contact);


}
