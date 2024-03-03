using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoContact
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        String strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
      
        protected void txtSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                sendemail();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO message ([name],[email],[phone],[subject],[message]) VALUES(@name,@email,@phone,@subject,@message)", con);
                com.Parameters.AddWithValue("@name", name.Text.Trim());
                com.Parameters.AddWithValue("@email", email.Text.Trim());
                com.Parameters.AddWithValue("@phone", phone.Text.Trim());
                com.Parameters.AddWithValue("@subject", subject.Text.Trim());
                com.Parameters.AddWithValue("@message", message.Text.Trim());
                com.ExecuteNonQuery();
                con.Close();
                name.Text = "";
                email.Text = "";
                message.Text = "";
                phone.Text = "";
                subject.Text = "";

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;


            }
        }
        private void sendemail()
        {
            String smtpUserName;
            String smtpPassword;
            MailMessage mail = new MailMessage();
            SmtpClient smtp_Client = new SmtpClient(System.Configuration.ConfigurationSettings.AppSettings["smtpClient"]);

            smtpUserName = System.Configuration.ConfigurationSettings.AppSettings["smtpUserName"];
            smtpPassword = System.Configuration.ConfigurationSettings.AppSettings["smtpPassword"];
            mail.From = new MailAddress(smtpUserName);
            mail.To.Add(email.Text.Trim());
            mail.Subject = "your Subject";
            mail.Body = ("Name: " + name.Text.Trim() + " Email: " + email.Text.Trim() + "Message: " + message.Text.Trim());
            smtp_Client.Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["smtpPort"]);
            smtp_Client.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
            smtp_Client.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationSettings.AppSettings["enableSSL"]);
            smtp_Client.Send(mail);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
}