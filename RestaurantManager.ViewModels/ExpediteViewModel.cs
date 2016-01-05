using System;
using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            NotifyPropertyChanged("OrderItems");
        }

        public List<Order> OrderItems
        {
            get { return base.Repository?.Orders; }
        }
    }
}
