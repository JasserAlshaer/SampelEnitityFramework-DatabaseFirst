using System;
using System.Collections.Generic;

namespace SampelEnitityFramework_DatabaseFirst.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCorses = new HashSet<StudentCorse>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }

        public virtual ICollection<StudentCorse> StudentCorses { get; set; }
    }
}
