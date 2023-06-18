using System;
using System.Collections.Generic;

namespace SampelEnitityFramework_DatabaseFirst.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public int? StudentId { get; set; }
    }
}
