using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAuthenticationAPI.Model
{
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
            CourseEnrolls = new HashSet<CourseEnroll>();
            Fees = new HashSet<Fee>();
            Topics = new HashSet<Topic>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }

        public virtual UserAccount User { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
