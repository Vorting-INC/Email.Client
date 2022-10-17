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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        
        public static string saveEmail = "";
        public static string savePassword = "";
        public static string saveServer = "";

        //connect to Imap server using mailkit imap
        private bool testEmail(string Email, string Password, string Server)
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

        //button that log in to your email using testEmail
        private void button1_Click(object sender, EventArgs e)
        {
            //saves tekst from user interface to send to next window
            saveEmail = textBox1.Text;
            savePassword = textBox2.Text;
            saveServer = textBox3.Text;
            
            //log in, if true open new window else login failed
            if (testEmail(saveEmail,savePassword,saveServer))     
            {
                //open form2 and close form1
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Login Failed");
            } 
        }
     // Exit button for closin application
        private void button2_Click(object sender, EventArgs e)

        {
            this.Close();

        }
        //admin login for testing purpose
        private void button3_Click(object sender, EventArgs e)
                {
                    saveEmail = "askvorting@outlook.com";
                    savePassword = "Askhv007";               
                    saveServer = "imap-mail.outlook.com";
                    //log in
                    if (testEmail(saveEmail, savePassword, saveServer))
                    {
                        //open form2 and close form1
                        Form2 f2 = new Form2();
                        f2.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }
                }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
        
    }
}
