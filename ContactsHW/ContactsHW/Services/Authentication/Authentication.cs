using ContactsHW.Model;
using ContactsHW.Services.Manager;
using ContactsHW.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsHW.Services.Authentication
{
    public class Authentication: IAuthentication
    {
       private IRepository _reposytory;
       private ISettingsManager _settingManager;

        public async Task <bool> SingInAsync(string login, string password)
        {
            bool singInValue = false;
            string sqlCommand= $"SELECT * FROM Users WHERE Login='{login}' AND Password='{password}'";
            User user = await _reposytory.FindWithCommandAsync<User>(sqlCommand);
            if(user.Id != 0)
            {
                _settingManager.ChangeIDUser(user.Id);
                return singInValue = true; 
            }
                return singInValue;
            
        }

        public async Task<bool> SingUpAsync(string login, string password)
        {
            bool singUpValue = false;
            string sqlCommand = $"SELECT * FROM Users WHERE Login='{login}' AND Password='{password}'";
            User user = await _reposytory.FindWithCommandAsync<User>(sqlCommand);
            if (user.Id == 0)
            {
                  user = new User()
                {
                    Login = login,
                    Password = password
                };
                await _reposytory.InsertAsync(user);
                singUpValue = true;
            }
            return singUpValue;
        }
    }
}
