using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Linq.Expressions;
using MailKit.Net;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Net.Imap;


namespace login
{
    internal class mailServer
    {
        //connect to Imap server using mailkit imap
        public bool testEmail(string Email, string Password, string Server)
        {

            using (var client = new ImapClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(Server, 993, true);
                client.Authenticate(Email, Password);


                if (client.IsAuthenticated == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        
    }
}
