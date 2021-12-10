using ContactsHW.Services.Settings;
using Prism.Mvvm;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsHW.ViewModel
{
    internal class HomePageViewModel : BindableBase
    {
        private ISettingsManager _settingsManager;
        public HomePageViewModel(ISettingsManager settingsManager)
            {
               _settingsManager = settingsManager;
            Count = _settingsManager.Count;
            }
        private int  _count;
        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value); 
        }

     protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            if(args.PropertyName == nameof(Count))
            {
                _settingsManager.Count = Count;
            }
        }
        public ICommand IncrementButtonTapCommand => new Command(OnIncrementButtonTap);

        private void OnIncrementButtonTap() 
        {
              Count++;
        }
        
    }
}
