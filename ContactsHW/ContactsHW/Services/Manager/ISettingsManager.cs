using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsHW.Services.Manager
{
    public interface ISettingsManager
    {
       int IDUser { get; set; }
       void ChangeIDUser(int userId);
    }
}
