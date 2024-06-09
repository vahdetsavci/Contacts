using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Entities
{
    internal class User
    {
        public Guid ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
