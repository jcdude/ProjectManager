using ProjectManagerBL.Email;
using ProjectManagerDAL.Entities;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerScheduler.Jobs
{
    class SendEmailJob : Job
    {
        public override string Name
        {
            get
            {
                return "SendEmail";
            }
        }

        public override string Schedule
        {
            get
            {
                return "0 0/2 8-17 * * ?";
            }
        }

        public override void Execute(IJobExecutionContext context)
        {
            using (var pMEntities = new ProjectManagerEntities())
            {
                var queuedEmails = from email in pMEntities.EmailQueues
                                   where (email.IsProcessed.HasValue?true:email.IsProcessed.Value) == true
                                   select new System.Net.Mail.MailMessage(email.FromAddress,email.ToAddress,email.Subject,email.Message);

                var emailSender = new OutGoingEmail(queuedEmails.ToList());
                emailSender.Send();
            }
        }
    }
}
