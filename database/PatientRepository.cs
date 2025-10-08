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
        public List<PatientDetails> GetPatients()
        {
            try
            {
                string connectionstring = "Server=DESKTOP-Q9V2K5P\\SQLEXPRESS;Database=Batch11;User Id = sa;Password=Anaiyaan@123;";
                string sql = $"select* from patient";        
                var connection = new SqlConnection(connectionstring);
                connection.Open();
                var result = connection.Query<PatientDetails>(sql).ToList();
                connection.Close();
                return result;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
            }

        public void Addpatients(PatientDetails record)
        {
            try
            {
                string connectionstring = "Server=DESKTOP- Q9V2K5P\\SQLEXPRESS;Database=Batch11;User Id = sa;Password=Anaiyaan@123;";
                string sql = $"insert into Patient ";
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
    }

    }

