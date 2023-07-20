using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public byte UserStatusId { get; set; }


        public User(string name, string surname, string email, string username)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Username = username;
        }

        public ICollection<UserContact> UserContacts { get; set; }

        public void AddPassword(string password)
        {
            //TODO: password add logic
        }

        public UserContact AddUserContact(UserContact userContact)
        {
            //TODO : add user contact
            return null;
        }
    }
}
