using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace FileManagmentSystem.Services
{
    public class EmailService
    {
        public User User { get; set; }
        private readonly string body;
        private const string subject = "Registration File Management System";

        public EmailService(User user)
        {
            this.User = user;
            body = "Registration successfully made click on the link to change password! http://localhost:11626/ChangePassword/ChangePassword/?UserId=" + user.Id + "&" + "OldPassword=" + this.User.Password;
        }

        public void SendRegistrationEmail()
        {
            var fromEmail = new MailAddress(WebConfigurationManager.AppSettings["Email"], "Zhivko Milev");
            var toEmail = new MailAddress(this.User.Email, string.Format("{0} {1}", this.User.FirstName, this.User.LastChangedOn));

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, WebConfigurationManager.AppSettings["EmailPassword"])
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }

    }
}
