using System;
using System.Collections.Generic;

namespace Herz.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Packet { get; set; }
        public int IdMonter { get; set; }
    }
}
