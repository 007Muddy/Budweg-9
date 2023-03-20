using ProjektBudweg.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel
{
    public class MessageRepo
    {
        private List<Message> messageRepo = new List<Message>();

        private string connectionString { get; } = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        //Loading all messages from database(P1_DB_2023_09) and polulating into messageRepo
        public MessageRepo()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Bud_Message", sqlConnection))
                    {
                        SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                        while (sqlReader.Read())
                        {

                            int MessageID = sqlReader.GetInt32(0);
                            string Type = sqlReader.GetString(1);
                            DateTime Date = sqlReader.GetDateTime(2);
                            string Description = sqlReader.GetString(3);
                            bool IsAnonym = sqlReader.GetBoolean(4);

                            Message message = new Message(MessageID, Type, Date, Description, IsAnonym);
                            messageRepo.Add(message);

                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Return all messages from repo, so we can access it from other classes
        public List<Message> GeAllMessages()
        {
            return messageRepo;
        }

        public void Update(Message message)
        {
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UPDATE TABLE Bud_Message SET Department = @Department, Type = @Type, Date = @Date, Description = @Description, IsFlagged = @IsFlagged WHERE Employee_ID = @EmployeeID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Type", message.Type);
                        sqlCommand.Parameters.AddWithValue("@Date", message.Date);
                        sqlCommand.Parameters.AddWithValue("@Description", message.Description);
                        sqlCommand.Parameters.AddWithValue("IsFlagged", 1);

                        sqlCommand.ExecuteNonQuery();
                    }
                }

            }
            catch (SqlException e)
            {

                throw new Exception("An error occured while updating the Message record.", e);
            }
        }
    }
}
