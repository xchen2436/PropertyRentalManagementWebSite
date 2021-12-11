using System;
using System.Collections.Generic;

#nullable disable

namespace PropertyRentalManagementWebSite.Models
{
    public partial class Apartment
    {
        public Apartment()
        {
            AppointmentAssignments = new HashSet<AppointmentAssignment>();
        }

        public int ApartmentId { get; set; }
        public string ApartmentType { get; set; }
        public string ApartmentPrice { get; set; }
        public string ApartmentAddress { get; set; }

        public virtual ICollection<AppointmentAssignment> AppointmentAssignments { get; set; }
    }
}
