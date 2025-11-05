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

       

        public Patient Add(Patient addpatient)
        {
            patients.Add(addpatient);
            return addpatient;
        }

       

        public Patient Update(Patient p)
        {
                var existing = patients.FirstOrDefault(s => s.patientid == p.patientid);

            if (existing != null)
            {
                existing.name = p.name;
                existing.emailid = p.emailid;
                existing.address = p.address;
                existing.location = p.location;
                
            }
            return existing;
            
            
        }

        public string  Delete(int id)
        {
       
                var a = patients.FirstOrDefault(s => s.patientid ==id);
                
                    if(a!=null)
                    {
                    patients.Remove(a);
                    return "patient deleted successfully";
                    }
            return "patient does not found";

            }
            
        
        

    }

}







           