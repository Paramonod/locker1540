using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testapp
{
    public interface IMessageService
    {
        void ShowMessage(string message);
    }
    public class MessageService : IMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
