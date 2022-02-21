using ContactsHW.Services.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using ContactsHW.Constants;

namespace ContactsHW.Services.Authorization
{
    internal class Authorization : IAuthorization
    {
        private ISettingsManager _settingsManager;
        public ISettingsManager SettingsManager;
        
        
        public Authorization(ISettingsManager _settingsManager)
        {
         SettingsManager = _settingsManager;

        }


        public bool IsLoggedIn()
        {
            if (_settingsManager.IDUser >= 0) { return true; }
            return false;
        }

        public void LogOut()
        {
            _settingsManager.ChangeIDUser(ConstantValue.DEFAULT_IDUSER);  
        }
    }
}
