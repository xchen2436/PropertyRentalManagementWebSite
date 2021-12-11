using System;
using System.Collections.Generic;

#nullable disable

namespace PropertyRentalManagementWebSite.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            AppointmentAssignments = new HashSet<AppointmentAssignment>();
        }

        public int TenantId { get; set; }
        public string TenantUsername { get; set; }
        public string TenantPassword { get; set; }
        public string TenantFirstName { get; set; }
        public string TenantLastName { get; set; }
        public string TenantEmail { get; set; }
        public string TenantPhonenumber { get; set; }

        public virtual ICollection<AppointmentAssignment> AppointmentAssignments { get; set; }
    }
}
