using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAuthenticationAPI.Model
{
    public partial class Contact
    {
        public int CId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
