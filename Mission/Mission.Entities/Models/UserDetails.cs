using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Models
{
    public class UserDetails
    {
        public UserDetails(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            EmailAddress = user.EmailAddress;
            UserType = user.UserType;
        }

        // Add this empty constructor for JSON deserialization
        public UserDetails() { }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string UserType { get; set; }
    }
}