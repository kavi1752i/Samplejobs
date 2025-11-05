using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using  Samplejobs.models;
using System.Text.Json;



namespace Samplejobs
{
    public class Httpclient
    {
        public bool Httpclientemail()
        {
            try
            {
                using (var clientserver = new HttpClient())
                {

                    clientserver.BaseAddress = new Uri("https://anaiyaan-api-dev.azurewebsites.net/swagger/index.html");
                    clientserver.DefaultRequestHeaders.Accept.Clear();
                    clientserver.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var email = new { FromAddress = "kaviyarasi.nallathambi@gmail.com", ToAddress = "kaviyarasi1702@gmail.com", Subject = "hello!", Content = "hai", gmailAppPassword = "miyi tnsh aogk yyvi" };
                    var response = clientserver.PostAsJsonAsync("api/Email_", email);
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return true;

                    }
                    else
                    {
                        var errormessage = result.Content.ReadAsStringAsync().Result;
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public async Task Getpatientasync()
        {
            try
            {
                using (var clientserver = new HttpClient())
                {

                    clientserver.BaseAddress = new Uri("https://anaiyaan-api-dev.azurewebsites.net/swagger/index.html");
                    clientserver.DefaultRequestHeaders.Accept.Clear();
                    clientserver.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await clientserver.GetAsync("api/JSONOperation");

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response from api");

                    }
                    else
                    {
                        Console.WriteLine($"error:{response.StatusCode}");


                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:{ex.Message}");
            }
        }
        

            public async Task updatepatientasync()
            {
                try
                {
                    using (var clientserver = new HttpClient())
                    {

                        clientserver.BaseAddress = new Uri("https://anaiyaan-api-dev.azurewebsites.net/swagger/index.html");
                        clientserver.DefaultRequestHeaders.Accept.Clear();
                        clientserver.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                   
                    var updatename = new 
                    {
                        id = 1,
                        Name = "Updated Name",
                        Email = "Updated email",
                        Mobienumber = 1234567890,
                        Address = "Updated Address",
                        Location = "Updated Location"

                    };
                    var jsoncontent = new StringContent(System.Text.Json.JsonSerializer.Serialize(updatename));
                    var response = await clientserver.PutAsync("api/JSONOperation",jsoncontent);
                    if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Response from api");

                        }
                        else
                        {
                            Console.WriteLine($"error:{response.StatusCode}");


                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception:{ex.Message}");
                }



            }
        public async Task Deletepatientasync()
        {
            try
            {
                using (var clientserver = new HttpClient())
                {

                    clientserver.BaseAddress = new Uri("https://anaiyaan-api-dev.azurewebsites.net/swagger/index.html");
                    clientserver.DefaultRequestHeaders.Accept.Clear();
                    clientserver.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await clientserver.DeleteAsync("api/JSONOperation");

                    if (response.IsSuccessStatusCode)
                    {
                       
                        Console.WriteLine("Record deleted successfully");

                    }
                    else
                    {
                        Console.WriteLine($"error:{response.StatusCode}");


                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:{ex.Message}");
            }
        }

    }
}



    
