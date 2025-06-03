using My_Contacts.Reposetory;
using My_Contacts.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace My_Contacts
{
    public partial class Form1 : Form
    {
        IContactsReposetory repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.SelectAll();
        }
    }
}
