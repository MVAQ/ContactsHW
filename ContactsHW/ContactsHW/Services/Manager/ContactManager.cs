using System;
using ContactsHW.Services.Manager;
using ContactsHW.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContactsHW.Services.Repository;
using System.Collections;
using System.IO;

public class ContactManager: IContactsManager
{
    private  ISettingsManager _settingsManager;
    private IRepository _reposytory;


    public ContactManager(ISettingsManager settingsManager, IRepository reposytory)
	{
        _settingsManager = settingsManager;
        _reposytory = reposytory;
    }

    public async Task<Contact> GetAllContactsAsync()
    {
        var IdCurrentUser = _settingsManager.IDUser;

        string SqlCommand = $"SELECT * FROM Contact WERE IDUser={IdCurrentUser}";
         
        var AllContactsCurrentUser = await _reposytory.FindWithCommandAsync<Contact>(SqlCommand);

        return AllContactsCurrentUser;
    }

    public async Task<Contact> DeleteContactsAsync(Contact contact)
    {
        if (File.Exists(contact.ContactImage))
        {
            File.Delete(contact.ContactImage);
        }
       await _reposytory.DeleteAsync(contact);

        return contact;
    }

       public async Task<Contact> SaveContactsAsync(Contact contact)
    {
        var CurrentContactToSave = contact;

        CurrentContactToSave.UserID = _settingsManager.IDUser;

        await _reposytory.InsertAsync(CurrentContactToSave);
     
        return CurrentContactToSave;
    }
}
