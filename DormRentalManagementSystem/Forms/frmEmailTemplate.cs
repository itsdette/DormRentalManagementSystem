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
using System.Globalization;

namespace DormRentalManagementSystem.Forms
{
    public partial class frmEmailTemplate : Form
    {
        frmWarning warning = new frmWarning();
        Class.myDatabase database = new Class.myDatabase();
        Class.ComboBox combo = new Class.ComboBox();
        string toAddress, subject, body, smtpServer, smtpUsername, smtpPassword, currentDate, currentTime;
        int smtpPort;

        private string initialBodyText = "Dear [tenant's name],\r\n\r\nGood day! \r\n\r\nI would like to inform you that the amount you have to pay for your rent is [amount] where the due date is on  [date]. I will be expecting your payment until the said date and a week after that.  \r\n\r\nI hope you pay the rent as soon as you can. Thank you!\r\n\r\nYours sincerely,\r\n\r\n[name]";
        private string initialSubjectText = "Request For Rent Payment";

        public frmEmailTemplate()
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

        private void frmEmailTemplate_Load(object sender, EventArgs e)
        {
            timer1_Tick(this, EventArgs.Empty);
            txtboxMessage.Text = initialBodyText;
            txtboxSubject.Text = initialSubjectText;
            // Assuming you have a TextBox named txtBody
            txtboxMessage.ScrollBars = ScrollBars.Both;

            comboBoxRecipient.DataSource = combo.email();
            comboBoxRecipient.DisplayMember = "EmailAddress";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                 toAddress = comboBoxRecipient.Text.Trim();
                 subject = txtboxSubject.Text.Trim();
                 body = txtboxMessage.Text.Trim();

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


                // Get the current date and time as strings
                 currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                 currentTime = DateTime.Now.ToString("HH:mm:ss");


                warning.lblWarn.Text = "Email sent successfully!";
                warning.ShowDialog();
                // MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                warning.lblWarn.Text = "Email sent unsuccessfully";
                warning.ShowDialog();
                //MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

