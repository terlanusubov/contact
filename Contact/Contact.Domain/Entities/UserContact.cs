using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.Entities
{
    public class UserContact : Entity
    {
        public int UserId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public User User { get; set; }


        public UserContact(string name, string surname, string phone, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }


        public void ConnectToUser(int userId)
        {
            UserId = userId;
        }
    }
}
