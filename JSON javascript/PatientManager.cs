using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;

namespace Json_ThreadOperation
{
    public class PatientManager
    {
        public List<Patient> patients = new List<Patient>();


        private string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\data\\javascript.json";
        
        public void MenuDriven()
        {

            while (true)
            {

                Console.WriteLine("1.Add");
                Console.WriteLine("2.Update");
                Console.WriteLine("3.Delete");
                Console.WriteLine("4.PrintAllPatient");
                Console.WriteLine("5.Search");          
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter a choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                    Add();
                
                else if (choice == 2)
                    Update();
                else if (choice == 3)
                    Delete();
                else if (choice == 4)
                    PrintAllPatient();
                else if (choice == 5)
                    Search();
              


                else if (choice == 6)
                    break;
                else
                {
                    Console.WriteLine("not available information");
                }
            }
        }
        public void Loaddata()
        {
            try
            {
                string json = File.ReadAllText(filepath);
                patients = JsonConvert.DeserializeObject<List<Patient>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured" + ex.Message);

            }

        }

        public void savedata()
        {
            try
            {
                string json = JsonConvert.SerializeObject(patients, Formatting.Indented);
                File.WriteAllText(filepath, json);

            }

        catch (Exception ex)
            {
                Console.WriteLine("an error occured" + ex.Message);

            }
        }
       
      

    

    public void Add()
        {
            try
            {
              
                Console.WriteLine("Enter a index how many patients want to add");
                int a = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < a; i++)
                {

                    Patient p = new Patient();
                    Console.WriteLine("enter a patients detaila" + " " + (i + 1));
                    Console.WriteLine("enter a patient name");
                    p.name = Console.ReadLine();
                    Console.WriteLine("enter a mobile number");
                    p.mobilenumber = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("enter a emaiid");
                    p.emailid = Console.ReadLine();
                    Console.WriteLine("enter a address");
                    p.address = Console.ReadLine();

                    Console.WriteLine("enter a location");
                    p.location = Console.ReadLine();
                   



                    if (patients.Any(s => s.name == p.name || s.mobilenumber == p.mobilenumber || s.emailid == p.emailid))
                    {
                        Console.WriteLine("patients already exits with the samenumber and emailsid");


                    }
                    else

                    {

                        patients.Add(p);
                        savedata();
                        Console.WriteLine("patient added sucessfully");

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured" + ex.Message);

            }

        }
        public void Update()
        {
            try
            {

                Console.WriteLine("Enter a mobilenumber to update ");
                long mobiletoupdate = Convert.ToInt64(Console.ReadLine());
 
               Patient var = patients.FirstOrDefault(s => s.mobilenumber == mobiletoupdate);

                if (var != null)
                {
                    Console.WriteLine("enter a name" + " " + var.name);
                    string name = Console.ReadLine();
                    if (name != "") var.name = name;

                    Console.WriteLine("enter a emailid" + " " + var.emailid);
                    string emailid = Console.ReadLine();
                    if (emailid != "") var.emailid = emailid;

                    Console.WriteLine("enter a adddress" + " " + var.address);
                    string addresss = Console.ReadLine();
                    if (addresss != "") var.address = addresss;

                    Console.WriteLine("enter a location" + " " + var.location);
                    string location = Console.ReadLine();
                    if (location != "") var.location = location;
                    savedata();
                    Console.WriteLine("patient added successfully");
                }
                else
                {
                    Console.WriteLine("patients does not found");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured" + ex.Message);
            }
        }
        public void Delete()
        {
            try
            {

                Console.WriteLine("enter a number to delete ");
                long numbertodelete = Convert.ToInt64(Console.ReadLine());


                Patient obj = patients.SingleOrDefault(s => s.mobilenumber == numbertodelete);
                {
                    if (obj != null)
                    {
                        savedata();

                        Console.WriteLine("patients deleted successfully");
                        patients.Remove(obj);


                    }

                    else
                    {

                        Console.WriteLine("patient does not found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured" + ex.Message);
            }

        }
        public void Search()
        {
            try
            {
                Console.WriteLine("Enter a number to search");
                string mobile = Console.ReadLine();


                List<Patient> patient = patients.Where(s => s.mobilenumber.ToString().Contains(mobile) || s.emailid.Contains(mobile)).ToList();

                if (patient != null)
                {
                    foreach (Patient q in patient)
                    {
                       
                        Console.WriteLine($"{q.name}    {q.mobilenumber}   {q.emailid}    {q.address}     {q.location}");
                    }


                }
                else
                {
                    Console.WriteLine("patients does not available");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured" + ex.Message);
            }

        }

        public void PrintAllPatient()
        {

            foreach (Patient z in patients)
            {
                Console.WriteLine("Name       Mobilenumber    Emailid      Address     Location");
                Console.WriteLine("" + z.name + "         " + z.mobilenumber + "         " + z.emailid + "       " + z.address + "        " + z
               .location);

            }
        }

    }

}





           