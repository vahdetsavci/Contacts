using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Entities
{
    internal class Contact
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneI { get; set; }
        public string PhoneII { get; set; }
        public string PhoneIII { get; set; }
        public string EmailAddress { get; set; }
        public string WebAddress { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
