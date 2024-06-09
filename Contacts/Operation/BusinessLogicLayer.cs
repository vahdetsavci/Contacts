using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Operation
{
    internal class BusinessLogicLayer
    {
        DataAccessLayer DAL;

        public BusinessLogicLayer()
        {
            DAL = new DataAccessLayer();
        }

        public int CheckUser(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                return DAL.CheckUser(new Entities.User()
                {
                    username = username,
                    password = password
                });
            }
            else
            {
                NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Log(NLog.LogLevel.Error, $"{DateTime.Now.ToString("D")} ERROR Missing parameter ");
                return -1;
            }
        }

        public int AddContact(string FirstName, string LastName, string PhoneI, string PhoneII, string PhoneIII, string EmailAddress, string WebAddress, string Address, string Description)
        {
            return DAL.AddContact(new Entities.Contact()
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneI = PhoneI,
                PhoneII = PhoneII,
                PhoneIII = PhoneIII,
                EmailAddress = EmailAddress,
                WebAddress = WebAddress,
                Address = Address,
                Description = Description
            });
        }

        public int EditContact(Guid ID, string FirstName, string LastName, string PhoneI, string PhoneII, string PhoneIII, string EmailAddress, string WebAddress, string Address, string Description)
        {
            return DAL.EditContact(new Entities.Contact()
            {
                ID = ID,
                FirstName = FirstName,
                LastName = LastName,
                PhoneI = PhoneI,
                PhoneII = PhoneII,
                PhoneIII = PhoneIII,
                EmailAddress = EmailAddress,
                WebAddress = WebAddress,
                Address = Address,
                Description = Description
            });
        }

        public int DeleteContact(Guid ID)
        {
            return DAL.DeleteContact(new Entities.Contact()
            {
                ID = ID
            });
        }

        public List<Entities.Contact> GetContacts()
        {
            List<Entities.Contact> contacts = new List<Entities.Contact>();
            Helper.TryCatch(() =>
            {
                SqlDataReader reader = DAL.GetContacts();
                while (reader.Read())
                {
                    contacts.Add(new Entities.Contact()
                    {
                        ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                        FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        LastName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        PhoneI = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        PhoneII = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        PhoneIII = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        EmailAddress = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        WebAddress = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Address = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Description = reader.IsDBNull(8) ? string.Empty : reader.GetString(8)
                    });
                }
                reader.Close();
            });
            DAL.SetConnection();
            return contacts;
        }
    }
}
