using System;
using System.Collections.Generic;

#nullable disable

namespace PropertyRentalManagementWebSite.Models
{
    public partial class Administrator
    {
        public int AdminId { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
    }
}
