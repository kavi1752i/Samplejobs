using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace DBConnection
{
    public class PatientRepository
    {
        private string connectionstring = "Server=DESKTOP-Q9V2K5P\\SQLEXPRESS;Database=Batch11;User Id = sa;Password=Anaiyaan@123;";
        public void MenuDriven()
        {

            while (true)
            {

                Console.WriteLine("1. Addpatients");
                Console.WriteLine("2.updatepatients");
                Console.WriteLine("3.deletepatients");
                Console.WriteLine("4.searchpatients");
                Console.WriteLine("5. GetPatients");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter a choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                    Addpatients();

                else if (choice == 2)
                    updatepatients();
                else if (choice == 3)
                    deletepatients();
                else if (choice == 4)
                    searchpatients();
                else if (choice == 5)
                    GetPatients();
                else if (choice == 6)
                    break;
                else
                {
                    Console.WriteLine("not available information");
                }
            }
        }
        public void Addpatients()
        {
            try
            {

                Console.WriteLine("Enter a index how many patient want to add");
                int a = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < a; i++)
                {

                    PatientDetails data = new PatientDetails();

                    Console.WriteLine("enter your patientid");
                    data.patientid = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("enter your patientname");
                    data.patientname = Console.ReadLine();
                    Console.WriteLine("enter your age");
                    data.age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("enter your city");
                    data.city = Console.ReadLine();

                    string sql = $"insert into patient values('{data.patientname}',{data.age},'{data.city }')";
                    var connection = new SqlConnection(connectionstring);
                    connection.Open();
                    var result = connection.Execute(sql);
                    connection.Close();

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            { 
     
                throw;
            }
        }
        public void updatepatients()
        {
            try
            {
                Console.WriteLine("Enter a patient id want to update ");
                int b = Convert.ToInt32(Console.ReadLine());
                {
                    PatientDetails p = new PatientDetails();
                    
                    Console.WriteLine("enter a patientname");
                    p.patientname = Console.ReadLine();
                    Console.WriteLine("enter a patient age");
                    p.age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter a city");
                    p.city = Console.ReadLine();

                    var connection = new SqlConnection(connectionstring);
                    connection.Open();
                    string updateQuery  = $"update patient set  patientname = @patientname,age=@age,city=@city where patientid=@patientid";
                    var result = connection.Execute(updateQuery, new { patientname = p.patientname, age = p.age, city = p.city, patientid = b });
                    connection.Close();
                    Console.WriteLine(result > 0 ? "record updated successfully" : "updated failed");

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void deletepatients()
        {
            try
            {

                Console.WriteLine("enter id to delete");
                int id = Convert.ToInt32(Console.ReadLine());

                string sql = $"delete from patient where patientid ={id}";
                var connection = new SqlConnection(connectionstring);
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();


            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void searchpatients()
        {
            try
            {

                Console.WriteLine("enter a patient id to serach");
                var id = Convert.ToInt32( Console.ReadLine());

                var connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = $"select*from patient where patientid = @patientid";
                var result = connection.QuerySingleOrDefault<PatientDetails>(sql,new { patientid = id });
                if(result!=null)
                {
                    Console.WriteLine($"patientid:{result.patientid}");
                    Console.WriteLine($"patientname:{result.patientname}");
                    Console.WriteLine($"age:{result.age}");
                    Console.WriteLine($"city:{result.city}");

                }
                else
                {
                    Console.WriteLine("patient does not found");
                }
                

            }

            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


            public List<PatientDetails> GetPatients()
            {
                try
                {

                    string sql = $"select* from patient";
                    var connection = new SqlConnection(connectionstring);
                    connection.Open();
                    var result = connection.Query<PatientDetails>(sql).ToList();
                    
                Console.WriteLine("patient list");
                foreach(var p in result)
                {
                    Console.WriteLine($"{p.patientid} | {p.patientname}|{p.age}|{p.city}");
                }
                connection.Close();
                return result;
                }
                catch (SqlException ex)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

    }


