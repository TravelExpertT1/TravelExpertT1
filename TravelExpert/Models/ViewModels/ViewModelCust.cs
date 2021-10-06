using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpert.Models;

namespace TravelExpert.Models
{
    public class ViewModelCustBook
    {
        
        public Booking booking { get; set; }
        public Package package { get; set; }




        /*public List<Incident> Incidents { get; set; }
        public Incident Incident { get; set; }

        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }

        public List<Product> Products { get; set; }
        public Product Product { get; set; }

        public List<Technician> Technicians { get; set; }
        public Technician Technician { get; set; }

        public Incident SelectedIncident { get; set; }

        public string SelectedIncident2 { get; set; }
        public string CheckActiveIncident(string incident) =>
            incident == SelectedIncident2 ? "active" : "";
        */
    }
}
