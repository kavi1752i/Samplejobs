using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Samplejobs
{
    class MailkitEmailSender
    {
        public async Task SendEmail()
        {
            string gmailpassword = "your_16_DIGIT_APP_PASSWRD";
            string fromAddress = "your.email@gmail.com";
            string toAddress = "recipient.email@gmail.com";

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Sender Name", fromAddress));
            email.To.Add(new MailboxAddress("Recipient Name", toAddress));
            email.Subject = "Text Emailfrom c#(Mailkit)";
            email.Body = new TextPart("plain")
            {
                Text = "This is a test email  sent using Mailkit."
            };

            try
            {
                using (var smtp = new SmtpClient())
                {
                    await smtp.ConnectAsync("smtp.gmail.com",587,SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync(fromAddress, gmailpassword);
                    await smtp.SendAsync(email);
                    await smtp.DisconnectAsync(true);
                    Console.WriteLine("email send successfully");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("failed to send email" + ex.Message);
            }
        }

    }
}
