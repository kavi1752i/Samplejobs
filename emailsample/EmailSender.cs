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
        public void SendEmail()
        {
            string gmailAppPassword = "miyi tnsh aogk yyvi";
            string fromAddress = "kaviyarasi.nallathambi@gmail.com";
            string toAddress = "sureshkumar.duraisamy@gmail.com";

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromAddress);
                    mail.To.Add(toAddress);
                    mail.Subject = "Test Email from c#";
                    mail.Body = "<h1>Hello!</h1><p>This is a test email sent from c# using the Gmail SMTP server.</p>";
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
