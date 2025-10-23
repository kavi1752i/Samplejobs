using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;



namespace Samplejobs
{
    public class Httpclient
    {
        public  bool Httpclientemail()
        {
            try
            {
                using (var clientserver = new HttpClient())
                {

                    clientserver.BaseAddress = new Uri("https://anaiyaan-api-dev.azurewebsites.net/_");
                    clientserver.DefaultRequestHeaders.Accept.Clear();
                    clientserver.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var email = new { FromAddress = "kaviyarasi.nallathambi@gmail.com", ToAddress = "kaviyarasi1702@gmail.com", Subject="hello!", Content="hai", gmailAppPassword = "miyi tnsh aogk yyvi" };
                    var response = clientserver.PostAsJsonAsync("api/SendEmail", email);
                    var result = response.Result;
                    if(result.IsSuccessStatusCode)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                    {    
                        return true;

                    }else
                    {
                        var errormessage =  result.Content.ReadAsStringAsync().Result;
                        return false;
                    }
                          
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
     }

        
            
        }
    }
    
