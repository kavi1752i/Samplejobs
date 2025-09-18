using System;

namespace Samplejobs
{
    class Program
    {
        static void Main(string[] args)
        {
            MailkitEmailSender m = new MailkitEmailSender();
            m.SendEmail();
        }
    }
}
