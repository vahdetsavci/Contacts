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
    public partial class NewContact : Form
    {
        BusinessLogicLayer BLL;

        public NewContact()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int result = BLL.AddContact(txt_firstName.Text, txt_lastName.Text, txt_phoneI.Text, txt_phoneII.Text, txt_phoneIII.Text, txt_emailAddress.Text, txt_webSite.Text, txt_address.Text, txt_description.Text);
            if (result > 0)
            {
                if (Application.OpenForms["ListContacts"] != null)
                    Helper.dataGrdViewUpdate();

                MessageBox.Show("Kişi eklendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Kişi ekleme esnasında bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
