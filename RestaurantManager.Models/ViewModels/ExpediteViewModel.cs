using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models.ViewModels
{
    public class ExpediteViewModel : ExpediteDataManager
    {
        public string SpecialRequests { get; set; }

        public Table Table { get; set; }

        public bool Complete { get; set; }

        public bool Expedite { get; set; }

        public List<Order> OrderItem { get; set; }
    }
}
