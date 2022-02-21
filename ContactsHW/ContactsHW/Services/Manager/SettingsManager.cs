using System;
using System.Collections.Generic;
using System.Text;
using ContactsHW.Constants;
using Xamarin.Essentials;

namespace ContactsHW.Services.Manager
{
    public class SettingsManager: ISettingsManager
    {
        public int IDUser 
        {
            get => Preferences.Get(nameof(IDUser), Constants.ConstantValue.DEFAULT_IDUSER);
            set => Preferences.Set(nameof(IDUser), value);
         }

        public void ChangeIDUser(int userId)
        {
           Preferences.Set(nameof(IDUser), userId);
        }
    }
}
