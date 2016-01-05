using System;
using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
        }

        private List<Order> _OrderItems;

        public List<Order> OrderItems
        {
            //get { return base.Repository.Orders; }
            get { return _OrderItems; }
            set
            {
                if (value != _OrderItems)
                {
                    _OrderItems = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
