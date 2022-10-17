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


namespace login
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //function that send an email using smtp 
            string email = Form1.saveEmail;
            string password = Form1.savePassword;
            string server = Form1.saveServer;
            string to = textBox1.Text;
            string subject = textBox3.Text;
            string body = textBox2.Text;
            
            sendEmail(email, password, to, server, subject, body);
            this.Close();

        }



        public bool sendEmail(string email, string password, string to,string server, string subject, string body)
       
        {
            try
            {
                //send an email to an gmail from an gmail using .Net.Email
                MailMessage mail = new MailMessage(email, to);
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);

                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = email,
                    Password = password
                };

                smtpClient.EnableSsl = true;


                smtpClient.Send(mail);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("email could not send");
                return false;
            }
        }

    private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
