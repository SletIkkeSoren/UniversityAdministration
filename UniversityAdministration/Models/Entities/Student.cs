using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityAdministration.Models.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName {get; set;}
        public string LastName { get; set; }
        public DateTime EnrollMentDate { get; set; }

        //Navigation properties
        //Når jeg læser en studerende vil jeg gerne se hvilke kurser han/hun er tilmeldt
        public ICollection<EnrollMent> EnrollMents{ get; set; }
    }
}
