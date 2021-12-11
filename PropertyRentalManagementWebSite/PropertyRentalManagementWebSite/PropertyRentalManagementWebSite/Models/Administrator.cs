using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PropertyRentalManagementWebSite.Models
{
    public class Administrator
    {
        [Required(AllowEmptyStrings = false)]
        public int AdminId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string AdminUsername { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string AdminPassword { get; set; }
    }
}
