using Contacts.Entities;
using Contacts.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts.Forms
{
    public partial class EditContact : Form
    {
        BusinessLogicLayer BLL;
        internal Contact contact;

        public EditContact(Guid ID)
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
            contact = BLL.GetContacts().Find(I => I.ID == ID);
        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            txt_firstName.Text = contact.FirstName;
            txt_lastName.Text = contact.LastName;
            txt_phoneI.Text = contact.PhoneI;
            txt_phoneII.Text = contact.PhoneII;
            txt_phoneIII.Text = contact.PhoneIII;
            txt_emailAddress.Text = contact.EmailAddress;
            txt_webSite.Text = contact.WebAddress;
            txt_address.Text = contact.Address;
            txt_description.Text = contact.Description;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int result = BLL.EditContact(contact.ID, txt_firstName.Text, txt_lastName.Text, txt_phoneI.Text, txt_phoneII.Text, txt_phoneIII.Text, txt_emailAddress.Text, txt_webSite.Text, txt_address.Text, txt_description.Text);
            if (result > 0)
            {
                Helper.dataGrdViewUpdate();
                MessageBox.Show("Kişi güncellendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Kişi düzenleme esnasında bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int result = BLL.DeleteContact(contact.ID);
            if (result > 0)
            {
                Helper.dataGrdViewUpdate();
                MessageBox.Show("Kişi silindi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Kişi silinme esnasında bir hata oluştu!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
