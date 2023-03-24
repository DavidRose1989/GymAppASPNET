using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace Testing.Models
{
    public class Users
    {
        public int MID { get; set; }     

        public string Fname { get; set; }
        public string Lname { get; set; }

        public string Gender { get; set; }

        public string Dob { get; set; }

        public  string Mobile { get; set; }  
        
        public string Email { get; set; }

        public string JoinDate { get; set; }

        public string Gymtime { get; set; }

        public string Maddress { get; set; }

        public string MembershipPeriod { get; set; }

        public string NewEntry { get; set; }

        public List<string> NewEntryCategories { get; set; } = new List<string>() { "Month to Month", "3 Month", "6 Month", "12 Month" };
    }
}
