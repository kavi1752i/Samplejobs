using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace EmailSample
{
     public class EmailSender
    {
       
            string gmailAppPassword = "miyi tnsh aogk yyvi";
            string fromAddress = "kaviyarasi.nallathambi@gmail.com";
            string toAddress = "kaviyarasi1702@gmail.com";
            string mailsubject = "Default";
            string mailBody = "Default";

        public EmailSender(string from, string to, string password, string subject, string body)
        {
            fromAddress = from;
            toAddress = to;
            gmailAppPassword = password;
            mailsubject = subject;
            mailBody = body;


        }
        public void SendEmail()
            { 

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromAddress);
                    mail.To.Add(toAddress);
                    mail.Subject = mailsubject;
                    mail.Body = mailBody;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com",587))
                    {
                        smtp.Credentials = new NetworkCredential(fromAddress, gmailAppPassword);
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;

                        smtp.Send(mail);
                        Console.WriteLine("email sent successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to send email:" + ex.Message);
            }
        }
    }
}
