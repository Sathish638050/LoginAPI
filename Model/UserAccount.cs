using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAuthenticationAPI.Model
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            Answers = new HashSet<Answer>();
            CourseEnrolls = new HashSet<CourseEnroll>();
            Courses = new HashSet<Course>();
            Fees = new HashSet<Fee>();
            Questions = new HashSet<Question>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string UserImage { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
