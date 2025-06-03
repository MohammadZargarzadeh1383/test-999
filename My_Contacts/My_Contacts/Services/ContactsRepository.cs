using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_Contacts.Reposetory;
using System.Data.SqlClient;

namespace My_Contacts.Services
{
    class ContactsRepository : IContactsReposetory
    {
        private string connectionString = "Data Source=MAHSA;Initial Catalog=Contacts_DB;Integrated Security=true";

        public bool Delete(int ContactID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string Name, string Family, string Mobile, string Email, string Adress)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string query = "Select * From My_Contacts";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                try
                {
                    connection.Open();
                    adapter.Fill(data);
                    return data;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public DataTable SelectRow(int ContactID)
        {
            throw new NotImplementedException();
        }

        public bool Update(int ContactID, string Name, string Family, string Mobile, string Email, string Adress)
        {
            throw new NotImplementedException();
        }
    }
}