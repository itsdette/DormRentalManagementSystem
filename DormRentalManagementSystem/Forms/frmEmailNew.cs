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
using MySql.Data.MySqlClient;

namespace DormRentalManagementSystem.Forms
{
    public partial class frmEmailNew : Form
    {
        frmWarning warning = new frmWarning();
        Class.myDatabase database = new Class.myDatabase();
        Class.ComboBox combo = new Class.ComboBox();
        string toAddress, subject, body, smtpServer, smtpUsername, smtpPassword;
        int smtpPort;
        public frmEmailNew()
        {
            InitializeComponent();
        }

        public frmWarning frmWarning
        {
            get => default;
            set
            {
            }
        }

        internal Class.ComboBox ComboBox
        {
            get => default;
            set
            {
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                 toAddress = comboBoxRecipient.Text.Trim();
                 subject = txtboxSubject.Text.Trim();
                 body = txtboxMessage.Text.Trim();
                DateTime dateTime = DateTime.Now; // Get the current date and time

                // Set your email credentials and SMTP server information
                 smtpServer = "smtp.gmail.com";
                 smtpUsername = "tominiovernadette@gmail.com";
                 smtpPassword = "frcv veas asam dozd";
                 smtpPort = 587; // Change this to the appropriate port for your SMTP server

                // Create a new MailMessage and set its properties
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(smtpUsername);
                mailMessage.To.Add(toAddress);
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                // Create a new SmtpClient and set its properties
                SmtpClient smtpClient = new SmtpClient(smtpServer);
                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                // Send the email
                smtpClient.Send(mailMessage);

                // Save the email details to the database
             //   SaveEmailData(toAddress, subject, body, dateTime);

                warning.lblWarn.Text = "Email sent successfully!";
                warning.ShowDialog();
            }
            catch (Exception ex)
            {
                warning.lblWarn.Text = "Email sent unsuccessfully";
                warning.ShowDialog();
                // Handle the exception, e.g., log or display an error message
            }
        }

        private void frmEmailNew_Load(object sender, EventArgs e)
        {
            comboBoxRecipient.DataSource = combo.email();
            comboBoxRecipient.DisplayMember = "EmailAddress";
        }
    }
}
