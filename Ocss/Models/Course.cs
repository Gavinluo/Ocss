using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Ocss.Models
{
    public partial class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
