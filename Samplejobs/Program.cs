using System;
using Newtonsoft.Json;

namespace Samplejobs
{
    class program
    {

        static void Main(string[] args)
        {

            Httpclient obj = new Httpclient();
            obj.Httpclientemail();

            // PatientRepository obj = new PatientRepository();
            //obj.MenuDriven(); 
            // PatientManager m = new PatientManager();
            // m.MenuDriven();


            //  try
            //{
            // MailkitEmailSender sender = new MailkitEmailSender();
            // sender.SendEmail();
            // }
            //catch(Exception ex)
            //{

            // }
            /*
              try
               {
             EmailSender send = new EmailSender();
             send.SendEmail();
             }
             catch (Exception ex)
              {

             }
            */

        }


    }
}
        

