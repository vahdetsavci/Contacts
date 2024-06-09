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
    public partial class LoginForm : Form
    {
        BusinessLogicLayer BLL;

        public LoginForm()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            int result = BLL.CheckUser(txt_username.Text, txt_password.Text);
            if (result > 0)
            {
                MenuStrip menuStrip = (MenuStrip)(Application.OpenForms["MainForm"]).Controls["menuStrip1"];
                menuStrip.Items[0].Enabled = true;
                menuStrip.Items[1].Enabled = true;
                Close();
            }
            else if (result == -1)
                MessageBox.Show("Lütfen alanları eksiksiz olarak doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Kullanıcı adı veya şifreniz yanlış!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
