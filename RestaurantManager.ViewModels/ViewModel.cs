using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }

        public ViewModel()
        {
            LoadData();
        }

        private bool isLoading;

        public bool IsLoading
        {
            get
            {
                return isLoading;
            }

            set
            {
                isLoading = value;
                NotifyPropertyChanged();
            }
        }

        private async void LoadData()
        {
            IsLoading = true;
            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            IsLoading = false;
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
