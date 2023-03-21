using ProjektBudweg.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel
{
    public class MessageRepo
    {

        private string connectionString { get; } = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        //Loading all messages from database(P1_DB_2023_09) and polulating into messageRepo
        public MessageRepo()
        {
           
        }

        //Return all messages from repo, so we can access it from other classes
  

        public bool AddMessage(string name, string lastName, string msgType, string department, DateTime date, string msg)
        {
            bool addSucces = false;
            try
            {

                using (SqlConnection sq = new SqlConnection(connectionString))
                {
                    sq.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Budweg_Message (Name, Lastname, MessageType, Department, Date, Message)" +
                        "VALUES(@name, @lastName, @messageType, @department, @date, @message)", sq))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                        cmd.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastName;
                        cmd.Parameters.Add("@messageType", SqlDbType.NVarChar).Value = msgType;
                        cmd.Parameters.Add("@department", SqlDbType.NVarChar).Value = department;
                        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
                        cmd.Parameters.Add("@message", SqlDbType.NVarChar).Value = msg;
                        cmd.ExecuteNonQuery();
                  
                        addSucces = true;
                        return addSucces;

                    }
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
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
