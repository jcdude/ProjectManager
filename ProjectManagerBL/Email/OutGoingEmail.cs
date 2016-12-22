using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerBL.Email
{
    public class OutGoingEmail
    {
        private ProjectManagerEntities PMEntities;

        private System.Net.Mail.SmtpClient client;
        private IList<System.Net.Mail.MailMessage> mails;

        private readonly string EmailHost = "smtp.gmail.com";
        private readonly string EmailUsername = "jedfletcher1@gmail.com";
        private readonly string EmailPassword = "57738703";
        private readonly int EmailPort = 465;

        public static readonly string EmailSystem = "jedfletcher1@gmail.com";

        public OutGoingEmail(string emailSentFromAddress, string email, string subject, string message)
        {
            this.Initialize();

            mails = new List<System.Net.Mail.MailMessage>();

            // Create the message:
            var mail = new System.Net.Mail.MailMessage(emailSentFromAddress, email);
            mail.Subject = subject;
            mail.Body = message;

            mails.Add(mail);
        }

        public OutGoingEmail(IList<System.Net.Mail.MailMessage> emails)
        {
            this.Initialize();

            mails = emails;
        }

        private void Initialize()
        {
            PMEntities = new ProjectManagerEntities();

            // Configure the client:
            client = new System.Net.Mail.SmtpClient(this.EmailHost);

            client.Port = this.EmailPort;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            // Creatte the credentials:
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(this.EmailUsername, this.EmailPassword);
            client.EnableSsl = true;
            client.Credentials = credentials;
        }

        public System.Threading.Tasks.Task Send()
        {
            foreach (var mail in this.mails)
            {
                this.client.SendAsync(mail, "emailSent");
            }
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public System.Threading.Tasks.Task Queue()
        {
            foreach (var mail in this.mails)
            {
                this.PMEntities.EmailQueues.Add(new EmailQueue()
                {
                    FromAddress = mail.From.Address,
                    ToAddress = mail.To.FirstOrDefault().Address,
                    Subject = mail.Subject,
                    Message = mail.Body,
                    DateCreated = DateTime.Now
                });
            }

            this.PMEntities.SaveChangesAsync();
            return System.Threading.Tasks.Task.FromResult(0);
        }
    }
}
