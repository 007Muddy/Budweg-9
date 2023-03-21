using ProjektBudweg.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel.Repositories
{
    public class DangerRepo
    {

        private List<Message> dangerRepo = new List<Message>();


        private string connectionString { get; } = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
    
        public DangerRepo()
        {
            RetrieveAll();

        }


        public void RetrieveAll()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Budweg_Message WHERE MessageType = 'Fare'", sqlConnection))
                    {
                        SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                        while (sqlReader.Read())
                        {

                            string Name = sqlReader.GetString(1);
                            string Lastname = sqlReader.GetString(2);
                            string Type = sqlReader.GetString(3);
                            string Department = sqlReader.GetString(4);
                            DateTime Date = sqlReader.GetDateTime(5);
                            string Description = sqlReader.GetString(6);

                            Message msg = new Message(Name, Lastname, Type, Department, Date, Description);
                            dangerRepo.Add(msg);

                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public List<Message> GetAll()
        {
            return dangerRepo;
        }
    }
}
