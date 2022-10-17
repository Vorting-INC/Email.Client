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
using Org.BouncyCastle.Asn1.X509;


namespace login
{
    public partial class Form2 : Form
    {
      
        public Form2()
        {
            
            InitializeComponent();
        
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string email = Form1.saveEmail;
        string password = Form1.savePassword;
        string server = Form1.saveServer;

        private void button1_Click(object sender, EventArgs e)
        {
            

            using (var client = new ImapClient())
            {
                client.Connect(server, 993, true);
                client.Authenticate(email, password);

                //retrieve last email from server
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                var message = inbox.Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId).FirstOrDefault();
                var from = message.Envelope.From.ToString();
                var body = message.TextBody;
                var subject = message.Envelope.Subject;
                MessageBox.Show("From " + from + "\n Subject: " + subject + "\n Body: " + body);

                
                  
            }

          
        }

        async void RetrieveFolders()
        {
            using (var client = new ImapClient())
            {
                await client.ConnectAsync(server, 993, true);
                await client.AuthenticateAsync(email, password);

                //retrieve last email from server
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                //fetch all email from server
                


            }
        }

        //make a list of the email on the server using mailkit imap
        private void button4_Click(object sender, EventArgs e)
        {
            using (var client = new ImapClient())
            {
                client.Connect(server, 993, true);
                client.Authenticate(email, password);

                //retrieve last email from server
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                //fetch all email from server
                var message = inbox.Fetch(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId);
                foreach (var item in message)
                {
                    var from = item.Envelope.From.ToString();
                    var body = item.Body;
                    var subject = item.Envelope.Subject;
                    MessageBox.Show("From " + from + "\n Subject: " + subject + "\n Body: " + body);
                }
            }
        }

        


        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select the item click on in the listbox
 listBox1.Items.Add("test");

        }
        
    //adds an object to the listbox
           
    }
}
