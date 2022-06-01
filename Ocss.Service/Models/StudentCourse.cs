using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Ocss.Service.Models
{
    public partial class StudentCourse
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
