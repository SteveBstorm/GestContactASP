using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Telephone { get; set; }
    }
}
