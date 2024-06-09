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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new LoginForm() { MdiParent = this }.Show();
        }

        private void newContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["NewContact"] != null)
                Application.OpenForms["NewContact"].Focus();
            else
                new NewContact() { MdiParent = this }.Show();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ListContacts"] != null)
                Application.OpenForms["ListContacts"].Focus();
            else
                new ListContacts() { MdiParent = this }.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
