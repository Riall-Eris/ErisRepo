using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eris.Helper
{
    public class EMessage
    {
        public EMessage()
        {
 
        }

        public static DialogResult Show(string text, string Caption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            FormMessage frm = new FormMessage(text, Caption, messageBoxButtons, messageBoxIcon);
            return frm.ShowDialog();
        }

        public static DialogResult Show(string text, string Caption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon, List<MessageEntity> Lst)
        {
            FormMessageData frm = new FormMessageData(text, Caption, messageBoxButtons, messageBoxIcon, Lst);
            return frm.ShowDialog();
        }

        public static DialogResult Show(string text, string Caption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon, List<Eris.Entity.WareErrorEntity> Lst)
        {
            FormWareMessage frm = new FormWareMessage(text, Caption, messageBoxButtons, messageBoxIcon, Lst);
            return frm.ShowDialog();
        }
    }

    public class MessageEntity
    {
        public MessageEntity() { }

        /// <summary>
        /// 1= White, 2= Red, 3= Green, 4= Orange, 5= Blue
        /// </summary>
        public int Color { get; set; }

        public string ERCode { get; set; }
        public string ERTitle { get; set; }
        public string ERDesc { get; set; }
    }
}