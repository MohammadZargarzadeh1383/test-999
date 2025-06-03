using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace My_Contacts.Reposetory
{
    interface IContactsReposetory

    {
        DataTable SelectAll();
        DataTable SelectRow(int ContactID);
        bool Delete(int ContactID);
        bool Insert(string Name, string Family, string Mobile, string Email, string Adress);
        bool Update(int ContactID, string Name, string Family, string Mobile, string Email, string Adress);
    }
}
