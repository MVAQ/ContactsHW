using System;
using Xamarin.Essentials;

namespace ContactsHW.Services.Settings
{
    public class SettingsManager:ISettingsManager
    {
        public int Count
        {
            get => Preferences.Get(nameof(Count),0);
            set => Preferences.Set(nameof(Count), value);
        }
    }
}
