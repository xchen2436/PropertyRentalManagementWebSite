using System;
using System.Collections.Generic;

#nullable disable

namespace PropertyRentalManagementWebSite.Models
{
    public partial class Manager
    {
        public Manager()
        {
            AppointmentAssignments = new HashSet<AppointmentAssignment>();
        }

        public int ManagerId { get; set; }
        public string ManagerUsername { get; set; }
        public string ManagerPassword { get; set; }
        public string Message { get; set; }

        public virtual ICollection<AppointmentAssignment> AppointmentAssignments { get; set; }
    }
}
