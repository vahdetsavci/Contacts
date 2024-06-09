using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts.Operation
{
    internal static class Helper
    {
        public static void dataGrdViewUpdate()
        {
            DataGridView dgw = (DataGridView)Application.OpenForms["ListContacts"].Controls["grd_list"];
            dgw.DataSource = new BusinessLogicLayer().GetContacts();
        }

        public static void TryCatch(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                NLog.Logger logger = NLog.LogManager.GetLogger("fileLogger");
                logger.Error(ex.Message);
            }
        }
    }
}
