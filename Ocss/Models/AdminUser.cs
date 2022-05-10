using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Ocss.Models
{
    public partial class AdminUser
    {
        public string AdminId { get; set; }
        public string AdminPassword { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
