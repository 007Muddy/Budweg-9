using ProjektBudweg.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel.Repositories
{
    public class WhistleBlowerRepo
    {
        private List<Message> whistleblowerRepo = new List<Message>();


        private string connectionString { get; } = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        //Loading all messages from database(P1_DB_2023_09) and polulating into messageRepo
        public WhistleBlowerRepo()
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

                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Budweg_Message WHERE MessageType = 'Whistleblower'", sqlConnection))
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
                            whistleblowerRepo.Add(msg);

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
            return whistleblowerRepo;
        }
    }
}
