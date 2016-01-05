using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        public OrderViewModel()
        {
            AddMenuItemCommand = new DelegateCommand(AddMenuItem);
            SubmitOrderCommand = new DelegateCommand(SubmitOrder);
            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;
        }

        private List<MenuItem> _menuItems;

        public List<MenuItem> MenuItems {
            get
            { return _menuItems; }
            set
            {
                if (value != this._menuItems)
                {
                    this._menuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private MenuItem _selectedMenuItem;

        public  MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                NotifyPropertyChanged();
            }
        }

        public DelegateCommand AddMenuItemCommand { get; private set; }

        public DelegateCommand SubmitOrderCommand { get; private set; }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; private set; }

        public void AddMenuItem()
        {
            this.CurrentlySelectedMenuItems.Add(this.SelectedMenuItem);
        }

        public void SubmitOrder()
        {
            base.Repository.Orders.Add(
                new Order
                {
                    Items = this.CurrentlySelectedMenuItems.ToList(),
                    Table = base.Repository.Tables.First(),
                    Expedite = false
                }
            );
            this.CurrentlySelectedMenuItems.Clear();

            new MessageDialog("Order sent.").ShowAsync();
        }


    }
}
