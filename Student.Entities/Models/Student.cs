using System;
using System.Collections.Generic;

#nullable disable

namespace Student.Entities.Models
{
    public partial class Student
    {
        public decimal Id { get; set; }
        public int Age { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
       
    }
}
