using Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Contacts.Operation
{
    internal class DataAccessLayer
    {
        SqlConnection connection;
        SqlCommand command;
        int result;

        public DataAccessLayer() => connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

        public void SetConnection()
        {
            switch (connection.State)
            {
                case System.Data.ConnectionState.Closed:
                    connection.Open();
                    break;
                default:
                    connection.Close();
                    break;
            }
        }

        public int CheckUser(User U)
        {
            Helper.TryCatch(() =>
            {
                command = new SqlCommand("CheckUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = U.username;
                command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = U.password;
                SetConnection();
                result = (int)command.ExecuteScalar();
            });
            SetConnection();
            return result;
        }

        public int AddContact(Contact C)
        {
            Helper.TryCatch(() =>
            {
                command = new SqlCommand("InsertContact", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar).Value = C.FirstName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar).Value = C.LastName;
                command.Parameters.Add("@PhoneI", System.Data.SqlDbType.VarChar).Value = C.PhoneI;
                command.Parameters.Add("@PhoneII", System.Data.SqlDbType.VarChar).Value = C.PhoneII;
                command.Parameters.Add("@PhoneIII", System.Data.SqlDbType.VarChar).Value = C.PhoneIII;
                command.Parameters.Add("@EmailAddress", System.Data.SqlDbType.VarChar).Value = C.EmailAddress;
                command.Parameters.Add("@WebAddress", System.Data.SqlDbType.VarChar).Value = C.WebAddress;
                command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar).Value = C.Address;
                command.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar).Value = C.Description;
                SetConnection();
                result = command.ExecuteNonQuery();
            });
            SetConnection();
            return result;
        }

        public int EditContact(Contact C)
        {
            Helper.TryCatch(() =>
            {
                command = new SqlCommand("UpdateContact", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@ID", System.Data.SqlDbType.UniqueIdentifier).Value = C.ID;
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar).Value = C.FirstName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar).Value = C.LastName;
                command.Parameters.Add("@PhoneI", System.Data.SqlDbType.VarChar).Value = C.PhoneI;
                command.Parameters.Add("@PhoneII", System.Data.SqlDbType.VarChar).Value = C.PhoneII;
                command.Parameters.Add("@PhoneIII", System.Data.SqlDbType.VarChar).Value = C.PhoneIII;
                command.Parameters.Add("@EmailAddress", System.Data.SqlDbType.VarChar).Value = C.EmailAddress;
                command.Parameters.Add("@WebAddress", System.Data.SqlDbType.VarChar).Value = C.WebAddress;
                command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar).Value = C.Address;
                command.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar).Value = C.Description;
                SetConnection();
                result = command.ExecuteNonQuery();
            });
            SetConnection();
            return result;
        }

        public int DeleteContact(Contact C)
        {
            Helper.TryCatch(() =>
            {
                command = new SqlCommand("DeleteContact", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@ID", System.Data.SqlDbType.UniqueIdentifier).Value = C.ID;
                SetConnection();
                result = command.ExecuteNonQuery();
            });
            SetConnection();
            return result;
        }

        public SqlDataReader GetContacts()
        {
            command = new SqlCommand("ListContacts", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SetConnection();
            return command.ExecuteReader();
        }
    }
}
