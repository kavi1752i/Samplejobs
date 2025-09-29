using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
 

namespace EmailSample
{
     public class MailkitEmailSender
    {
        
            public async Task SendEmail()
            {
                string gmailpassword = "miyi tnsh aogk yyvi";
                string fromAddress = "kaviyarasi.nallathambi@gmail.com";
                string toAddress = "sureshkumar.duraisamy@gmail.com";

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("kaviyarasi", fromAddress));
                email.To.Add(new MailboxAddress("sureshkumar", toAddress));
                email.Subject = "Text Emailfrom c#(Mailkit)";
                email.Body = new TextPart("plain")
                {
                    Text = "This is a test email  sent using Mailkit."
                };

                try
                {
                    using (var smtp = new SmtpClient())
                    {
                        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                        smtp.Authenticate(fromAddress, gmailpassword);
                        smtp.Send(email);
                        smtp.Disconnect(true);
                        Console.WriteLine("email send successfully");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("failed to send email" + ex.Message);
                }
            }

        }
    }


