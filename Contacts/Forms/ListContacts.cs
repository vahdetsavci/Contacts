using Contacts.Forms;
using Contacts.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts
{
    public partial class ListContacts : Form
    {
        BusinessLogicLayer BLL;

        public ListContacts()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void ListContacts_Load(object sender, EventArgs e)
        {
            grd_list.DataSource = BLL.GetContacts();
            grd_list.Columns[0].Visible = false;
        }

        private void grd_list_DoubleClick(object sender, EventArgs e)
        {
            Guid id = Guid.Parse(grd_list.SelectedRows[0].Cells[0].Value.ToString());
            if (Application.OpenForms["EditContact"] != null)
                Application.OpenForms["EditContact"].Close();

                new EditContact(id) { MdiParent = Application.OpenForms["MainForm"] }.Show();
        }
    }
}
