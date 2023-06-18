using System;
using System.Collections.Generic;

namespace SampelEnitityFramework_DatabaseFirst.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCorses = new HashSet<StudentCorse>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Brithdate { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<StudentCorse> StudentCorses { get; set; }
    }
}
