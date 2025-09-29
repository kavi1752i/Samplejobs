using System;
using EmailSample;
using Json_ThreadOperation;
using Newtonsoft.Json;


namespace Samplejobs
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager m = new PatientManager();
            m.MenuDriven();


                // try
                //{
                //MailkitEmailSender sender = new MailkitEmailSender();
                //sender.SendEmail();
                // }
                //catch(Exception ex)
                //{

            //}

            // try
            //  {
            //EmailSender send = new EmailSender();
            //send.SendEmail();
            // }
            // catch (Exception ex)
            // {

            //}





        }
    }
}
