using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsHW.Services.Authorization
{
    public interface IAuthorization
    {
        void LogOut();
        bool IsLoggedIn();

    }
}
