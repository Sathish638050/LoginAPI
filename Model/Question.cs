using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAuthenticationAPI.Model
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string Question1 { get; set; }
        public int UserId { get; set; }

        public virtual UserAccount User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
