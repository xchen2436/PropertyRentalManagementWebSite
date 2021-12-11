using System;
using System.Collections.Generic;

#nullable disable

namespace PropertyRentalManagementWebSite.Models
{
    public partial class AppointmentAssignment
    {
        public int AssignmentId { get; set; }
        public int? ManagerId { get; set; }
        public int? TenantId { get; set; }
        public int? ApartmentId { get; set; }
        public DateTime? Date { get; set; }
        public string NoteMessage { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
