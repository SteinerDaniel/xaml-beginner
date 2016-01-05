using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {       
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        private List<MenuItem> _MenuItems;

        public List<MenuItem> MenuItems {
            get
            { return _MenuItems; }
            set
            {
                if (value != this._MenuItems)
                {
                    this._MenuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<MenuItem> _CurrentlySelectedMenuItems;

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems {
            get
            { return _CurrentlySelectedMenuItems; }
            set
            {
                if (value != this._CurrentlySelectedMenuItems)
                {
                    this._CurrentlySelectedMenuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
