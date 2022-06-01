using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Ocss.Service.Models
{
    public partial class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentPassword { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
